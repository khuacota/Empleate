using Empleate.Data;
using Empleate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empleate.Repository
{
    public class EmployeeHandler
    {
        private AppDbContext DBContext { get; set; }
        public EmployeeHandler(AppDbContext context)
        {
            this.DBContext = context;
        }

        public ICollection<Employee> filterByOccupation(string[] searchWords)
        {
            var occupationEmployee = this.DBContext.OcupacionesEmpleados.ToList();
            //return DBContext.Profesiones.Where(c => c.Descripcion.Contains(description)).Include(e => e.Empleados).FirstOrDefault();
        }
    }
}
