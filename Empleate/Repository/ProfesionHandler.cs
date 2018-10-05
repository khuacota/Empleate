using Empleate.Data;
using Empleate.Models;
using Empleate.Repository.Interface;
using System;
using System.Linq;

namespace Empleate.Repository
{
    public class ProfesionHandler : EmpleateHandler<Profesion>, IProfesion
    {

        public ProfesionHandler(AppDbContext context) : base(context) { }

        public int CompleteTransaction()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
        }

        public Profesion FindProfesionByDescription(string description)
        {
            return Context.Profesiones.Where(c => c.Descripcion.Contains(description)).FirstOrDefault();
        }
    }
}
