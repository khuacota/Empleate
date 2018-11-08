using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Empleate.Validators;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Empleate.Models
{
    public class Academico
    {
        [Required(ErrorMessage = "Id de Empleado es requerido")]
        public int EmpleadoId { get; set; }

        public ICollection<Experiencia> Experiencias { get; set; }

        [Required(ErrorMessage = "Almenos 1 idioma es requerido")]
        public ICollection<Language> Idiomas { get; set; }

        [Required(ErrorMessage = "Almenos 1 titulo es requerido")]
        public ICollection<Titulo> Titulos { get; set; }
        
        public ICollection<HabilidadEmpleado> Habilidades { get; set; }
    }
}
