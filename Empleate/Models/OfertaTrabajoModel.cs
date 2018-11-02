using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empleate.Models
{
    public class OfertaTrabajoModel
    {
        public int EmpresaId { get; set; }

        public string Profesion { get; set; }

        public string Descripcion { get; set; }

        public int ExperienciaMin { get; set; }

        public ICollection<LanguageRequerido> IdiomasReq { get; set; }

        public ICollection<HabilidadRequerida> HabilidadesReq { get; set; }

        public string Ciudad { get; set; }

        public DateTime HoraInicio { get; set; }

        public DateTime HoraFin { get; set; }

        public DateTime  FechaLimite { get; set; }
    }
}
