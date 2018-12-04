using Empleate.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Empleate.Models
{
    public class OfferJobModel
    {

        [Required(ErrorMessage = "Nombre es requerido")]
        public int EmpresaId { get; set; }


        [Required(ErrorMessage = "Profesion es requerido")]
        [RegularExpression(RegularExpression.TextValidation, ErrorMessage = "Profesion debe ser texto")]
        public string Profesion { get; set; }


        [Required(ErrorMessage = "Descripcion es requerido")]
        [RegularExpression(RegularExpression.TextValidation, ErrorMessage = "Descripcion debe ser texto")]
        public string Descripcion { get; set; }


        [Required(ErrorMessage = "Experiencia minima es requerido")]
        public int ExperienciaMin { get; set; }


        [Required(ErrorMessage = "almenos 1 idioma es requerido")]
        public ICollection<LanguageRequired> IdiomasReq { get; set; }


        [Required(ErrorMessage = "almenos 1 habilidad es requerido")]
        public ICollection<SkillRequired> HabilidadesReq { get; set; }

        [Required(ErrorMessage = "Ciudad es requerido")]
        [RegularExpression(RegularExpression.TextValidation, ErrorMessage = "Ciudad debe ser texto")]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "Hora de inicio es requerido")]
        public DateTime HoraInicio { get; set; }

        [Required(ErrorMessage = "Hora de salida es requerido")]
        public DateTime HoraFin { get; set; }

        [Required(ErrorMessage = "Fecha limite de postulacion  es requerido")]
        public DateTime FechaLimite { get; set; }
    }
}
