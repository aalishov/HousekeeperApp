using HousekeeperApp.Data.Seeding.Contracts;
using HousekeeperApp.Models;
using HousekeeperApp.Models.Enums;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousekeeperApp.Data.Seeding
{
    public class RequestsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Requests.Any())
            {
                return;
            }

            Random random = new Random();

            for (int i = 0; i < 100; i++)
            {
                Client client = dbContext.Clients.Skip(random.Next(0, dbContext.Clients.Count())).FirstOrDefault();

                int locationCount = dbContext.Locations.Where(x => x.ClientId == client.Id).Count();
                Location location = dbContext.Locations.Where(x => x.ClientId == client.Id).Skip(random.Next(0, locationCount)).FirstOrDefault();

                if (client != null && location != null)
                {
                    Request request = new Request()
                    {
                        Name = $"Request {i}",
                        Status = Models.Enums.Status.Pending,
                        Budget = 200,
                        Category = (Category)random.Next(0, 3),
                        Client = client,
                        Location = location,
                    };
                    dbContext.Requests.Add(request);
                }
            }
            for (int i = 0; i < 100; i++)
            {
                Client client = dbContext.Clients.Skip(random.Next(0, dbContext.Clients.Count())).FirstOrDefault();

                int locationCount = dbContext.Locations.Where(x => x.ClientId == client.Id).Count();
                Location location = dbContext.Locations.Where(x => x.ClientId == client.Id).Skip(random.Next(0, locationCount)).FirstOrDefault();

                Housekeeper housekeeper = dbContext.Housekeepers.Skip(random.Next(0, dbContext.Housekeepers.Count())).FirstOrDefault();

                if (client != null && location != null)
                {
                    Request request = new Request()
                    {
                        Name = $"Request {i}",
                        Status = Models.Enums.Status.PendingVisit,
                        Budget = 200,
                        Category = (Category)random.Next(0, 3),
                        Client = client,
                        Location = location,
                        ExpireDate = DateTime.Now.AddDays(random.Next(0, 50)),
                        Housekeeper = housekeeper,
                    };
                    dbContext.Requests.Add(request);
                }
            }
            for (int i = 0; i < 50; i++)
            {
                Client client = dbContext.Clients.Skip(random.Next(0, dbContext.Clients.Count())).FirstOrDefault();

                int locationCount = dbContext.Locations.Where(x => x.ClientId == client.Id).Count();
                Location location = dbContext.Locations.Where(x => x.ClientId == client.Id).Skip(random.Next(0, locationCount)).FirstOrDefault();

                Housekeeper housekeeper = dbContext.Housekeepers.Skip(random.Next(0, dbContext.Housekeepers.Count())).FirstOrDefault();

                if (client != null && location != null)
                {
                    Request request = new Request()
                    {
                        Name = $"Request {i}",
                        Status = Models.Enums.Status.Finished,
                        Budget = 200,
                        Category = (Category)random.Next(0, 3),
                        Client = client,
                        Location = location,
                        ExpireDate = DateTime.Now.AddDays(random.Next(0, 50) * -1),
                        Housekeeper = housekeeper,
                    };
                    dbContext.Requests.Add(request);
                }
            }
            await dbContext.SaveChangesAsync();
        }
    }
}
