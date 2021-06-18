using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProgrammingProject.Data;
using ProgrammingProject.Models;

using System.Threading.Tasks;

namespace ProgrammingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public RolesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("add/{userId}/{role}")]
        public async Task<IActionResult> AddUserToRole(string userId,string role)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if(! await _userManager.IsInRoleAsync(user,role))
                {
                    await _userManager.AddToRoleAsync(user, role); 
                }
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }


        [HttpPost]
        [Route("remove/{userId}/{role}")]
        public async Task<IActionResult> RemoveUserFromRole(string userId, string role)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (await _userManager.IsInRoleAsync(user, role))
                {
                    await _userManager.RemoveFromRoleAsync(user, role);
                }
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }
    }
}
