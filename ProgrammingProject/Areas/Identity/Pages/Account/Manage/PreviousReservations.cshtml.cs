using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using ProgrammingProject.Data;
using Microsoft.EntityFrameworkCore;

namespace ProgrammingProject.Areas.Identity.Pages.Account.Manage
{
    public partial class PreviousReservationsModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public PreviousReservationsModel(
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        public class PreviousReservationModel
        {
            public DateTime StartTime { get; set; }
            public int Duration { get; set; }
            public int Guests { get; set; }
            public string Notes { get; set; }
            public ReservationStatus ReservationStatus { get; set; }
            public List<Table> Tables { get; set; }
        }


        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            var reservations = await _context.Reservations.Include(r => r.Person).Where(u => u.Person.Email == user.Email).Include(r => r.ReservationStatus).Include(r => r.ReservationTables).ThenInclude(r => r.Table).ToListAsync();
            var input = new List<PreviousReservationModel>();
            foreach (var reservation in reservations)
            {
                var tables = new List<Table>();
                foreach (var table in reservation.ReservationTables)
                {
                    tables.Add(table.Table);
                }
                input.Add(new PreviousReservationModel
                {
                    StartTime = reservation.StartTime,
                    Duration = reservation.Duration,
                    Guests = reservation.Guests,
                    Notes = reservation.Notes,
                    ReservationStatus = reservation.ReservationStatus,
                    Tables = tables
                });
            }
            input.Sort((x, y) => DateTime.Compare(x.StartTime, y.StartTime));
            ViewData["PreviousReservations"] = input;
            return Page();
        }
    }
}
