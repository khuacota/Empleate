using Empleate.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Empleate.Data
{
    public class AppDbContext : IdentityDbContext<User, Role, string, IdentityUserClaim<string>,
    UserRole, IdentityUserLogin<string>,
    IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>(b =>
            {
                b.ToTable("Users");
            });

            builder.Entity<Role>(role =>
            {
                role.ToTable("Roles");
                role.HasKey(r => r.Id);
                role.HasIndex(r => r.NormalizedName).HasName("RoleNameIndex").IsUnique();
                role.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();

                role.Property(u => u.Name).HasMaxLength(256);
                role.Property(u => u.NormalizedName).HasMaxLength(256);

                role.HasMany<UserRole>()
                    .WithOne(ur => ur.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();
                role.HasMany<IdentityRoleClaim<string>>()
                    .WithOne()
                    .HasForeignKey(rc => rc.RoleId)
                    .IsRequired();
            });

            builder.Entity<IdentityRoleClaim<string>>(roleClaim =>
            {
                roleClaim.HasKey(rc => rc.Id);
                roleClaim.ToTable("RoleClaims");
            });

            builder.Entity<UserRole>(userRole =>
            {
                userRole.ToTable("UserRoles");
                userRole.HasKey(r => new { r.UserId, r.RoleId });
            });

            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");


            builder.Entity<Role>().HasData(
                new Role() { Id = "1", Name = "Employee", NormalizedName = "EMPLOYEE"},
                new Role() { Id = "2", Name = "Company", NormalizedName = "COMPANY"}
            );
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
