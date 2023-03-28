namespace HousekeeperApp.Models
{
    using System;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser<string>
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual Housekeeper Housekeeper { get; set; }

        public virtual Client Client { get; set; }
    }
}
