using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProgrammingProject.Data;

namespace ProgrammingProject.Areas.Staff.Controllers
{
    public class HomeController : StaffBaseController
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
