using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProgrammingProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingProject.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class HomeController : ManagerBaseController
    {
        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager) : base(context, userManager)
        {

        }
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
