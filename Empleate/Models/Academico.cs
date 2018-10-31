using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empleate.Models
{
    public class Academico
    {
        public int EmpleadoId { get; set; }

        public ICollection<Experiencia> Experiencias { get; set; }

        public ICollection<Language> Idiomas { get; set; }

        public ICollection<Titulo> Titulos { get; set; }

        public ICollection<HabilidadEmpleado> Habilidades { get; set; }
    }
}
