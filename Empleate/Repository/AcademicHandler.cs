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
        
        public void CreateEmpleado(Empleado item)
        {
            this.DBContext.Empleados.Add(item);

            this.DBContext.SaveChanges();
        }

        public void Create(Academico item)
        {

            if(item.Idiomas.Count < 1 || item.Titulos.Count < 1)
            {
                throw new Exception("invalid quantity");
            }
                
            foreach (var idioma in item.Idiomas)
            {
                if (!ValidIdioma(idioma))
                {
                    throw new Exception("invalid language");
                }
                    
            }
            foreach (var titulo in item.Titulos)
            {
                if (!ValidTitulo(titulo))
                {

                    throw new Exception("invalid title");
                }
            }
            foreach (var exp in item.Experiencias)
            {
                if (!ValidExp(exp))
                {
                    throw new Exception("invalid experience");
                }
                    
            }
            this.DBContext.Titulos.AddRange(item.Titulos);
            this.DBContext.Idiomas.AddRange(item.Idiomas);
            if (item.Experiencias != null)
            {
                this.DBContext.Experiencias.AddRange(item.Experiencias);

            }
            this.DBContext.SaveChanges();
        }

        public Boolean ValidTitulo(Titulo titulo)
        {
            Boolean res = true;
            Regex regex = new Regex(@"^[a-zA-Z][a-zA-Z0-9]*$");
            res &= regex.IsMatch(titulo.descripcion);
            regex = new Regex(@"^[a-zA-Z][a-zA-Z]*$");
            res &= regex.IsMatch(titulo.grado);
            return res;
        }

        public Boolean ValidExp(Experiencia exp)
        {
            Boolean res = true;
            Regex regex = new Regex(@"^[a-zA-Z][a-zA-Z0-9]*$");
            res &= regex.IsMatch(exp.lugar);
            regex = new Regex(@"^[a-zA-Z][a-zA-Z]*$");
            res &= regex.IsMatch(exp.cargo);
            res &= DateTime.Compare(exp.inicio,exp.fin) < 0;
            res &= DateTime.Compare(exp.fin, DateTime.Today) <= 0;
            return res;
        }

        public Boolean ValidIdioma(Language idioma)
        {
            Boolean res = true;
            Regex regex = new Regex(@"^[a-zA-Z][a-zA-Z]*$");
            res &= regex.IsMatch(idioma.idioma);
            return res;
        }
    }
}
