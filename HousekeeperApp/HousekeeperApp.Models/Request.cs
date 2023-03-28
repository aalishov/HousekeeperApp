namespace HousekeeperApp.Models
{
    using System;
    using HousekeeperApp.Models.Enums;

    public class Request
    {
        public Request()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string LocationId { get; set; }

        public virtual Location Location { get; set; }

        public DateTime ExpireDate { get; set; }

        public double Budget { get; set; }

        public Category Category { get; set; }

        public Status Status { get; set; } = Status.Pending;

        public string ClientId { get; set; }

        public virtual Client Client { get; set; }

        public string HousekeeperId { get; set; }

        public virtual Housekeeper Housekeeper { get; set; }
    }
}
