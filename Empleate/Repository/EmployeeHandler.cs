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
            var ocupations = new List<OccupationEmp>();
            foreach(var searchWord in searchWords)
            {

                ocupations.AddRange(this.DBContext.OcupacionesEmpleados.Where(oc => oc.Occupation.Contains(searchWord)));
            }
            var employees = new List<Employee>();
            foreach (var ocupation in ocupations)
            {
                employees.AddRange(this.DBContext.Empleados.Where(emp => emp.Id == ocupation.EmployeeId));
            }
            foreach(var emp in employees)
            {
                emp.Occupations.AddRange(ocupations.Where(oc => oc.EmployeeId == emp.Id));

            }
            return employees;
            //return DBContext.Profesiones.Where(c => c.Descripcion.Contains(description)).Include(e => e.Empleados).FirstOrDefault();
        }
    }
}
