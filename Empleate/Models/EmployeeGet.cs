using Empleate.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Empleate.Models
{
    public class EmployeeGet
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }

        public ICollection<OccupationEmp> Occupations{ get; set; }
    }
}
