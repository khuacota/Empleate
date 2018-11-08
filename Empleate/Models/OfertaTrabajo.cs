using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Empleate.Validators;

namespace Empleate.Models
{
    public class OfertaTrabajo
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required(ErrorMessage = "Id de empresa es requerido")]
        public int EmpresaId { get; set; }


        [Required(ErrorMessage = "profesion es requerido")]
        [RegularExpression(RegularExpression.TextValidation, ErrorMessage = "profesion debe ser texto")]
        public string Profesion { get; set; }


        [Required(ErrorMessage = "descripcion es requerido")]
        [RegularExpression(RegularExpression.NumTextValidation, ErrorMessage = "descripcion debe ser texto")]
        public string Descripcion { get; set; }


        [Required(ErrorMessage = "experiencia minima es requerido")]
        public int ExperienciaMin { get; set; }


        [Required(ErrorMessage = "ciudad es requerido")]
        [RegularExpression(RegularExpression.TextValidation, ErrorMessage = "ciudad debe ser texto")]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "hora de inicio es requerido")]
        public DateTime HoraInicio { get; set; }


        [Required(ErrorMessage = "hora de salida es requerido")]
        public DateTime HoraFin { get; set; }


        [Required(ErrorMessage = "fecha limite de postulacion es requerido")]
        public DateTime  FechaLimite { get; set; }
    }
}
