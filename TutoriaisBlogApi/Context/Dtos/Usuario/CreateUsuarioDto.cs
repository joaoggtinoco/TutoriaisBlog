using System.ComponentModel.DataAnnotations;

namespace TutoriaisBlogApi.Context.Dtos.Usuario
{
  public class CreateUsuarioDto
  {
    [Required(ErrorMessage = "O campo Nome é obrigatório")]
    [StringLength(80)]
    public string Nome { get; set; }
  
    [Required(ErrorMessage = "O campo E-mail é obrigatório")]
    [EmailAddress]
    [StringLength(100)]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "O campo Idade é obrigatório")]
    public int Idade { get; set; }
  }
}
