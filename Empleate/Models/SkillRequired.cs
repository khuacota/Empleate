
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Empleate.Models
{
    public class SkillRequired
    {

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Habilidad es requerido")]
        public string Habilidad { get; set; }

        public int OfertaId { get; set; }
    }
}
