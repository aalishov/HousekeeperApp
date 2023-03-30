using HousekeeperApp.Data;
using HousekeeperApp.Models;
using HousekeeperApp.Services.Contracts;
using HousekeeperApp.ViewModels.Locations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousekeeperApp.Services
{
    public class LocationsService : ILocationsService
    {
        private readonly ApplicationDbContext context;

        public LocationsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task CreateLocationAsync(CreateLocationViewModel model, string userId)
        {
            Client client = this.context.Clients.FirstOrDefault(x => x.UserId == userId);
            Location location = new Location()
            {
                Name = model.Name,
                Address = model.Address,
                Client = client,
            };
            await this.context.Locations.AddAsync(location);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            Location location = await this.GetLocationByIdAsync(id);

            if (location != null)
            {
                this.context.Locations.Remove(location);
                await this.context.SaveChangesAsync();
            }
        }

        public async Task<EditLocationViewModel> GetEditLocationViewModel(string id)
        {
            Location location = await this.GetLocationByIdAsync(id);

            return new EditLocationViewModel()
            {
                Id = location.Id,
                Name = location.Name,
                Address = location.Address,
            };
        }

        public async Task<Location> GetLocationByIdAsync(string id)
        {
            return await this.context.Locations.FindAsync(id);
        }

        public async Task<IndexLocationsViewModel> GetLocationsAsync(IndexLocationsViewModel model, string userId)
        {
            model.Locations = await this.context.Locations
                .Where(x => x.Client.UserId == userId)
                .Skip((model.Page - 1) * model.ItemsPerPage)
                .Take(model.ItemsPerPage)
                .Select(x => new IndexLocationViewModel() { Id = x.Id, Name = x.Name, Address = x.Address })
                .ToListAsync();

            model.ElementsCount = await this.context.Locations.Where(x => x.Client.UserId == userId).CountAsync();

            return model;
        }

        public async Task UpdateLocationAsync(EditLocationViewModel model)
        {
            Location location = await this.context.Locations.FindAsync(model.Id);
            location.Name = model.Name;
            location.Address = model.Address;
            this.context.Update(location);
            await this.context.SaveChangesAsync();
        }
    }
}
