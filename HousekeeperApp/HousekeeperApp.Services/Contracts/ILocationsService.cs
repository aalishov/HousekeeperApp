namespace HousekeeperApp.Services.Contracts
{
    using HousekeeperApp.Models;
    using HousekeeperApp.ViewModels.Locations;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Threading.Tasks;

    public interface ILocationsService
    {
        Task<IndexLocationsViewModel> GetLocationsAsync(IndexLocationsViewModel model, string userId);

        Task<EditLocationViewModel> GetEditLocationViewModel(string id);

        Task<Location> GetLocationByIdAsync(string id);

        Task<SelectList> GetLocationSelectListAsync(string userId);

        Task CreateLocationAsync(CreateLocationViewModel model, string userId);

        Task UpdateLocationAsync(EditLocationViewModel model);

        Task DeleteAsync(string id);
    }
}
