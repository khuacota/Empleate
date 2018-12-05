using Empleate.Models;
using Microsoft.EntityFrameworkCore;

namespace Empleate.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Postulation> Postulations { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<JobOffer> Offers { get; set; }

        public DbSet<Experience> Experiences { get; set; }

        public DbSet<LanguageEmployee> Languages { get; set; }

        public DbSet<LanguageJob> RequiredLanguages { get; set; }

        public DbSet<Title> Degrees { get; set; }

        public DbSet<SkillEmployee> EmployeeSkills { get; set; }

        public DbSet<SkillJob> RequiredSkills { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<OccupationEmp> EmployeeOccupations { get; set; }
    }
}
