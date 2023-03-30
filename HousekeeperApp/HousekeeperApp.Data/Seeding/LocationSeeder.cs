using HousekeeperApp.Common;
using HousekeeperApp.Data.Seeding.Contracts;
using HousekeeperApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousekeeperApp.Data.Seeding
{
    public class LocationSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Locations.Any()) { return; }

            for (int i = 0; i < 50; i++)
            {
                Random random = new Random();
                Location location = new Location()
                {
                    Name = $"Location {i}",
                    Address = $"{SeederConstants.towns[random.Next(0, SeederConstants.towns.Count - 1)]}{i}",
                    Client = dbContext.Clients.Skip(random.Next(1, dbContext.Clients.Count())).FirstOrDefault(),
                };
                await dbContext.Locations.AddAsync(location);
            }
            await dbContext.SaveChangesAsync();
        }
    }
}