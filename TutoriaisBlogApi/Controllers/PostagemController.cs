using TutoriaisBlogApi.Models;
using TutoriaisBlogApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TutoriaisBlogApi.Context.Dtos;
using AutoMapper;
using TutoriaisBlogApi.Context.Dtos.Postagem;

namespace TutoriaisBlogApi.Controllers
{

  [Route("api/[controller]")]
  [ApiController]
  //[Produces("application/json")]
  public class PostagemController : ControllerBase
  {
    private IPostagemService _postagemService;
    private IMapper _mapper;
    public PostagemController(IPostagemService postagemService, IMapper mapper)
    {
       _postagemService  = postagemService;
       _mapper = mapper;
    }


   
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IAsyncEnumerable<Postagem>>> GetPostagens()
    {
      try
      {
        IEnumerable<Postagem> postagens = await _postagemService.GetPostagens();
        List<ReadPostagemDto> postagensDto = new List<ReadPostagemDto>();
        foreach(Postagem postagem in postagens)
        {
         ReadPostagemDto postagemDto =  _mapper.Map<ReadPostagemDto>(postagem);
         postagensDto.Add(postagemDto);
        }
        return Ok(postagensDto);
      }
      catch
      {
        //return BadRequest("Request inválido");
        return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter postagens");
      }
    }


    [HttpGet("{id:int}", Name = "GetPostagem")]
    public async Task<ActionResult<Postagem>> GetPostagem(int id)
    {
      try
      {
        ReadPostagemDto postagemPorIdDto;
        var postagemPorId = await _postagemService.GetPostagem(id);
        if (postagemPorId == null)
          return NotFound($"Não foi encontrado nenhuma postagem com o ID: {id}.");
        else 
          postagemPorIdDto = _mapper.Map<ReadPostagemDto>(postagemPorId);
        return Ok(postagemPorIdDto);
      }
      catch
      {
        return BadRequest("Request inválido.");
      }
    }

    //[HttpGet("{usuarioId:int}", Name = "GetPostagens")]
    //public async Task<ActionResult<Postagem>> GetPostagensPorIdUsuario(int idUsuario)
    //{

    //}

    [HttpPost]
    public async Task<ActionResult> CreatePostagem(CreatePostagemDto postagemDto) //[FromBody]
    {
      Postagem postagem = _mapper.Map<Postagem>(postagemDto);
      try
      {
        await _postagemService.CreatePostagem(postagem);
        return CreatedAtRoute(nameof(GetPostagem), new { id = postagem.Id }, postagem);
      }
      catch
      {
        return BadRequest("Request inválido.");
      }
    }

    //TODO Adicionar Dto
    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdatePostagem(int id, [FromBody] Postagem postagem)
    {
      try
      {
        if (postagem.Id == id)
        {
          await _postagemService.UpdatePostagem(postagem);
          //return NoContent();
          return Ok($"Postagem com id: {id} foi atualizado com sucesso.");
        }
        else
        {
          return BadRequest("Dados inconsistentes");
        }
      }
      catch
      {
        return BadRequest("Request inválido.");
      }
    }

    //TODO Adicionar Dto
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeletePostagem(int id)
    {
      try
      {
        var postagem = await _postagemService.GetPostagem(id);
        if (postagem != null)
        {
          await _postagemService.DeletePostagem(postagem);
          return Ok($"Postagem com ID: {id} deletado com sucesso.");
        }
        else
        {
          return NotFound($"Não foi encontrado nenhuma postagem com ID: {id}.");
        }
      }
      catch
      {
        return BadRequest("Request inválido.");
      }
    }

    }
  }

