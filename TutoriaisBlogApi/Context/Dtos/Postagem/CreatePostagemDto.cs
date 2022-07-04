using System.ComponentModel.DataAnnotations;

namespace TutoriaisBlogApi.Context.Dtos.Postagem
{
  public class CreatePostagemDto
  {
    [Required]
    [StringLength(300)]
    public string Conteudo { get; set; }
    [Required]
    public int UsuarioId { get; set; }
  }
}
