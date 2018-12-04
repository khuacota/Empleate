using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Empleate.Models
{
    public class Academic
    {
        [Required(ErrorMessage = "Id de Empleado es requerido")]
        public int EmpleadoId { get; set; }

        public ICollection<Experience> Experiencias { get; set; }

        [Required(ErrorMessage = "Almenos 1 idioma es requerido")]
        public ICollection<Language> Idiomas { get; set; }

        [Required(ErrorMessage = "Almenos 1 titulo es requerido")]
        public ICollection<Degree> Titulos { get; set; }

        public ICollection<SkillEmployee> Habilidades { get; set; }
    }
}
