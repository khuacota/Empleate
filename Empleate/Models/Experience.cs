using Empleate.Validators;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Empleate.Models
{
    public class Experience
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Lugar es requerido")]
        [RegularExpression(RegularExpression.NumTextValidation, ErrorMessage = "Lugar debe ser texto")]
        public string Place { get; set; }

        [Required(ErrorMessage = "Cargo es requerido")]
        [RegularExpression(RegularExpression.TextValidation, ErrorMessage = "Cargo debe ser texto")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Inicio es requerido")]
        public DateTime Inicio { get; set; }

        [Required(ErrorMessage = "Fin es requerido")]
        public DateTime Fin { get; set; }

        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Empleado { get; set; }
    }
}
