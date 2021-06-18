using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingProject.Data;

namespace ProgrammingProject.Areas.Manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TablesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("getTable/{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var table = await _context.Tables.FirstOrDefaultAsync(t => t.Id == Id);
            var tableModel = new Manager.Models.Table.Table
            {
                Name = table.Name,
                Seats = table.Seats,
                AreaId = table.AreaId
            };
            return Ok(tableModel);
        }
    }
}
