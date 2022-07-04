using Microsoft.EntityFrameworkCore;
using TutoriaisBlogApi.Context;
using TutoriaisBlogApi.Models;

namespace TutoriaisBlogApi.Services
{
  public class PostagemService : IPostagemService
  {
    private readonly AppDbContext _context;

    public PostagemService(AppDbContext context)
    {
      _context = context;
    }


    public async Task<IEnumerable<Postagem>> GetPostagens()
    {
      return await _context.Postagens.ToListAsync();
    }
    public async Task<Postagem> GetPostagem(int id)
    {
      Postagem? postagem = await _context.Postagens.FindAsync(id);
      return postagem;
    }

    //public async Task<IEnumerable<Postagem>> GetPostagensPorIdUsuario(int idUsuario)
    //{
    //  Postagem postagem1 = new Postagem();
    //  await _context.Postagens.FindAsync(postagem1.UsuarioId.Equals(idUsuario));
    //  foreach ()
    //  IEnumerable<Postagem>? postagem = await _context.Postagens.FindAsync(postagem1.UsuarioId.Equals(idUsuario));
    //  return postagem;
    //}

    public async Task CreatePostagem(Postagem postagem)
    {
      _context.Postagens.Add(postagem);
      await _context.SaveChangesAsync();
    }

    public async Task UpdatePostagem(Postagem postagem)
    {
      _context.Entry(postagem).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    }
    public async Task DeletePostagem(Postagem postagem)
    {
      _context.Postagens.Remove(postagem);
      await _context.SaveChangesAsync();

    }

  }
}
