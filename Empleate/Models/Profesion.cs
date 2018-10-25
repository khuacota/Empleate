using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Empleate.Models
{
    public class Profesion
    {
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public ICollection<Empleado> Empleados { get; set; }
    }
}
