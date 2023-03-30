using HousekeeperApp.Models;
using HousekeeperApp.ViewModels.Locations;
using System.Threading.Tasks;

namespace HousekeeperApp.Services.Contracts
{
    public interface ILocationsService
    {
        public Task<IndexLocationsViewModel> GetLocationsAsync(IndexLocationsViewModel model, string userId);

        public Task<EditLocationViewModel> GetEditLocationViewModel(string id);

        public Task<Location> GetLocationByIdAsync(string id);

        Task CreateLocationAsync(CreateLocationViewModel model, string userId);

        Task UpdateLocationAsync(EditLocationViewModel model);

        Task DeleteAsync(string id);
    }
}
