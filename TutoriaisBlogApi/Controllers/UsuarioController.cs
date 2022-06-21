using TutoriaisBlogApi.Models;
using TutoriaisBlogApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TutoriaisBlogApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  //[Produces("application/json")]
  public class UsuarioController : ControllerBase
  {
    private IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
      _usuarioService = usuarioService;
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
        var usuarios = await _usuarioService.GetUsuarios();
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
        var usuariosByName = await _usuarioService.GetUsuarioByName(nome);
        if (usuariosByName.Count() == 0)
          return NotFound($"Não foi encontrado nenhum usuário com o critério: {nome}.");
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
        var usuarioPorId = await _usuarioService.GetUsuario(id);
        if (usuarioPorId == null)
          return NotFound($"Não foi encontrado nenhum usuário com o ID: {id}.");
        return Ok(usuarioPorId);
      }
      catch
      {
        return BadRequest("Request inválido.");
      }
    }

    [HttpPost]
    public async Task<ActionResult> CreateUsuario(Usuario usuario)
    {
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
    public async Task<ActionResult> UpdateUsuario(int id, [FromBody] Usuario usuario)
    {
      try
      {
        if (usuario.Id == id)
        {
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

