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

        public void Postulate(Postulation value)
        {
            this.DBContext.Postulations.Add(value);
            this.DBContext.SaveChanges();

        }

        public JobOfferModel GetOne(int id)
        {
            var offers = this.DBContext.Ofertas.Where(offer => offer.CompanyId == id).ToList();
            var job = new JobOfferModel()
            {
                City = offers[0].City,
                CompanyId = offers[0].CompanyId,
                Deadline = offers[0].Deadline,
                Description = offers[0].Description,
                EndTime = offers[0].EndTime,
                MinExperience = offers[0].MinExperience,
                Profession = offers[0].Profession,
                StartTime = offers[0].StartTime
            };
            job.ReqLanguages = this.DBContext.IdiomasRequeridos.Where(offer => offer.OfferId == offers[0].Id).ToList();
            job.ReqSkills = this.DBContext.HabilidadesRequeridas.Where(offer => offer.OfferId == offers[0].Id).ToList();
            return job;

        }

        public ICollection<JobOfferModel> filterByCompany(string[] searchWords)
        {
            var companies = this.DBContext.Empresas.ToList();
            var companiesres = new List<Company>();
            var jobOffers = new List<JobOffer>();
            foreach (var company in companies)
            {
                foreach(var word in searchWords)
                {
                    if (company.Name.Contains(word))
                    {
                        companiesres.Add(company);   
                    }
                }
            }
            foreach(var company in companiesres)
            {
                jobOffers.AddRange(this.DBContext.Ofertas.Where(offer => offer.CompanyId == company.Id).ToList());
            }
            var results = new List<JobOfferModel>();
            foreach (var jobOffer in jobOffers)
            {
                var job = new JobOfferModel() {
                    City = jobOffer.City,
                    CompanyId = jobOffer.CompanyId,
                    Deadline = jobOffer.Deadline,
                    Description = jobOffer.Description,
                    EndTime = jobOffer.EndTime,
                    MinExperience = jobOffer.MinExperience,
                    Profession = jobOffer.Profession,
                    StartTime = jobOffer.StartTime
                };
                job.ReqLanguages = this.DBContext.IdiomasRequeridos.Where(offer => offer.OfferId == jobOffer.Id).ToList();
                job.ReqSkills = this.DBContext.HabilidadesRequeridas.Where(offer => offer.OfferId == jobOffer.Id).ToList();
                results.Add(job);
            }
            return results;
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
