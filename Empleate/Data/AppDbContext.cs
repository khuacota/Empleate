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

        public DbSet<Employee> Empleados { get; set; }

        public DbSet<JobOffer> Ofertas { get; set; }

        public DbSet<Experience> Experiencias { get; set; }

        public DbSet<LanguageEmployee> Idiomas { get; set; }

        public DbSet<LanguageJob> IdiomasRequeridos { get; set; }

        public DbSet<Title> Titulos { get; set; }

        public DbSet<SkillEmployee> HabilidadEmp { get; set; }

        public DbSet<SkillJob> HabilidadesRequeridas { get; set; }

        public DbSet<Company> Empresas { get; set; }
    }
}
