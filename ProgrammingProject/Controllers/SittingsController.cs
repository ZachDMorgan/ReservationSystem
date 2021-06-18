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
    public class SittingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public SittingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("getSitting/{sittingId}")]
        public async Task<IActionResult> GetSitting(int sittingId)
        {
            try
            {
                var sitting = await _context.Sittings.FirstOrDefaultAsync(s => s.Id == sittingId);
                if (sitting != null)
                {
                    return Ok(sitting);
                }
                return NotFound();
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpPost]
        [Route("open/{sittingId}")]
        public async Task<IActionResult> OpenSitting(int sittingId)
        {
            try
            {
                var sitting = await _context.Sittings.FirstOrDefaultAsync(s => s.Id == sittingId);
                if (sitting != null)
                {
                    sitting.Open = true;
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
        [Route("close/{sittingId}")]
        public async Task<IActionResult> CloseSitting(int sittingId)
        {
            try
            {
                var sitting = await _context.Sittings.FirstOrDefaultAsync(s => s.Id == sittingId);
                if (sitting != null)
                {
                    sitting.Open = false;
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

        [HttpGet]
        [Route("getGraphData")]
        public IActionResult GetGraphDataAllTime()
        {
            var sittings = _context.Sittings.Include(s => s.Reservations).Include(s => s.SittingType).ToArray();
            var sits = sittings.OrderBy(s => s.StartTime.Ticks);
            var graphData = new List<GraphData>();
            foreach (var sitting in sits)
            {
                int pax = 0;
                foreach (var reservation in sitting.Reservations)
                {
                    pax += reservation.Guests;
                }
                var gd = new GraphData
                {
                    Name = sitting.SittingType.Description,
                    StartTime = sitting.StartTime.ToString(),
                    EndTime = sitting.EndTime.ToString(),
                    Capacity = sitting.Capacity,
                    PAX = pax
                };
                graphData.Add(gd);
            }
            return Ok(graphData);
        }

        class GraphData
        {
            public string Name { get; set; }
            public string StartTime { get; set; }
            public string EndTime { get; set; }
            public int Capacity { get; set; }
            public int PAX { get; set; }
        }

        [HttpGet]
        [Route("getGraphData/{minMonth}/{maxMonth}")]
        public IActionResult GetGraphData(int minMonth, int maxMonth)
        {
            var date = DateTime.Now;
            var minDate = date.AddMonths(minMonth);
            var maxDate = date.AddMonths(maxMonth);
            var sittings = _context.Sittings.Include(s => s.Reservations).Include(s => s.SittingType).Where(s => ((s.StartTime.Month >= minDate.Month) || (s.StartTime.Year > minDate.Year)) && (s.StartTime.Month <= maxDate.Month)).ToArray();
            var sits = sittings.OrderBy(s => s.StartTime.Ticks);
            var graphData = new List<GraphData>();
            foreach (var sitting in sits)
            {
                int pax = 0;
                foreach (var reservation in sitting.Reservations)
                {
                    pax += reservation.Guests;
                }
                var gd = new GraphData
                {
                    Name = sitting.SittingType.Description,
                    StartTime = sitting.StartTime.ToString(),
                    EndTime = sitting.EndTime.ToString(),
                    Capacity = sitting.Capacity,
                    PAX = pax
                };
                graphData.Add(gd);
            }
            return Ok(graphData);
        }
    }
}
