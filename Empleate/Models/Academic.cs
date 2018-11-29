using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Empleate.Models
{
    public class Academic
    {
        [Required(ErrorMessage = "Id de Empleado es requerido")]
        public int EmployeeId { get; set; }

        public ICollection<Experience> Experiences { get; set; }

        [Required(ErrorMessage = "Al menos 1 idioma es requerido")]
        public ICollection<LanguageEmployee> Languages { get; set; }

        [Required(ErrorMessage = "Al menos 1 titulo es requerido")]
        public ICollection<Title> Degrees { get; set; }

        public ICollection<SkillEmployee> Skills { get; set; }
    }
}
