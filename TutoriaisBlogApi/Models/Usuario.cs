using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

//Essa classe tem como objetivo ser a entidade do banco
namespace TutoriaisBlogApi.Models
{
  [Table("Usuarios")]
  public class Usuario
  {
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo Nome é obrigatório")]
    [StringLength(80)]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "O campo E-mail é obrigatório")]
    [EmailAddress]
    [StringLength(100)]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "O campo Idade é obrigatório")]
    public int Idade { get; set; }
    [JsonIgnore]
    public virtual List<Postagem> Postagens { get; set; }
  }
}
