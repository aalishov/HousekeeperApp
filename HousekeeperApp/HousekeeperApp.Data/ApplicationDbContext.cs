namespace HousekeeperApp.Data
{
    using HousekeeperApp.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    // Add-Migration InitialMigration -OutputDir Migrations  -Project HousekeeperApp.Data -StartupProject HousekeeperApp.Web
    // Update-Database -Project HousekeeperApp.Data -StartupProject HousekeeperApp.Web
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
        {
        }

        public virtual DbSet<Housekeeper> Housekeepers { get; set; }

        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<Request> Requests { get; set; }

        public virtual DbSet<Location> Locations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // User-Housekeeper One-To-One
            builder.Entity<Housekeeper>(
                entity =>
                {
                    entity.HasOne(x => x.User)
                      .WithOne(x => x.Housekeeper)
                     .HasForeignKey<Housekeeper>(x => x.UserId)
                     .OnDelete(DeleteBehavior.Cascade);
                });

            // User-Client One-To-One
            builder.Entity<Client>(
             entity =>
             {
                 entity.HasOne(x => x.User)
                 .WithOne(x => x.Client)
                 .HasForeignKey<Client>(x => x.UserId)
                 .OnDelete(DeleteBehavior.Cascade);
             });
        }
    }
}
