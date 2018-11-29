using Empleate.Validators;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Empleate.Models
{
    public class Title
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Grado es requerido")]
        [RegularExpression(RegularExpression.TextValidation, ErrorMessage = "Grade debe ser texto")]
        public string Degree { get; set; }


        [Required(ErrorMessage = "Descripcion es requerido")]
        public string Description { get; set; }

        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
    }
}
