﻿using HousekeeperApp.Models.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace HousekeeperApp.ViewModels.Requests
{
    public class EditRequestViewModel
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string LocationId { get; set; }

        [Display(Name = "Expire date")]
        public DateTime ExpireDate { get; set; }

        public double Budget { get; set; }

        public Category Category { get; set; }

        public SelectList Locations { get; set; }

    }
}