using Empleate.Data;
using Empleate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Empleate.Repository
{
    

    public class OfertasHandler
    {
        protected AppDbContext DBContext { get; set; }
        public OfertasHandler(AppDbContext context)
        {
            this.DBContext = context;
        }

        public void Create(OfertaTrabajoModel item)
        {

            if(item.IdiomasReq.Count < 1 || item.HabilidadesReq.Count < 1)
            {
                throw new Exception("invalid quantity");
            }
                
            foreach (var idioma in item.IdiomasReq)
            {
                if (!ValidIdioma(idioma) && idioma.OfertaId != item.EmpresaId)
                {
                    throw new Exception("invalid language");
                }
                    
            }

            var oferta = new OfertaTrabajo() { 
                EmpresaId = item.EmpresaId,
                Ciudad = item.Ciudad,
                ExperienciaMin = item.ExperienciaMin,
                FechaLimite = item.FechaLimite,
                HoraFin = item.HoraFin,
                HoraInicio = item.HoraInicio,
                Profesion = item.Profesion
            };
            if (!ValidOferta(oferta))
            {
                throw new Exception("invalid data");
            }
            this.DBContext.Ofertas.Add(oferta);
            this.DBContext.IdiomasRequeridos.AddRange(item.IdiomasReq);
            if (item.HabilidadesReq != null)
            {
                this.DBContext.HabilidadesRequeridas.AddRange(item.HabilidadesReq);

            }
            this.DBContext.SaveChanges();
        }

        public Boolean ValidIdioma(LanguageRequerido idioma)
        {
            Boolean res = true;
            Regex regex = new Regex(@"^[a-zA-Z][a-zA-Z]*$");
            res &= regex.IsMatch(idioma.Idioma);
            return res;
        }

        public Boolean ValidOferta(OfertaTrabajo oferta)
        {
            Boolean res = true;
            Regex regex = new Regex(@"^[a-zA-Z][a-zA-Z]*$");
            res &= regex.IsMatch(oferta.Profesion);
            res &= regex.IsMatch(oferta.Ciudad);
            regex = new Regex(@"^[a-zA-Z][a-zA-Z0-9]*$");
            res &= regex.IsMatch(oferta.Descripcion);
            res &= oferta.ExperienciaMin >= 0 && oferta.ExperienciaMin <= 20;
            res &= DateTime.Compare(oferta.FechaLimite, DateTime.Today) > 0;
            return res;
        }
    }
}
