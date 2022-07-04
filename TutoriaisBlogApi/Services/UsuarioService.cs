using TutoriaisBlogApi.Context;
using TutoriaisBlogApi.Models;
using Microsoft.EntityFrameworkCore;

//Esse classe tem como objetivo fazer as alterações no banco.
namespace TutoriaisBlogApi.Services
{
  public class UsuarioService : IUsuarioService
  {
    private readonly AppDbContext _context;
    public UsuarioService(AppDbContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<Usuario>> GetUsuarios()
    {
      return await _context.Usuarios.ToListAsync();
    }

    public async Task<IEnumerable<Usuario>> GetUsuarioByName(string nome)
    {
      IEnumerable<Usuario> usuarios;
      if (!string.IsNullOrWhiteSpace(nome))
      {
        usuarios = await _context.Usuarios.Where(x => x.Nome.Contains(nome)).ToListAsync();
      }
      else
      {
        usuarios = await GetUsuarios();
      }
      return usuarios;
    }

    public async Task<Usuario> GetUsuario(int id)
    {
      var usuario = await _context.Usuarios.FindAsync(id);
      return usuario;
    }

    public async Task CreateUsuario(Usuario usuario)
    {
      _context.Usuarios.Add(usuario);
      await _context.SaveChangesAsync();
    }

    public async Task UpdateUsuario(Usuario usuario)
    {
      _context.Entry(usuario).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    }

    public async Task DeleteUsuario(Usuario usuario)
    {
      _context.Usuarios.Remove(usuario);
      await _context.SaveChangesAsync();
    }
  }
}
