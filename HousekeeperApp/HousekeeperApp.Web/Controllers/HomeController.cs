using HousekeeperApp.Services.Contracts;
using HousekeeperApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HousekeeperApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailSender emailSender;
        public HomeController(ILogger<HomeController> logger, IEmailSender emailSender)
        {
            this.emailSender = emailSender;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<string> SendEmail()
        {

            await this.emailSender.SendEmailAsync("a.alishov@live.com", "Alishov", "alishalishov92@gmail.com", "DemoEmail", "<h1>Имаш поща</h1>");
            await this.emailSender.SendEmailAsync("a.alishov@live.com", "Alishov", "a_alishov@abv.bg", "DemoEmail", "<h1>Имаш поща</h1>");

            return "Email send";
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
