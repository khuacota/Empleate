using Empleate.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Empleate.Models
{
    public class Experiencia
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Lugar es requerido")]
        [RegularExpression(RegularExpression.NumTextValidation, ErrorMessage = "Lugar debe ser texto")]
        public string Lugar { get; set; }

        [Required(ErrorMessage = "Cargo es requerido")]
        [RegularExpression(RegularExpression.TextValidation, ErrorMessage = "Cargo debe ser texto")]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "Inicio es requerido")]
        public DateTime Inicio { get; set; }

        [Required(ErrorMessage = "Fin es requerido")]
        public DateTime Fin { get; set; }

        public int EmpleadoId { get; set; }
        [ForeignKey("EmpleadoId")]
        public Empleado Empleado { get; set; }
    }
}
