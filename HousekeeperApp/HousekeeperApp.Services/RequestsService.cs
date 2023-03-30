using HousekeeperApp.Data;
using HousekeeperApp.Models;
using HousekeeperApp.Services.Contracts;
using HousekeeperApp.ViewModels.Requests;
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

        public Task CreateRequestAsync(CreateRequestViewModel model, string userId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<EditRequestViewModel> GetEditRequestByAdminViewModel(string id)
        {
            throw new NotImplementedException();
        }

        public Task<EditRequestViewModel> GetEditRequestByClientViewModel(string id)
        {
            throw new NotImplementedException();
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

        public Task UpdateRequestAsync(EditRequestViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
