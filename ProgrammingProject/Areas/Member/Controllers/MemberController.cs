using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingProject.Areas.Member.Controllers
{
    [Area("Member")]
    public class MemberController : Controller
    {
        public MemberController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
