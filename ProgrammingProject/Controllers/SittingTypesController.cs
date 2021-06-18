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
    public class SittingTypesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public SittingTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("getSittingTypes")]
        public async Task<IActionResult> GetSittingTypes()
        {
            var sources = await _context.SittingTypes.Where(s => s.Active == true).ToListAsync();
            return Ok(sources);
        }

        [HttpGet]
        [Route("getAllSittingTypes")]
        public async Task<IActionResult> GetAllSittingTypes()
        {
            var sources = await _context.SittingTypes.ToListAsync();
            return Ok(sources);
        }

        [HttpGet]
        [Route("getDeletableSittingTypes")]
        public async Task<IActionResult> GetDeletableSittingTypes()
        {
            var sittings = await _context.Sittings.Include(r => r.SittingType).Include(r => r.Reservations).ToListAsync();
            var sources = await _context.SittingTypes.ToListAsync();
            foreach (var sitting in sittings)
            {
                if(sitting.Reservations.Count > 0)
                {
                    sources.Remove(sitting.SittingType);
                }
                
            }
            return Ok(sources);
        }

        [HttpPost]
        [Route("activate/{sittingTypeId}")]
        public async Task<IActionResult> ActivateSittingType(int sittingTypeId)
        {
            try
            {
                var sittingType = await _context.SittingTypes.FirstOrDefaultAsync(s => s.Id == sittingTypeId);
                if (sittingType != null)
                {
                    sittingType.Active = true;
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                return NotFound();

            }
            catch
            {
                return NotFound();
            }

        }


        [HttpPost]
        [Route("deactivate/{sittingTypeId}")]
        public async Task<IActionResult> DeactivateSittingType(int sittingTypeId)
        {
            try
            {
                var sittingType = await _context.SittingTypes.FirstOrDefaultAsync(s => s.Id == sittingTypeId);
                if (sittingType != null)
                {
                    sittingType.Active = false;
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                return NotFound();

            }
            catch
            {
                return NotFound();
            }

        }

    }
}

