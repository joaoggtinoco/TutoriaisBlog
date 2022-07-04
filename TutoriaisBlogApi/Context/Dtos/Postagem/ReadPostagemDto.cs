using System.ComponentModel.DataAnnotations;

namespace TutoriaisBlogApi.Context.Dtos.Postagem
{
  public class ReadPostagemDto
  {
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(300)]
    public string Conteudo { get; set; }

    public Models.Usuario Usuario { get; set; }
  }
}
