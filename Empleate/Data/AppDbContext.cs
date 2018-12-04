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

        public DbSet<OfferJob> Ofertas { get; set; }

        public DbSet<Experience> Experiencias { get; set; }

        public DbSet<Language> Idiomas { get; set; }

        public DbSet<LanguageRequired> IdiomasRequeridos { get; set; }

        public DbSet<Degree> Titulos { get; set; }

        public DbSet<SkillEmployee> HabilidadEmp { get; set; }

        public DbSet<SkillRequired> HabilidadesRequeridas { get; set; }

        public DbSet<Company> Empresas { get; set; }
    }
}
