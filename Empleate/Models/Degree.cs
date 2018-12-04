using Empleate.Validators;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Empleate.Models
{
    public class Degree
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Grado es requerido")]
        [RegularExpression(RegularExpression.TextValidation, ErrorMessage = "Grado debe ser texto")]
        public string Grado { get; set; }


        [Required(ErrorMessage = "Descripcion es requerido")]
        public string Descripcion { get; set; }

        public int EmpleadoId { get; set; }
        [ForeignKey("EmpleadoId")]
        public Employee Empleado { get; set; }
    }
}
