using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Empleate.Models
{
    public class OfertaTrabajo
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int EmpresaId { get; set; }

        public string Profesion { get; set; }

        public string Descripcion { get; set; }

        public int ExperienciaMin { get; set; }

        public string Ciudad { get; set; }

        public DateTime HoraInicio { get; set; }

        public DateTime HoraFin { get; set; }

        public DateTime  FechaLimite { get; set; }
    }
}
