using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProgrammingProject.Data;
using ProgrammingProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingProject.Controllers
{
	[Area("Manager"), Authorize(Roles = "Manager")]
	public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
		private readonly ILogger<AdminController> _logger;
		private readonly SignInManager<ApplicationUser> _signInManager;
		protected readonly ApplicationDbContext _context;

		public AdminController(
                UserManager<ApplicationUser> userManager,
                RoleManager<IdentityRole> roleManager,
				ILogger<AdminController> logger,
				SignInManager<ApplicationUser> signInManager,
				ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
			_logger = logger;
			_signInManager = signInManager;
			_context = context;
		}

		public IActionResult StaffList()
		{
			ViewBag.UserManager = _userManager; 
			return View();
		}

		public IActionResult MemberList()
		{
			ViewBag.UserManager = _userManager;
			return View();
		}

		public async Task<IActionResult> EditStaff(string id)
		{
			var viewModel = new Person();
			if (!string.IsNullOrWhiteSpace(id))
			{
				var user = await _userManager.FindByIdAsync(id);
                var userRoles = await _userManager.GetRolesAsync(user);
                var p = await _context.People.FirstOrDefaultAsync(p => p.Email == user.Email);

				viewModel.FirstName = p?.FirstName;
				viewModel.Surname = p?.Surname;
				viewModel.Phone = p?.Phone;
				viewModel.Email = p?.Email;

				var allRoles = await _roleManager.Roles.ToListAsync();

				
				viewModel.Roles = allRoles.Select(x => new RoleViewModel()
				{
					Id = x.Id,
					Name = x.Name,
					Selected = userRoles.Contains(x.Name),
				}).ToArray();

			}

			return View(viewModel);
		}

		public async Task<IActionResult> EditMember(string id)
		{
			var viewModel = new Person();
			if (!string.IsNullOrWhiteSpace(id))
			{
				var user = await _userManager.FindByIdAsync(id);
				var userRoles = await _userManager.GetRolesAsync(user);
				var p = await _context.People.FirstOrDefaultAsync(p => p.Email == user.Email);

				viewModel.FirstName = p?.FirstName;
				viewModel.Surname = p?.Surname;
				viewModel.Phone = p?.Phone;
				viewModel.Email = p?.Email;

				var allRoles = await _roleManager.Roles.ToListAsync();


				viewModel.Roles = allRoles.Select(x => new RoleViewModel()
				{
					Id = x.Id,
					Name = x.Name,
					Selected = userRoles.Contains(x.Name),
				}).ToArray();

			}

			return View(viewModel);
		}

		[HttpPost]
		public async Task<IActionResult> EditUser(UserViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var user = await _userManager.FindByIdAsync(viewModel.Id);
				var userRoles = await _userManager.GetRolesAsync(user);

				//await _userManager.RemoveFromRolesAsync(user, userRoles);
				//await _userManager.AddToRolesAsync(user, viewModel.Roles.Where(x => x.Selected).Select(x => x.Name));

				return RedirectToAction(nameof(StaffList));
			}

			return View(viewModel);
		}
		
		[HttpGet]
		public IActionResult CreateStaff()
        {
			return View();
        }
		[HttpPost]
		public async Task<IActionResult> CreateStaff(RegisterViewModel model)
		{
			if (ModelState.IsValid)
            {
				var uniqueUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
				if(uniqueUser!= null) {
					ModelState.AddModelError("UniqueEmail", "Email is not unique. Use another one");
					return View(model);
				}
				var user = new ApplicationUser 
				{ 
					UserName = model.Email, 
					Email = model.Email 
				};

				var result = await _userManager.CreateAsync(user, model.Password);
				await _userManager.AddToRoleAsync(user, "Staff");

				if (result.Succeeded)
                {
					var createdUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
					await _userManager.AddToRoleAsync(createdUser, "Staff");
					if (_signInManager.IsSignedIn(User) && User.IsInRole("Manager"))
                    {
						return RedirectToAction("StaffList", "Admin");
                    }

					await _signInManager.SignInAsync(user, isPersistent: false);
					return RedirectToAction("index", "home");
                }

				foreach(var error in result.Errors) 
				{
					ModelState.AddModelError("", error.Description);
				}
            }

			return View(model);
		}


        public async Task<IActionResult> DeleteUser(string id)
        {
			var user = await _userManager.FindByIdAsync(id);

			if (user == null)
            {
				ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
				return View("NotFound");
            }
			else
            {
				var result = await _userManager.DeleteAsync(user);

				if (result.Succeeded)
                {
					return RedirectToAction("StaffList");
                }

				foreach (var error in result.Errors)
                {
					ModelState.AddModelError("", error.Description);
                }

				return View("StaffList");
            }
        }
	}
}