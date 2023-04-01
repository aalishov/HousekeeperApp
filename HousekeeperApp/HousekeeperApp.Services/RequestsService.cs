using HousekeeperApp.Data;
using HousekeeperApp.Models;
using HousekeeperApp.Services.Contracts;
using HousekeeperApp.ViewModels.Housekeepers;
using HousekeeperApp.ViewModels.Locations;
using HousekeeperApp.ViewModels.Requests;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousekeeperApp.Services
{
    public class RequestsService : IRequestsService
    {
        private readonly ApplicationDbContext context;

        public RequestsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task CreateRequestAsync(CreateRequestViewModel model)
        {
            Client client = this.context.Clients.FirstOrDefault(x => x.UserId == model.UserId);

            Request request = new Request()
            {
                Name = model.Name,
                Description = model.Description,
                ExpireDate = model.ExpireDate,
                Budget = model.Budget,
                Category = model.Category,
                LocationId = model.LocationId,
                Client = client,
            };

            await this.context.Requests.AddAsync(request);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            Request request = this.context.Requests.Find(id);
            if (request != null)
            {
                this.context.Requests.Remove(request);
                await this.context.SaveChangesAsync();
            }
        }

        public async Task EditRequestByClientAsync(EditRequestViewModel model)
        {
            Request request = await this.context.Requests.FirstOrDefaultAsync(x => x.Id == model.Id);
            request.Name = model.Name;
            request.Description = model.Description;
            request.ExpireDate = model.ExpireDate;
            request.Budget = model.Budget;
            request.Category = model.Category;
            request.LocationId = model.LocationId;
            this.context.Update(request);
            await this.context.SaveChangesAsync();
        }



        public async Task<EditRequestViewModel> GetRequestToEditAsync(string id)
        {
            Request request = await this.context.Requests.FirstOrDefaultAsync(x => x.Id == id);

            return new EditRequestViewModel()
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                ExpireDate = request.ExpireDate,
                Budget = request.Budget,
                Category = request.Category,
                LocationId = request.LocationId,
            };
        }

        public async Task<IndexRequestsViewModel> GetIndexRequestsAsync(IndexRequestsViewModel model, string userId = null)
        {
            model.Requests = await this.context.Requests
                .Where(x => userId != null ? x.Client.UserId == userId : x.Id != null)
                .Skip((model.Page - 1) * model.ItemsPerPage)
                .Take(model.ItemsPerPage)
                .Select(x => new IndexRequestViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Status = x.Status,
                    Category = x.Category,
                    ExpireDate = x.ExpireDate > DateTime.Now.AddYears(-150) ? x.ExpireDate.ToShortDateString() : "-",
                    Housekeeper = $"{x.Housekeeper.User.FirstName} {x.Housekeeper.User.LastName}",
                })
                .ToListAsync();

            model.ElementsCount = await this.context.Requests
                .Where(x => userId != null ? x.Client.UserId == userId : x.Id != null).CountAsync();

            return model;
        }

        public Task<Request> GetRequestByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task Complete(string id)
        {
            Request request = await this.context.Requests.FindAsync(id);
            if (request != null)
            {
                request.Status = Models.Enums.Status.Finished;
                this.context.Update(request);
               await this.context.SaveChangesAsync();
            }
        }

        public async Task Cancele(string id)
        {
            Request request = await this.context.Requests.FindAsync(id);
            if (request != null)
            {
                request.Status = Models.Enums.Status.Cancele;
                this.context.Update(request);
                await this.context.SaveChangesAsync();
            }
        }

        public async Task<EditRequestByAdminViewModel> GetRequestToEditByAdminAsync(string id)
        {
            Request request = await this.context.Requests.FirstOrDefaultAsync(x => x.Id == id);

            return new EditRequestByAdminViewModel()
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                ExpireDate = request.ExpireDate,
                Budget = request.Budget,
                Category = request.Category,
                Status = request.Status,
                LocationId = request.LocationId,
                HousekeeperId = request.HousekeeperId,
                Housekeeprs = await this.GetHousekeepersSelectListAsync(),
            };
        }

        public async Task<SelectList> GetHousekeepersSelectListAsync()
        {
            List<SelectListHousekeeperViewModel> locations = await this.context.Housekeepers
                .Select(x => new SelectListHousekeeperViewModel()
                {
                    Id = x.Id,
                    FullName = $"{x.User.FirstName} - {x.User.LastName}",
                }).ToListAsync();
            return new SelectList(locations, "Id", "FullName");
        }

        public async Task EditRequestByAdminAsync(EditRequestByAdminViewModel model)
        {
            Request request = await this.context.Requests.FirstOrDefaultAsync(x => x.Id == model.Id);
            request.Name = model.Name;
            request.Description = model.Description;
            request.ExpireDate = model.ExpireDate;
            request.Budget = model.Budget;
            request.Category = model.Category;
            request.LocationId = model.LocationId;
            request.HousekeeperId = model.HousekeeperId;
            request.Status=model.Status;

            this.context.Update(request);
            await this.context.SaveChangesAsync();
        }
    }
}
