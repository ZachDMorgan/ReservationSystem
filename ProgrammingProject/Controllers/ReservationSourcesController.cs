using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingProject.Data;

namespace ProgrammingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationSourcesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ReservationSourcesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("getSources")]
        public async Task<IActionResult> Get()
        {
            var sources = await _context.ReservationSources.ToListAsync();
            return Ok(sources);
        }
    }
}
