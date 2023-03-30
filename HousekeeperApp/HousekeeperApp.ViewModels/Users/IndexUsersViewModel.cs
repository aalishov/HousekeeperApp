namespace HousekeeperApp.ViewModels.Users
{
    using ViewModels.Shared;
    using System.Collections.Generic;
    public class IndexUsersViewModel:PagingViewModel
    {
        public ICollection<IndexUserViewModel> Users { get; set; }
    }
}
