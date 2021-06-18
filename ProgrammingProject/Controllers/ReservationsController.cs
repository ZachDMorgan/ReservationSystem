using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingProject.Data;


namespace ProgrammingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public ReservationsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("getDates/{Pax}")]
        public async Task<IActionResult> GetDates(int Pax)
        {
            //should be logic to see where PAX fits into sittings
            var sittings = await _context.Sittings.Where(s => (s.Open == true) && (s.StartTime >= DateTime.Now)).ToListAsync();
            var allAvailableDates = new List<DateTime>();
            var s = new SeatingStrategy();
            foreach (var sitting in sittings)
            {
                if (s.SittingAvailablies(_context, sitting.Id, Pax) >= 0)
                {
                    allAvailableDates.Add(sitting.StartTime.Date);
                    allAvailableDates.Add(sitting.EndTime.Date);
                }
            }
            var availableDates = allAvailableDates.Distinct().OrderBy(d => d.Date).ToList();

            return Ok(availableDates);
        }

        [HttpGet]
        [Route("getTimes/{date}")]
        public async Task<IActionResult> GetTimes(DateTime date)
        {
            //should be logic to see where PAX fits into sittings
            var sittings = await _context.Sittings.Where(s => ((s.StartTime.Date == date.Date) && (s.Open == true)) || (s.EndTime.Date == date.Date) && (s.Open == true)).ToListAsync();
            var allAvailableTimes = new List<DateTime>();
            foreach (var sitting in sittings)
            {

                for (DateTime i = sitting.StartTime; i < sitting.EndTime.AddMinutes(-15); i = i.AddMinutes(15))
                {
                    if (i.Date == date.Date) allAvailableTimes.Add(i);
                }
            }
            var availableDates = allAvailableTimes.Distinct().OrderBy(d => d.TimeOfDay).ToList();

            return Ok(availableDates);
        }

        [HttpGet]
        [Route("getStatus/{id}")]
        public async Task<IActionResult> GetStatus(int id)
        {
            var statuses = await _context.ReservationStatuses.ToListAsync();
            var reservation = await _context.Reservations.Include(rt => rt.ReservationTables).ThenInclude(t => t.Table).FirstOrDefaultAsync(r => r.Id == id);
            if (reservation == null) { return NotFound(); }
            if (reservation.ReservationTables.Count > 0)
            {
                return Ok(statuses);
            }
            else
            {
                var seated = statuses.FirstOrDefault(s => s.Description == "Seated");
                var completed = statuses.FirstOrDefault(s => s.Description == "Completed");
                statuses.RemoveAll(s => s == seated);
                statuses.RemoveAll(s => s == completed);
                return Ok(statuses);
            }
        }

        [HttpGet]
        [Route("getTables/{id}")]
        public async Task<IActionResult> GetTables(int id)
        {
            var reservation = await _context.Reservations.Include(rt => rt.ReservationTables).ThenInclude(t => t.Table).FirstOrDefaultAsync(r => r.Id == id);
            //var sittingReservations = await _context.Reservations.Include(rt => rt.ReservationTables).ThenInclude(t => t.Table).Where(r => r.SittingId == reservation.SittingId).ToListAsync();
            var tables = new List<Table>();
            if (reservation.ReservationTables.Count == 0)
            {
                tables = await _context.Tables.Where(t => t.Active == true).ToListAsync();
            }
            else
            {   // contrain available tables to same area
                tables = await _context.Tables.Where(t => (t.Active == true) && (t.AreaId == reservation.ReservationTables[0].Table.AreaId)).ToListAsync();
                foreach (var table in reservation.ReservationTables)
                {
                    tables.Remove(table.Table);
                }
            }
            if (tables == null) { return NotFound(); }
            return Ok(tables);

        }
    }
}
