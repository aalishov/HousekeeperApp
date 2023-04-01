using HousekeeperApp.Models;
using HousekeeperApp.ViewModels.Locations;
using HousekeeperApp.ViewModels.Requests;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HousekeeperApp.Services.Contracts
{
    public interface IRequestsService
    {
        Task<IndexRequestsViewModel> GetIndexRequestsAsync(IndexRequestsViewModel model, string userId = null);

        public Task<Request> GetRequestByIdAsync(string id);

        Task CreateRequestAsync(CreateRequestViewModel model);

        Task Complete(string id);

        Task Cancele(string id);

        Task DeleteAsync(string id);

        Task<EditRequestViewModel> GetRequestToEditAsync(string id);
        Task<SelectList> GetHousekeepersSelectListAsync();


        Task EditRequestByClientAsync(EditRequestViewModel model);

        Task<EditRequestByAdminViewModel> GetRequestToEditByAdminAsync(string id);
        Task EditRequestByAdminAsync(EditRequestByAdminViewModel model);
    }
}
