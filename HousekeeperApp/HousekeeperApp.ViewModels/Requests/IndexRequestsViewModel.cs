namespace HousekeeperApp.ViewModels.Requests
{
    using HousekeeperApp.ViewModels.Shared;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class IndexRequestsViewModel : PagingViewModel
    {
        public ICollection<IndexRequestViewModel> Requests { get; set; } = new List<IndexRequestViewModel>();
    }
}
