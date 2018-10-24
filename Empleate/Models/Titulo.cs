using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Empleate.Models
{
    public class Titulo
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string grado { get; set; }

        public string descripcion { get; set; }

        public int EmpleadoId { get; set; }
        [ForeignKey("EmpleadoId")]
        public Profesion Empleado { get; set; }
    }
}
