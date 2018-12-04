using Empleate.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Empleate.Models
{
    public class JobOfferModel
    {

        [Required(ErrorMessage = "Nombre es requerido")]
        public int CompanyId { get; set; }


        [Required(ErrorMessage = "Profesion es requerido")]
        [RegularExpression(RegularExpression.TextValidation, ErrorMessage = "Profesion debe ser texto")]
        public string Profession { get; set; }


        [Required(ErrorMessage = "Descripcion es requerido")]
        [RegularExpression(RegularExpression.TextValidation, ErrorMessage = "Descripcion debe ser texto")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Experiencia minima es requerido")]
        public int MinExperience { get; set; }


        [Required(ErrorMessage = "almenos 1 idioma es requerido")]
        public ICollection<LanguageJob> ReqLanguages { get; set; }


        [Required(ErrorMessage = "almenos 1 habilidad es requerido")]
        public ICollection<SkillJob> ReqSkills { get; set; }

        [Required(ErrorMessage = "Ciudad es requerido")]
        [RegularExpression(RegularExpression.TextValidation, ErrorMessage = "Ciudad debe ser texto")]
        public string City { get; set; }

        [Required(ErrorMessage = "Hora de inicio es requerido")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "Hora de salida es requerido")]
        public DateTime EndTime { get; set; }

        [Required(ErrorMessage = "Fecha limite de postulacion  es requerido")]
        public DateTime Deadline { get; set; }
    }
}
