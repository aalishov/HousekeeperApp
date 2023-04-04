using HousekeeperApp.Services.Contracts;
using HousekeeperApp.ViewModels.Locations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HousekeeperApp.Web.Controllers
{
    [Authorize(Roles = ("Admin,Client"))]
    public class LocationsController : Controller
    {
        private readonly ILocationsService service;

        public LocationsController(ILocationsService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index(IndexLocationsViewModel model)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            model = await this.service.GetLocationsAsync(model, userId);

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Requests/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateLocationViewModel model)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            if (ModelState.IsValid && userId != null)
            {
                await service.CreateLocationAsync(model, userId);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            EditLocationViewModel model = await service.GetEditLocationViewModel(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditLocationViewModel model)
        {
            if (ModelState.IsValid)
            {
                await service.UpdateLocationAsync(model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            await service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
