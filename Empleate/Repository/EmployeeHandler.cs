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
            var occupationEmployee = this.DBContext.EmployeeOccupations.ToList();
            var ocupations = new List<OccupationEmp>();
            foreach(var searchWord in searchWords)
            {

                ocupations.AddRange(this.DBContext.EmployeeOccupations.Where(oc => oc.Occupation.Contains(searchWord)));
            }
            var employees = new List<Employee>();
            foreach (var ocupation in ocupations)
            {
                employees.AddRange(this.DBContext.Employees.Where(emp => emp.Id == ocupation.EmployeeId));
            }
            return employees;
            //return DBContext.Profesiones.Where(c => c.Descripcion.Contains(description)).Include(e => e.Employees).FirstOrDefault();
        }
    }
}
