using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LocalizationDemo.Models;
using Microsoft.Extensions.Localization;

namespace LocalizationDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<ErrorMessagesSharedRources> _sharedResourceLocalizer;
        private readonly IStringLocalizer<HomeController> _localizer;
    

        public HomeController(ILogger<HomeController> logger,
            IStringLocalizer<ErrorMessagesSharedRources> sharedResourceLocalizer,
            IStringLocalizer<HomeController> localizer)
        {
            _logger = logger;
            _sharedResourceLocalizer = sharedResourceLocalizer;
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            ViewData["Slogan"] = _localizer["Slogan"];
            ViewData["ErrorMessage"] = _sharedResourceLocalizer["ERR_001"];
            
            EmployeeViewModel model = new EmployeeViewModel
            {
                FirstName = "Rivaansh",
                LastName = "Bhatt",
                Salary = 100000,
                DOB = new DateTime(2020, 05, 17)
            };
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
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
