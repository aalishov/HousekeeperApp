using HousekeeperApp.Data;
using HousekeeperApp.Models;
using HousekeeperApp.Services.Contracts;
using HousekeeperApp.ViewModels.Housekeepers;
using HousekeeperApp.ViewModels.Locations;
using HousekeeperApp.ViewModels.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousekeeperApp.Services
{
    public class RequestsService : IRequestsService
    {
        private readonly ApplicationDbContext context;

        public RequestsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task CreateRequestAsync(CreateRequestViewModel model)
        {
            Client client = this.context.Clients.FirstOrDefault(x => x.UserId == model.UserId);

            Request request = new Request()
            {
                Name = model.Name,
                Description = model.Description,
                ExpireDate = model.ExpireDate,
                Budget = model.Budget,
                Category = model.Category,
                LocationId = model.LocationId,
                Client = client,
            };

            await this.context.Requests.AddAsync(request);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            Request request = this.context.Requests.Find(id);
            if (request != null)
            {
                this.context.Requests.Remove(request);
                await this.context.SaveChangesAsync();
            }
        }

        public async Task EditRequestByClientAsync(EditRequestViewModel model)
        {
            Request request = await this.context.Requests.FirstOrDefaultAsync(x => x.Id == model.Id);
            request.Name = model.Name;
            request.Description = model.Description;
            request.ExpireDate = model.ExpireDate;
            request.Budget = model.Budget;
            request.Category = model.Category;
            request.LocationId = model.LocationId;
            this.context.Update(request);
            await this.context.SaveChangesAsync();
        }



        public async Task<EditRequestViewModel> GetRequestToEditAsync(string id)
        {
            Request request = await this.context.Requests.FirstOrDefaultAsync(x => x.Id == id);

            return new EditRequestViewModel()
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                ExpireDate = request.ExpireDate,
                Budget = request.Budget,
                Category = request.Category,
                LocationId = request.LocationId,
            };
        }

        public async Task<IndexRequestsViewModel> GetIndexRequestsAsync(IndexRequestsViewModel model, string userId = null)
        {
            bool isClient = this.context.Clients.Any(x => x.User.Id == userId);

            model.Requests = await this.context.Requests
                .Where(x => userId != null && isClient ? x.Client.User.Id == userId : x.Id != null)
                .Where(x => userId != null && !isClient ? x.Housekeeper.User.Id == userId : x.Id != null)
                .Skip((model.Page - 1) * model.ItemsPerPage)
                .Take(model.ItemsPerPage)
                .Select(x => new IndexRequestViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Status = x.Status,
                    Category = x.Category,
                    ExpireDate = x.ExpireDate > DateTime.Now.AddYears(-150) ? x.ExpireDate.ToShortDateString() : "-",
                    Housekeeper = $"{x.Housekeeper.User.FirstName} {x.Housekeeper.User.LastName}",
                })
                .ToListAsync();

            model.ElementsCount = await this.context.Requests
                .Where(x => userId != null ? x.Client.UserId == userId : x.Id != null).CountAsync();

            return model;
        }

        public async Task<SendForReviewViewModel> GetRequestToReview(string id)
        {
            Request request = await this.context.Requests.FindAsync(id);
            return new SendForReviewViewModel()
            {
                Id = request.Id,
                Name = request.Name,
                Category = request.Category,
                ExpireDate = request.ExpireDate.ToShortDateString(),
                Location = request.Location.Name,
            };
        }

        public Task<Request> GetRequestByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task Complete(string id)
        {
            Request request = await this.context.Requests.FindAsync(id);
            if (request != null)
            {
                request.Status = Models.Enums.Status.Finished;
                this.context.Update(request);
                await this.context.SaveChangesAsync();
            }
        }

        public async Task Cancele(string id)
        {
            Request request = await this.context.Requests.FindAsync(id);
            if (request != null)
            {
                request.Status = Models.Enums.Status.Cancele;
                this.context.Update(request);
                await this.context.SaveChangesAsync();
            }
        }

        public async Task<EditRequestByAdminViewModel> GetRequestToEditByAdminAsync(string id)
        {
            Request request = await this.context.Requests.FirstOrDefaultAsync(x => x.Id == id);

            return new EditRequestByAdminViewModel()
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                ExpireDate = request.ExpireDate,
                Budget = request.Budget,
                Category = request.Category,
                Status = request.Status,
                LocationId = request.LocationId,
                HousekeeperId = request.HousekeeperId,
                Housekeeprs = await this.GetHousekeepersSelectListAsync(),
            };
        }

        public async Task<SelectList> GetHousekeepersSelectListAsync()
        {
            List<SelectListHousekeeperViewModel> locations = await this.context.Housekeepers
                .Select(x => new SelectListHousekeeperViewModel()
                {
                    Id = x.Id,
                    FullName = $"{x.User.FirstName} - {x.User.LastName}",
                }).ToListAsync();
            return new SelectList(locations, "Id", "FullName");
        }

        public async Task<DetailsRequestViewModel> GetRequestDetails(string id)
        {
            Request request = this.context.Requests.Find(id);

            DetailsRequestViewModel model = new DetailsRequestViewModel()
            {
                Name = request.Name,
                Description = string.IsNullOrWhiteSpace(request.Description) ? "=" : request.Description,
                Budget = request.Budget,
                Status = request.Status,
                Category = request.Category,
                ExpireDate = request.ExpireDate.ToShortDateString(),
                FinishDate = request.FinishDate != null ? request.FinishDate.GetValueOrDefault().ToShortDateString() : "-",
                Picture= request.Picture,
            };
            model.Client = $"{request.Client.User.FirstName} {request.Client.User.LastName}";
            model.Housekeeper = request.Housekeeper != null ? $"{request.Housekeeper.User.FirstName} {request.Housekeeper.User.LastName}" : "-";

            return model;
        }

        public async Task EditRequestByAdminAsync(EditRequestByAdminViewModel model)
        {
            Request request = await this.context.Requests.FirstOrDefaultAsync(x => x.Id == model.Id);
            request.Name = model.Name;
            request.Description = model.Description;
            request.ExpireDate = model.ExpireDate;
            request.Budget = model.Budget;
            request.Category = model.Category;
            request.LocationId = model.LocationId;
            request.HousekeeperId = model.HousekeeperId;
            request.Status = model.Status;

            this.context.Update(request);
            await this.context.SaveChangesAsync();
        }

        public async Task SendForRequestAsync(SendForReviewViewModel model)
        {
            Request request = this.context.Requests.Find(model.Id);

            request.Picture = await this.ImageToStringAsync(model.PictureFile);
            request.FinishDate = DateTime.UtcNow;
            request.Status = Models.Enums.Status.Review;

            this.context.Update(request);
            await this.context.SaveChangesAsync();
        }


        private async Task<string> ImageToStringAsync(IFormFile file)
        {
            List<string> imageExtensions = new List<string>() { ".JPG", ".BMP", ".PNG" };


            if (file != null) // check if the user uploded something
            {
                var extension = Path.GetExtension(file.FileName); //get file extension
                if (imageExtensions.Contains(extension.ToUpperInvariant()))
                {
                    using var dataStream = new MemoryStream();
                    await file.CopyToAsync(dataStream);
                    byte[] imageBytes = dataStream.ToArray();
                    string base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
            return null;
        }
    }
}
