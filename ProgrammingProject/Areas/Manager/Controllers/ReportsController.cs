using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingProject.Data;

namespace ProgrammingProject.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Graphs()
        {
            return View();
        }

        //GET: Manager/Reports/ReservationsReport
        public async Task<IActionResult> ReservationsReport()
        {
            var applicationDbContext = _context.Reservations.OrderByDescending(d => d.StartTime).Include(r => r.Person).Include(r => r.ReservationSource).Include(r => r.ReservationStatus).Include(r => r.Sitting).Include(r => r.ReservationTables).ThenInclude(r => r.Table);
            return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult ReservationsReportWeek()
        {
            var wc = DateTime.Today.AddDays(-1 * ((7 + (DateTime.Today.DayOfWeek - DayOfWeek.Sunday)) % 7)).Date;
            var we = wc.AddDays(7);

            var reservationsByWeek = _context.Reservations
                                    .Where(r => r.StartTime.Date >= wc && r.StartTime.Date < we)
                                    .ToArray();
            int[] count = new int[7]; 

            foreach(var g in reservationsByWeek.GroupBy(r => r.StartTime.DayOfWeek).OrderBy(g => (int)g.Key))
            {
                count[(int)g.Key] = g.Count(); 
            }

            ViewBag.Data = count; 
            return View();
        }

        public IActionResult ReservationsReportMonth()
        {
            //var mc = DateTime.Today.AddMonths(1 - DateTime.Today.Month);
            var reservationsByMonth = _context.Reservations.Select(r => r.StartTime.Date).ToArray();
                                    
            int[] count = new int[12];

            foreach (var g in reservationsByMonth.GroupBy(r => r.Month - 1).OrderBy(g => g.Key))
            {
                count[g.Key] = g.Count();
            }

            ViewBag.Data = count;
            return View();
        }
    }
}