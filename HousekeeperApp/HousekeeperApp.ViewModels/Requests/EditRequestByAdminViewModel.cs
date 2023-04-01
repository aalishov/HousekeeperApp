using HousekeeperApp.Models.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousekeeperApp.ViewModels.Requests
{
    public class EditRequestByAdminViewModel : EditRequestViewModel
    {
        public Status Status { get; set; }

        public string HousekeeperId { get; set; }

        public SelectList Housekeeprs { get; set; }
    }
}
