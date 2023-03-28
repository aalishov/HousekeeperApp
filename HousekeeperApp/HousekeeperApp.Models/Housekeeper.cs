namespace HousekeeperApp.Models
{
    using System;
    using System.Collections.Generic;

    public class Housekeeper
    {
        public Housekeeper()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
    }
}
