
namespace HousekeeperApp.ViewModels.Locations
{
    using HousekeeperApp.ViewModels.Shared;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class IndexLocationsViewModel : PagingViewModel
    {
        public ICollection<IndexLocationViewModel> Locations { get; set; } = new List<IndexLocationViewModel>();
    }
}
