using HousekeeperApp.Common;
using HousekeeperApp.Models;
using HousekeeperApp.Services;
using HousekeeperApp.Services.Contracts;
using HousekeeperApp.ViewModels.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HousekeeperApp.Web.Controllers
{
    public class RequestsController : Controller
    {
        private readonly IRequestsService requestsService;
        private readonly ILocationsService locationsService;

        public RequestsController(IRequestsService service, ILocationsService locationsService)
        {
            this.requestsService = service;
            this.locationsService = locationsService;
        }

        public async Task<IActionResult> Index(IndexRequestsViewModel model)
        {
            string userId = null;
            if (this.User.IsInRole(GlobalConstants.ClientRole))
            {
                userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            model = await this.requestsService.GetIndexRequestsAsync(model, userId);

            return this.View(model);
        }

        // GET: Create
        public async Task<IActionResult> Create()
        {
            CreateRequestViewModel model = new CreateRequestViewModel();
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            model.ExpireDate = System.DateTime.Now;
            model.Locations = await this.locationsService.GetLocationSelectListAsync(userId);
            return this.View(model);
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateRequestViewModel model)
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            model.UserId = userId;
            if (this.ModelState.IsValid)
            {
                await this.requestsService.CreateRequestAsync(model);
                return this.RedirectToAction(nameof(this.Index));
            }

            model.Locations = await this.locationsService.GetLocationSelectListAsync(model.UserId);
            return this.View(model);
        }

        public async Task<IActionResult> Complete(string id)
        {
            await this.requestsService.Complete(id);
            return this.RedirectToAction(nameof(this.Index));
        }

        public async Task<IActionResult> Cancel(string id)
        {
            await this.requestsService.Cancele(id);
            return this.RedirectToAction(nameof(this.Index));
        }

        [HttpGet]
        public async Task<IActionResult> EditByClient(string id)
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            EditRequestViewModel model = await requestsService.GetRequestToEditAsync(id);
            model.Locations = await this.locationsService.GetLocationSelectListAsync(userId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditByClient(EditRequestViewModel model)
        {
            if (ModelState.IsValid)
            {
                await requestsService.EditRequestByClientAsync(model);
                return RedirectToAction(nameof(Index));
            }
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            model.Locations = await this.locationsService.GetLocationSelectListAsync(userId);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditByAdmin(string id)
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            EditRequestByAdminViewModel model = await this.requestsService.GetRequestToEditByAdminAsync(id);
            model.Locations = await this.locationsService.GetLocationSelectListAsync(userId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditByAdmin(EditRequestByAdminViewModel model)
        {
            if (ModelState.IsValid)
            {
                await requestsService.EditRequestByAdminAsync(model);
                return RedirectToAction(nameof(Index));
            }
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            model.Locations = await this.locationsService.GetLocationSelectListAsync(userId);
            model.Housekeeprs = await this.requestsService.GetHousekeepersSelectListAsync();
            return View(model);
        }



        [Authorize(Roles = "Admin,Client")]
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            await requestsService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
