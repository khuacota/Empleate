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
            /*builder.Entity<Profesion>()
                .HasMany(p => p.Empleados)
                .WithOne(p => p.Profesion);
            builder.Entity<Empleado>()
            .HasOne(p => p.Profesion)
            .WithMany(b => b.Empleados)
            .HasForeignKey(x => x.ProfesionId);*/
        }

        public DbSet<Empleado> Empleados { get; set; }

        public DbSet<Profesion> Profesiones { get; set; }

    }
}
