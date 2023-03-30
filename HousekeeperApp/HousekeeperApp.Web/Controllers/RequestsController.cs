using HousekeeperApp.Common;
using HousekeeperApp.Services.Contracts;
using HousekeeperApp.ViewModels.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HousekeeperApp.Web.Controllers
{
    public class RequestsController : Controller
    {
        private readonly IRequestsService service;

        public RequestsController(IRequestsService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index(IndexRequestsViewModel model)
        {
            string userId = null;
            if (this.User.IsInRole(GlobalConstants.ClientRole))
            {
                userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            model = await this.service.GetIndexRequestsAsync(model, userId);

            return View(model);
        }
    }
}
