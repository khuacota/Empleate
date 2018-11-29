using Empleate.Data;
using Empleate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Empleate.Repository
{
    

    public class AcademicHandler
    {
        protected AppDbContext DBContext { get; set; }
        public AcademicHandler(AppDbContext context)
        {
            this.DBContext = context;
        }
        
        public void CreateEmpleado(Employee item)
        {
            this.DBContext.Empleados.Add(item);

            this.DBContext.SaveChanges();
        }

        public void Create(Academic item)
        {
            var result =  this.DBContext.Idiomas.Where(idioma => idioma.EmployeeId == item.EmployeeId).ToList();
            if (result.ToArray().Length > 0)
            {
                throw new Exception("esta cuenta ya tiene informacion academica");
            }
            if (item.Languages.Count < 1 || item.Degrees.Count < 1)
            {
                throw new Exception("necesitas minimo 1 titulo e idioma");
            }
                
            foreach (var idioma in item.Languages)
            {
                if (idioma.EmployeeId != item.EmployeeId)
                {
                    throw new Exception("idioma invalido");
                }
                    
            }
            foreach (var titulo in item.Degrees)
            {
                if (titulo.EmployeeId != item.EmployeeId)
                {

                    throw new Exception("titulo invalido");
                }
            }
            foreach (var exp in item.Experiences)
            {
                if (!ValidExp(exp) && exp.EmployeeId != item.EmployeeId)
                {
                    throw new Exception("experiencia invalida");
                }
                    
            }
            this.DBContext.Titulos.AddRange(item.Degrees);
            this.DBContext.Idiomas.AddRange(item.Languages);
            if (item.Experiences != null)
            {
                this.DBContext.Experiencias.AddRange(item.Experiences);

            }
            if (item.Skills != null)
            {
                this.DBContext.HabilidadEmp.AddRange(item.Skills);

            }
            this.DBContext.SaveChanges();
        }

        public Boolean ValidTitulo(Title titulo)
        {
            Boolean res = true;
            Regex regex = new Regex(@"^[a-zA-Z][a-zA-Z0-9]*$");
            res &= regex.IsMatch(titulo.Description);
            regex = new Regex(@"^[a-zA-Z][a-zA-Z]*$");
            res &= regex.IsMatch(titulo.Grade);
            return res;
        }

        public Boolean ValidExp(Experience exp)
        {
            Boolean res = true;
            res &= DateTime.Compare(exp.Inicio,exp.Fin) < 0;
            res &= DateTime.Compare(exp.Fin, DateTime.Today) <= 0;
            return res;
        }

        public Boolean ValidIdioma(LanguageEmployee idioma)
        {
            Boolean res = true;
            Regex regex = new Regex(@"^[a-zA-Z][a-zA-Z]*$");
            res &= regex.IsMatch(idioma.Language);
            return res;
        }
    }
}
