using TutoriaisBlogApi.Models;
using TutoriaisBlogApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TutoriaisBlogApi.Context.Dtos;
using AutoMapper;
using TutoriaisBlogApi.Context.Dtos.Usuario;


//Essa classe tem como objetivo gerenciar as respostas da API
namespace TutoriaisBlogApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  //[Produces("application/json")]
  public class UsuarioController : ControllerBase
  {
    private IUsuarioService _usuarioService;
    private IMapper _mapper;
    public UsuarioController(IUsuarioService usuarioService, IMapper mapper)
    {
      _usuarioService = usuarioService;
      _mapper = mapper;
    }

    //Obtém todos os usuários.
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IAsyncEnumerable<Usuario>>> GetUsuarios()
    {
      try
      {
        IEnumerable<Usuario> usuarios = await _usuarioService.GetUsuarios();
        List<ReadUsuarioDto> usuariosDto = new List<ReadUsuarioDto>();
        foreach (Usuario usuario in usuarios)
        {
          ReadUsuarioDto usuarioDto = _mapper.Map<ReadUsuarioDto>(usuario);
          usuariosDto.Add(usuarioDto);
        }
          return Ok(usuarios);
      }
      catch
      {
        //return BadRequest("Request inválido");
        return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter usuários");
      }
    }
    [HttpGet("UsuariosPorNome")]
    public async Task<ActionResult<IAsyncEnumerable<Usuario>>> GetUsuarioByName([FromQuery] string nome)
    {
      try
      {
        //TODO: Corrigir implementação, pos o GetUsuarioByName retorna uma lista de usuarios com o param nome.
        ReadUsuarioDto usuariosByNameDto;
        IEnumerable<Usuario> usuariosByName = await _usuarioService.GetUsuarioByName(nome);
        if (usuariosByName.Count() == 0)
          return NotFound($"Não foi encontrado nenhum usuário com o critério: {nome}.");
        else
          usuariosByNameDto = _mapper.Map<ReadUsuarioDto>(usuariosByName);

        return Ok(usuariosByName);
      }
      catch
      {
        return BadRequest("Request inválido.");
      }
    }

    [HttpGet("{id:int}", Name = "GetUsuario")]
    public async Task<ActionResult<Usuario>> GetUsuario(int id)
    {
      try
      {
        ReadUsuarioDto usuarioPorIdDto;
        var usuarioPorId = await _usuarioService.GetUsuario(id);
        if (usuarioPorId == null)
          return NotFound($"Não foi encontrado nenhum usuário com o ID: {id}.");
        else
          usuarioPorIdDto = _mapper.Map<ReadUsuarioDto>(usuarioPorId);

        return Ok(usuarioPorIdDto);
      }
      catch
      {
        return BadRequest("Request inválido.");
      }
    }

    [HttpPost]
    public async Task<ActionResult> CreateUsuario(CreateUsuarioDto usuarioDto) //[FromBody]
    {
      Usuario usuario = _mapper.Map<Usuario>(usuarioDto);
      try
      {
        await _usuarioService.CreateUsuario(usuario);
        return CreatedAtRoute(nameof(GetUsuario), new { id = usuario.Id }, usuario);
      }
      catch
      {
        return BadRequest("Request inválido.");
      }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateUsuario(int id, [FromBody] UpdateUsuarioDto usuarioDto)
    {
      try
      {
        Usuario? usuario = await _usuarioService.GetUsuario(id);
        if (usuario != null)
        {
          _mapper.Map(usuarioDto, usuario);
          await _usuarioService.UpdateUsuario(usuario);
          //return NoContent();
          return Ok($"Usuário com id: {id} foi atualizado com sucesso.");
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

    //TODO fazer mapeamento com Dto
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteUsuario(int id)
    {
      try
      {
        var usuario = await _usuarioService.GetUsuario(id);
        if (usuario != null)
        {
          await _usuarioService.DeleteUsuario(usuario);
          return Ok($"Usuário com ID: {id} deletado com sucesso.");
        }
        else
        {
          return NotFound($"Não foi encontrado nenhum usuário com ID: {id}.");
        }
      }
      catch
      {
        return BadRequest("Request inválido.");
      }
    }


  }
}

