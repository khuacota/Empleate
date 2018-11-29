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
        
        public Academic GetOne(int id)
        {
            var academic = new Academic();
            var languages = this.DBContext.Idiomas.Where(idioma => idioma.EmployeeId == id).ToList();
            var skills = this.DBContext.HabilidadEmp.Where(idioma => idioma.EmployeeId == id).ToList();
            var degrees = this.DBContext.Titulos.Where(idioma => idioma.EmployeeId == id).ToList();
            var experiences = this.DBContext.Experiencias.Where(idioma => idioma.EmployeeId == id).ToList();
            academic.Degrees = degrees;
            academic.Skills = skills;
            academic.Languages = languages;
            academic.Experiences = experiences;
            return academic;
        }

        public void Create(Academic item)
        {
            var result =  this.DBContext.Idiomas.Where(idioma => idioma.EmployeeId == item.EmployeeId).ToList();
            
            if (item.Languages.Count < 1)
            {
                throw new Exception("necesitas minimo 1 titulo e idioma");
            }

            if(item.Occupations.Count < 1 && item.Degrees.Count < 1)
            {
                throw new Exception("necesitas minimo 1 titulo u ocupacion");
            }

            foreach (var idioma in item.Languages)
            {
                if (idioma.EmployeeId != item.EmployeeId)
                {
                    throw new Exception("idioma invalido");
                }
                    
            }
            foreach (var occupation in item.Occupations)
            {
                if (occupation.EmployeeId != item.EmployeeId)
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

        public Boolean ValidExp(Experience exp)
        {
            Boolean res = true;
            res &= DateTime.Compare(exp.Inicio,exp.Fin) < 0;
            res &= DateTime.Compare(exp.Fin, DateTime.Today) <= 0;
            return res;
        }
    }
}
