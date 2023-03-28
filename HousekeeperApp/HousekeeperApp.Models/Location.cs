namespace HousekeeperApp.Models
{
    using System;

    public class Location
    {
        public Location()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}
