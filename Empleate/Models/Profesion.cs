using System.Collections.Generic;

namespace Empleate.Models
{
    public class Profesion
    {
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public ICollection<Empleado> Empleados { get; set; }
    }
}
