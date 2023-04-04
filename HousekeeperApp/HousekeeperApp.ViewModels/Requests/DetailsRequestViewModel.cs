using HousekeeperApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace HousekeeperApp.ViewModels.Requests
{
    public class DetailsRequestViewModel
    {
        public string Name { get; set; }

        public string Client { get; set; }

        public string Housekeeper { get; set; }

        public string Description { get; set; }

        public string Location{ get; set; }

        [Display(Name = "Expire date")]
        public string ExpireDate { get; set; }

        [Display(Name = "Finish date")]
        public string FinishDate { get; set; }

        public double Budget { get; set; }

        public Category Category { get; set; }

        public Status Status { get; set; }

        public string Picture { get; set; }
    }
}
