namespace HousekeeperApp.ViewModels.Requests
{
    using HousekeeperApp.Models.Enums;

    public class IndexRequestViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public string ExpireDate { get; set; }

        public string Budget { get; set; }

        public Category Category { get; set; }

        public Status Status { get; set; }

        public string Client { get; set; }

        public string Housekeeper { get; set; }
    }
}
