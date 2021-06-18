using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ProgrammingProject.Data;

namespace ProgrammingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public TokenController(IConfiguration config, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _configuration = config;
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public class UserJWTCredentials
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserJWTCredentials u)
        {

            if (u != null && u.Email != null && u.Password != null)
            {
                var result = await _signInManager.PasswordSignInAsync(u.Email, u.Password, true, false);


                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(u.Email);
                    var claims = new List<Claim>();
                    claims.Add(new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]));
                    claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                    claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()));
                    claims.Add(new Claim("Id", user.Id.ToString()));
                    claims.Add(new Claim("UserName", user.UserName));
                    claims.Add(new Claim("Email", user.Email));
                    foreach (var r in await _userManager.GetRolesAsync(user))
                    {
                        claims.Add(new Claim("role", r));
                    }
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);
                    var thingo = new JwtSecurityTokenHandler().WriteToken(token);
                    return Ok(thingo.ToString());
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }


    }
}
