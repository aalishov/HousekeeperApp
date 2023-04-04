using HousekeeperApp.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HousekeeperApp.ViewModels.Requests
{
    public class SendForReviewViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }


        [Display(Name = "Expire date")]
        public string ExpireDate { get; set; }

        public Category Category { get; set; }

        public string Picture { get; set; }

        [BindProperty]
        [Required]
        public IFormFile PictureFile { get; set; }
    }
}
