using Empleate.Data;
using Empleate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Empleate.Repository
{
    

    public class OffersHandler
    {
        protected AppDbContext DBContext { get; set; }
        public OffersHandler(AppDbContext context)
        {
            this.DBContext = context;
        }

        public void Postulate(Postulation value)
        {
            this.DBContext.Postulations.Add(value);
            this.DBContext.SaveChanges();

        }

        public JobOfferModelGet GetOne(int id)
        {
            var offers = this.DBContext.Offers.Where(offer => offer.CompanyId == id).ToList();
            var job = new JobOfferModelGet()
            {
                City = offers[0].City,
                Deadline = offers[0].Deadline,
                Description = offers[0].Description,
                EndTime = offers[0].EndTime,
                MinExperience = offers[0].MinExperience,
                Profession = offers[0].Profession,
                StartTime = offers[0].StartTime
            };
            job.CompanyName = this.DBContext.Companies.Where(com => com.Id == offers[0].CompanyId).ToList()[0].Name;
            job.ReqLanguages = this.DBContext.RequiredLanguages.Where(offer => offer.OfferId == offers[0].Id).ToList();
            job.ReqSkills = this.DBContext.RequiredSkills.Where(offer => offer.OfferId == offers[0].Id).ToList();
            return job;

        }

        public ICollection<JobOfferModelGet> filterByCompany(string[] searchWords)
        {
            var companies = this.DBContext.Companies.ToList();
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
                jobOffers.AddRange(this.DBContext.Offers.Where(offer => offer.CompanyId == company.Id).ToList());
            }
            var results = new List<JobOfferModelGet>();
            foreach (var jobOffer in jobOffers)
            {
                var job = new JobOfferModelGet() {
                    City = jobOffer.City,
                    Deadline = jobOffer.Deadline,
                    Description = jobOffer.Description,
                    EndTime = jobOffer.EndTime,
                    MinExperience = jobOffer.MinExperience,
                    Profession = jobOffer.Profession,
                    StartTime = jobOffer.StartTime
                };
                job.CompanyName = this.DBContext.Companies.Where(com => com.Id == jobOffer.CompanyId).ToList()[0].Name;
                job.ReqLanguages = this.DBContext.RequiredLanguages.Where(offer => offer.OfferId == jobOffer.Id).ToList();
                job.ReqSkills = this.DBContext.RequiredSkills.Where(offer => offer.OfferId == jobOffer.Id).ToList();
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
            this.DBContext.Offers.Add(oferta);
            this.DBContext.RequiredLanguages.AddRange(item.ReqLanguages);
            if (item.ReqSkills != null)
            {
                this.DBContext.RequiredSkills.AddRange(item.ReqSkills);

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
