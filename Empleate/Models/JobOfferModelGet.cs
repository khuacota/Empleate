using Empleate.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Empleate.Models
{
    public class JobOfferModelGet
    {
        
        public string CompanyName { get; set; }
        public string Profession { get; set; }
        public string Description { get; set; }
        public int MinExperience { get; set; }
        public ICollection<LanguageJob> ReqLanguages { get; set; }
        public ICollection<SkillJob> ReqSkills { get; set; }
        public string City { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime Deadline { get; set; }
    }
}
