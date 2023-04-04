namespace HousekeeperApp.Services
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HousekeeperApp.Data;
    using HousekeeperApp.Models;
    using HousekeeperApp.Services.Contracts;
    using HousekeeperApp.ViewModels.Users;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class UsersService : IUsersService
    {
        private ApplicationDbContext context;
        private UserManager<User> userManager;
        private RoleManager<IdentityRole> roleManager;

        public UsersService(ApplicationDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task DeleteUserByIdAsync(string id)
        {
            User user = await userManager.FindByIdAsync(id);
            user.Client.Requests.Clear();
            user.Client = null;

            await userManager.DeleteAsync(user);
        }

        public async Task CreateHousekeeperAsync(CreateHousekeeperViewModel model)
        {
            Housekeeper housekeeper = new Housekeeper()
            {
            };
            User user = new User()
            {
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                NormalizedEmail = model.Email,
                UserName = model.Email,
                NormalizedUserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailConfirmed = true,
                SecurityStamp = string.Empty,
                Housekeeper = housekeeper
            };

            await userManager.CreateAsync(user, model.Password);
            await userManager.AddToRoleAsync(user, nameof(Housekeeper));
        }

        public async Task UpdateUserAsync(EditUserViewModel model)
        {
            User user = await context.Users.FindAsync(model.Id);

            string role = userManager.GetRolesAsync(user).GetAwaiter().GetResult().FirstOrDefault();

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;

            // Change role
            if (role != model.Role)
            {
                user.Housekeeper = null;
                user.Client = null;
                if (model.Role == "Housekeeper")
                {
                    Housekeeper housekeeper = new Housekeeper() { };
                    user.Housekeeper = housekeeper;
                    await userManager.RemoveFromRoleAsync(user, nameof(Client));
                    await userManager.AddToRoleAsync(user, nameof(Housekeeper));
                }
                else
                {
                    Client client = new Client();
                    user.Client = client;
                    await userManager.RemoveFromRoleAsync(user, nameof(Housekeeper));
                    await userManager.AddToRoleAsync(user, nameof(Client));
                }
            }

            await context.SaveChangesAsync();
        }
        public async Task<EditUserViewModel> GetUserToEditByIdAsync(string id)
        {
            User user = await context.Users.FindAsync(id);
            EditUserViewModel model = null;
            if (user != null)
            {
                model = new EditUserViewModel()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Role = userManager.GetRolesAsync(user).GetAwaiter().GetResult().FirstOrDefault()
                };
            }
            return model;
        }

        public async Task<IndexUserViewModel> GetUserByIdAsync(string id)
        {
            User user = await context.Users.FindAsync(id);

            IndexUserViewModel model = null;

            if (user != null)
            {
                model = new IndexUserViewModel()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Role = userManager.GetRolesAsync(user).GetAwaiter().GetResult().FirstOrDefault()
                };
            }

            return model;
        }

        public async Task<IndexUsersViewModel> GetUsersAsync(int page = 1, int itemsPerPage = 10)
        {
            IndexUsersViewModel model = new IndexUsersViewModel();

            model.ItemsPerPage = itemsPerPage;
            model.Page = page;
            model.ElementsCount = await this.context.Users.CountAsync();

            model.Users = await this.context.Users
                  .Skip((page - 1) * itemsPerPage)
                  .Take(itemsPerPage)
                  .Select(x => new IndexUserViewModel()
                  {
                      Id = x.Id,
                      FirstName = x.FirstName,
                      LastName = x.LastName,
                      Email = x.Email,
                      Role = userManager.GetRolesAsync(x).GetAwaiter().GetResult().FirstOrDefault()
                  }
              ).ToListAsync();

            return model;
        }
    }
}
