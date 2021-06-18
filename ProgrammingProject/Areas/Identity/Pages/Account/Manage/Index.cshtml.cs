using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProgrammingProject.Data;

namespace ProgrammingProject.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            public int Id { get; set; }
            public string FirstName { get; set; }
            public string Surname { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            if(Input == null)
            {
                var userName = await _userManager.GetUserNameAsync(user);
                var p = await _context.People.FirstOrDefaultAsync(p => p.Email == user.Email);

                Username = userName;

                Input = new InputModel
                {
                    Id = p.Id,
                    Email = p.Email,
                    FirstName = p.FirstName,
                    Surname = p.Surname,
                    Phone = p.Phone,
                };
            }
           
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
           
            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var p = await _context.People.FirstOrDefaultAsync(p => p.Id == Input.Id);
            p.FirstName = Input.FirstName;
            p.Surname = Input.Surname;
            p.Phone = Input.Phone;
            await _context.SaveChangesAsync();
            

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
