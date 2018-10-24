using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Empleate.Models
{
    public class Experiencia
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string lugar { get; set; }

        public string cargo { get; set; }

        public DateTime inicio { get; set; }

        public DateTime fin { get; set; }

        public int EmpleadoId { get; set; }
        [ForeignKey("EmpleadoId")]
        public Profesion Empleado { get; set; }
    }
}
