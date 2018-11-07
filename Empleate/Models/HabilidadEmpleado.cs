using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Empleate.Models
{
    public class HabilidadEmpleado
    {

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Habilidad { get; set; }

        public int EmpleadoId { get; set; }
        [ForeignKey("EmpleadoId")]
        public Empleado Empleado { get; set; }
    }
}
