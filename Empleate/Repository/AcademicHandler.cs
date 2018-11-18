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
            if (item.Idiomas.Count < 1 || item.Titulos.Count < 1)
            {
                throw new Exception("necesitas minimo 1 idioma");
            }
            if (item.Ocupaciones.Count < 1 && item.Titulos.Count < 1)
            {
                throw new Exception("necesitas minimo 1 titulo u ocupacion");

            }
                
            foreach (var idioma in item.Idiomas)
            {
                if (idioma.EmpleadoId != item.EmpleadoId)
                {
                    throw new Exception("idioma invalido");
                }
                    
            }
            foreach (var titulo in item.Titulos)
            {
                if (titulo.EmpleadoId != item.EmpleadoId)
                {

                    throw new Exception("titulo invalido");
                }
            }
            foreach (var ocupacion in item.Ocupaciones)
            {
                if (ocupacion.EmpleadoId != item.EmpleadoId)
                {
                    throw new Exception("ocupacion invalido");
                }
            }
            foreach (var exp in item.Experiencias)
            {
                if (!ValidExp(exp) && exp.EmpleadoId != item.EmpleadoId)
                {
                    throw new Exception("experiencia invalida");
                }
                    
            }
            this.DBContext.Idiomas.AddRange(item.Idiomas);
            if (item.Experiencias != null)
            {
                this.DBContext.Experiencias.AddRange(item.Experiencias);

            }
            if (item.Titulos != null)
            {
                this.DBContext.Titulos.AddRange(item.Titulos);

            }
            if (item.Ocupaciones != null)
            {
                this.DBContext.OcupacionesEmpleados.AddRange(item.Ocupaciones);

            }

            if (item.Habilidades != null)
            {
                this.DBContext.HabilidadEmp.AddRange(item.Habilidades);

            }
            this.DBContext.SaveChanges();
        }

        public Boolean ValidTitulo(Titulo titulo)
        {
            Boolean res = true;
            Regex regex = new Regex(@"^[a-zA-Z][a-zA-Z0-9]*$");
            res &= regex.IsMatch(titulo.Descripcion);
            regex = new Regex(@"^[a-zA-Z][a-zA-Z]*$");
            res &= regex.IsMatch(titulo.Grado);
            return res;
        }

        public Boolean ValidExp(Experiencia exp)
        {
            Boolean res = true;
            res &= DateTime.Compare(exp.Inicio,exp.Fin) < 0;
            res &= DateTime.Compare(exp.Fin, DateTime.Today) <= 0;
            return res;
        }

        public Boolean ValidIdioma(Language idioma)
        {
            Boolean res = true;
            Regex regex = new Regex(@"^[a-zA-Z][a-zA-Z]*$");
            res &= regex.IsMatch(idioma.Idioma);
            return res;
        }
    }
}
