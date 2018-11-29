using Empleate.Validators;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Empleate.Models
{
    public class JobOffer
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required(ErrorMessage = "Id de empresa es requerido")]
        public int CompanyId { get; set; }


        [Required(ErrorMessage = "profesion es requerido")]
        [RegularExpression(RegularExpression.TextValidation, ErrorMessage = "profesion debe ser texto")]
        public string Profession { get; set; }


        [Required(ErrorMessage = "descripcion es requerido")]
        [RegularExpression(RegularExpression.NumTextValidation, ErrorMessage = "descripcion debe ser texto")]
        public string Description { get; set; }


        [Required(ErrorMessage = "experiencia minima es requerido")]
        public int MinExperience { get; set; }


        [Required(ErrorMessage = "ciudad es requerido")]
        [RegularExpression(RegularExpression.TextValidation, ErrorMessage = "ciudad debe ser texto")]
        public string City { get; set; }

        [Required(ErrorMessage = "hora de inicio es requerido")]
        public DateTime StartTime { get; set; }


        [Required(ErrorMessage = "hora de salida es requerido")]
        public DateTime EndTime { get; set; }


        [Required(ErrorMessage = "fecha limite de postulacion es requerido")]
        public DateTime Deadline { get; set; }
    }
}
