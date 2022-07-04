using TutoriaisBlogApi.Models;

namespace TutoriaisBlogApi.Services
{
  public interface IPostagemService
  {
    Task<IEnumerable<Postagem>> GetPostagens();
    Task<Postagem> GetPostagem(int id);
    Task CreatePostagem(Postagem postagem);
    Task UpdatePostagem(Postagem postagem);
    Task DeletePostagem(Postagem postagem);

  }
}
