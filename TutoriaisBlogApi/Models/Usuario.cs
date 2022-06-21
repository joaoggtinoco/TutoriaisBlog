using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TutoriaisBlogApi.Models
{
  [Table("Usuarios")]
  public class Usuario
  {
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(80)]
    public string Nome { get; set; }
    [Required]
    [EmailAddress]
    [StringLength(100)]
    public string Email { get; set; }
    [Required]
    public int Idade { get; set; }
  }
}
