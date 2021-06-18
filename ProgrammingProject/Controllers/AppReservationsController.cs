using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingProject.Data;

namespace ProgrammingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Roles = "Member")]
    public class AppReservationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public AppReservationsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetReservations()
        {
            var email = User.Claims.FirstOrDefault(c => c.Type == "Email").Value;
            if (email == null) { return NotFound(); }
            var person = await _context.People.FirstOrDefaultAsync(r => (r.Email == email) && (r.Verified == true));
            if (person == null) { return NotFound(); }
            var res = await _context.Reservations.Include(p => p.Person).Include(rs => rs.Sitting).ThenInclude(st => st.SittingType).Include(rt => rt.ReservationTables).ThenInclude(t => t.Table).Include(rs => rs.ReservationStatus).Where(rp => (rp.Person.Email == email) && (rp.Person.Verified == true)).ToListAsync();
            if (res != null)
            {
                var reservations = new List<Object>();
                foreach (var r in res)
                {
                    var tables = new List<string>();
                    foreach (var rt in r.ReservationTables)
                    {
                        tables.Add(rt.Table.Name);
                    }

                    reservations.Add(new
                    {
                        r.Id,
                        Sitting = r.Sitting.SittingType.Description,
                        ReservationStatus = r.ReservationStatus.Description,
                        StartTime = r.StartTime.ToString(),
                        r.Duration,
                        r.Guests,
                        r.Notes,
                        Tables = tables
                    });
                }
                return Ok(reservations);
            }
            return Ok();

        }

        [HttpGet]
        [Route("getName")]
        public async Task<IActionResult> GetName()
        {
            var email = User.Claims.FirstOrDefault(c => c.Type == "Email").Value;
            if (email == null) { return NotFound(); }
            var person = await _context.People.FirstOrDefaultAsync(r => (r.Email == email) && (r.Verified == true));
            if (person == null) { return NotFound(); }
            return Ok(person.FirstName);
        }

        [HttpGet]
        [Route("checkValid")]
        public IActionResult CheckValid()
        {
            return Ok(true);
        }

        [HttpPost]
        public async Task<IActionResult> MakeReservation(CustomerReservation r)
        {
            if (ModelState.IsValid)
            {
                var email = User.Claims.FirstOrDefault(c => c.Type == "Email").Value;
                if (email == null) { return NotFound(); }
                var person = await _context.People.FirstOrDefaultAsync(r => (r.Email == email) && (r.Verified == true));
                if (person == null) { return NotFound(); }
                try
                {
                    var startTime = DateTime.Parse(r.StartTime);
                    //find the correct sitting to assign to
                    var sittingId = _context.Sittings.FirstOrDefault(t => t.StartTime <= startTime && t.EndTime > startTime).Id;
                    //cast to reservation object
                    var reservation = new Reservation
                    {
                        PersonId = person.Id,
                        SittingId = sittingId,
                        ReservationSourceId = 5,
                        ReservationStatusId = 1,
                        StartTime = startTime,
                        Duration = 90,
                        Guests = int.Parse(r.Guests),
                        Notes = r.Notes
                    };
                    //send to db
                    _context.Reservations.Add(reservation);
                    _context.SaveChanges();
                    return Ok(true);
                }
                catch (Exception e)
                {
                    return Ok(false);
                }
            }
            return Ok(false);

        }

        public class CustomerReservation
        {
            public string StartTime { get; set; }
            public string Guests { get; set; }
            public string Notes { get; set; }
        }
    }
}
