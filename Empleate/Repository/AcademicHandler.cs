using Empleate.Data;
using Empleate.Models;
using Microsoft.EntityFrameworkCore;
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
            var languages = this.DBContext.Languages.Where(idioma => idioma.EmployeeId == id).ToList();
            var skills = this.DBContext.EmployeeSkills.Where(idioma => idioma.EmployeeId == id).ToList();
            var degrees = this.DBContext.Degrees.Where(idioma => idioma.EmployeeId == id).ToList();
            var experiences = this.DBContext.Experiences.Where(idioma => idioma.EmployeeId == id).ToList();
            var occupations = this.DBContext.EmployeeOccupations.Where(oc => oc.EmployeeId == id).ToList();
            academic.Degrees = degrees;
            academic.Skills = skills;
            academic.Languages = languages;
            academic.Experiences = experiences;
            academic.Occupations = occupations;
            return academic;
        }

        public void Edit(Academic academic){
            Employee employee = this.DBContext.Employees.Include(emp => emp.Languages)
                .Include(emp => emp.Skills).Include(emp => emp.Titles).Include(emp => emp.Occupations)
                .Include(emp => emp.Experiences).SingleOrDefault(x => x.Id == academic.EmployeeId);
            if (employee == null)
            {
                throw new Exception("Empleado no existe");
            }
            List<LanguageEmployee> languageEmployees = employee.Languages;
            this.DBContext.Languages.RemoveRange(languageEmployees);
            List<Experience> experiences = employee.Experiences;
            this.DBContext.Experiences.RemoveRange(experiences);
            List<SkillEmployee> skills = employee.Skills;
            this.DBContext.EmployeeSkills.RemoveRange(skills);
            List<OccupationEmp> occupations = employee.Occupations;
            this.DBContext.EmployeeOccupations.RemoveRange(occupations);
            List<Title> titles = employee.Titles;
            this.DBContext.Degrees.RemoveRange(titles);
            this.DBContext.SaveChanges();
            this.Create(academic);

        }

        public void Create(Academic item)
        {
            var result =  this.DBContext.Languages.Where(idioma => idioma.EmployeeId == item.EmployeeId).ToList();
            
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
                    throw new Exception("ocupacion invalido");
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
            this.DBContext.Languages.AddRange(item.Languages);
            if (item.Experiences.LongCount() != 0)
            {
                this.DBContext.Experiences.AddRange(item.Experiences);

            }
            if (item.Degrees.LongCount() != 0)
            {
                this.DBContext.Degrees.AddRange(item.Degrees);

            }
            if (item.Occupations.LongCount() != 0)
            {
                this.DBContext.EmployeeOccupations.AddRange(item.Occupations);

            }
            if (item.Skills.LongCount() != 0)
            {
                this.DBContext.EmployeeSkills.AddRange(item.Skills);
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
