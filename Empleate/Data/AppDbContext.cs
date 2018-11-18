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

        public DbSet<Empleado> Empleados { get; set; }

        public DbSet<OfertaTrabajo> Ofertas { get; set; }

        public DbSet<Experiencia> Experiencias { get; set; }

        public DbSet<Language> Idiomas { get; set; }

        public DbSet<LanguageRequerido> IdiomasRequeridos { get; set; }

        public DbSet<Titulo> Titulos { get; set; }

        public DbSet<HabilidadEmpleado> HabilidadEmp { get; set; }

        public DbSet<HabilidadRequerida> HabilidadesRequeridas { get; set; }

        public DbSet<Empresa> Empresas { get; set; }

        public DbSet<OcupacionEmpleado> OcupacionesEmpleados { get; set; }
    }
}
