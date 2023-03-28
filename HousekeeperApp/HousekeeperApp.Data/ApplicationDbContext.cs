namespace HousekeeperApp.Data
{
    using Castle.Core.Resource;
    using HousekeeperApp.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System;
    using Housekeeper.Common;
    using Microsoft.EntityFrameworkCore.Migrations;
    using static System.Net.WebRequestMethods;

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

            // Create user - administrator
            User admin = this.CreateUser(GlobalConstants.AdminUsername);

            builder.Entity<User>().HasData(admin);

            // Create roles
            IdentityRole adminRole = CreateRole(GlobalConstants.AdminRole);
            IdentityRole firstRole = CreateRole(GlobalConstants.HousekeeperRole);
            IdentityRole secondRole = CreateRole(GlobalConstants.ClientRole);

            builder.Entity<IdentityRole>(
                option =>
                {
                    option.HasData(new IdentityRole[]
                    {
                        adminRole,
                        firstRole,
                        secondRole,
                    });
                });

            // Add admin to role
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = adminRole.Id,
                UserId = admin.Id,
            });

            Random random = new Random();

            // Add Clients
            for (int i = 0; i < 100; i++)
            {
                User user = this.CreateUser($"client{i}@abv.bg");
                Client client = new Client()
                {
                    UserId = user.Id,
                };

                builder.Entity<User>().HasData(user);
                builder.Entity<Client>().HasData(client);

                builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
                {
                    RoleId = secondRole.Id,
                    UserId = user.Id,
                });
            }

            // Add Housekeeperes
            for (int i = 0; i < 50; i++)
            {
                User user = this.CreateUser($"housekeeper{i}@abv.bg");
                Housekeeper housekeeper = new Housekeeper()
                {
                    UserId = user.Id,
                };

                builder.Entity<User>().HasData(user);
                builder.Entity<Housekeeper>().HasData(housekeeper);

                builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
                {
                    RoleId = firstRole.Id,
                    UserId = user.Id,
                });
            }
        }

        private static IdentityRole CreateRole(string roleName)
        {
            return new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = roleName, NormalizedName = roleName };
        }

        private User CreateUser(string email, string password = GlobalConstants.Password)
        {
            List<string> firstName = new List<string>() { "John", "Alex", "Jane", "Jack" };
            List<string> lastName = new List<string>() { "Johnson", "Alexandrov" };
            Random random = new Random();
            var hasher = new PasswordHasher<IdentityUser>();

            // Create user
            User user = new User()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = email,
                NormalizedUserName = email,
                Email = email,
                NormalizedEmail = email,
                EmailConfirmed = false,
                PasswordHash = hasher.HashPassword(null, password),
                SecurityStamp = string.Empty,
                FirstName = firstName[random.Next(0, firstName.Count)],
                LastName = lastName[random.Next(0, lastName.Count)],
            };
            return user;
        }
    }
}
