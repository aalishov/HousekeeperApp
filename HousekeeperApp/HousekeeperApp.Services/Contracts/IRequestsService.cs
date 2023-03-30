using HousekeeperApp.Models;
using HousekeeperApp.ViewModels.Locations;
using HousekeeperApp.ViewModels.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HousekeeperApp.Services.Contracts
{
    public interface IRequestsService
    {
        Task<IndexRequestsViewModel> GetIndexRequestsAsync(IndexRequestsViewModel model, string userId = null);

        public Task<EditRequestViewModel> GetEditRequestByClientViewModel(string id);

        public Task<EditRequestViewModel> GetEditRequestByAdminViewModel(string id);

        public Task<Request> GetRequestByIdAsync(string id);

        Task CreateRequestAsync(CreateRequestViewModel model, string userId);

        Task UpdateRequestAsync(EditRequestViewModel model);

        Task DeleteAsync(string id);
    }
}
