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

        public void Create(JobOfferModel item)
        {

            var oferta = new JobOffer() { 
                CompanyId = item.CompanyId,
                Description = item.Description,
                City = item.City,
                MinExperience = item.MinExperience,
                Deadline = item.Deadline,
                EndTime = item.EndTime,
                StartTime = item.StartTime,
                Profession = item.Profession
            };
            if (!ValidOferta(oferta))
            {
                throw new Exception("invalid data");
            }
            this.DBContext.Ofertas.Add(oferta);
            this.DBContext.IdiomasRequeridos.AddRange(item.ReqLanguages);
            if (item.ReqSkills != null)
            {
                this.DBContext.HabilidadesRequeridas.AddRange(item.ReqSkills);

            }
            this.DBContext.SaveChanges();
        }

        public Boolean ValidIdioma(LanguageJob idioma)
        {
            Boolean res = true;
            Regex regex = new Regex(@"^[a-zA-Z][a-zA-Z]*$");
            res &= regex.IsMatch(idioma.Language);
            return res;
        }

        public Boolean ValidOferta(JobOffer oferta)
        {
            Boolean res = true;
            res &= oferta.MinExperience >= 0 && oferta.MinExperience <= 20;
            res &= DateTime.Compare(oferta.Deadline, DateTime.Today) > 0;
            return res;
        }
    }
}
