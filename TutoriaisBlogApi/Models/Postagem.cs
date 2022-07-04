using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TutoriaisBlogApi.Models
{
  [Table("Postagens")]
  public class Postagem
  {
    [Key]
    public int Id{ get; set; }

    [Required]
    [StringLength(300)]
    public string Conteudo { get; set; }

    public virtual Usuario Usuario { get; set; }

    [Required]
    public int UsuarioId { get; set; }

  }
}
