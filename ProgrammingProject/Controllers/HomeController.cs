using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProgrammingProject.Models;

namespace ProgrammingProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Menu()
        {
            return View();
        }
        

        public IActionResult About()
        {
            return View();
        }
        

        public IActionResult Contact()
        {
            return View();
        }
        

        public IActionResult WhatsOn()
        {
            return View();
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
        public IActionResult RedirectUser()
        {
            if(User == null) { return RedirectToAction("Privacy", "Home"); }
            if (User.IsInRole("Manager")) return RedirectToAction("Index", "Home", new { area = "Manager" });
            if (User.IsInRole("Staff")) return RedirectToAction("Index", "Reservation", new { area = "Staff" });
            return RedirectToAction("Index", "Home");
        }
    }
}
