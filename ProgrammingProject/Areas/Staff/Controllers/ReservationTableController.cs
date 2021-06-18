using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProgrammingProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingProject.Areas.Staff.Controllers
{
    [Area("Staff")]
    public class ReservationTableController : StaffBaseController
    {
        
        public ReservationTableController(ApplicationDbContext context, UserManager<ApplicationUser> userManager) : base(context, userManager)
        {

        }
        public async Task<IActionResult> Index()
        {
            var reservations = await _context.Reservations
                .Include(r => r.ReservationTables)
                    .ThenInclude(rt => rt.Table)
                .Include(r => r.Person)
                    .ToListAsync();
            return View(reservations);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            var res = await _context.Reservations.FindAsync(id);


            var r = new Models.ReservationTable.Create
            {
                ReservationId = res.Id,
                Tables = new SelectList(await _context.Tables.OrderBy(Table=> Table.Name).ToListAsync(), "Id", "Name")
            };
            return View(r);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Models.ReservationTable.Create r)
        {
            if (ModelState.IsValid)
            {


                var assignTable = new ReservationTable
                {
                    ReservationId = r.ReservationId,
                    TableId = r.TableId

                };
                _context.ReservationTables.Add(assignTable);
                await _context.SaveChangesAsync();
                return RedirectToAction("Update", "Reservation", new { id = r.SittingId, Area = "Staff" });

            }
            r.Tables = new SelectList(await _context.Areas.ToListAsync(), "Id", "Name", r.TableId);


            return View(r);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var table = await _context.ReservationTables.Include(t => t.Table).FirstAsync(t => t.ReservationId == id);
            if (table == null) { return NotFound(); }
            var t = new Models.ReservationTable.Delete
            {
                Id = table.Id,
                ReservationId = table.ReservationId,
                TableId = table.TableId,
                Tables = table.Table.Name

            };

            return View(t);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Models.ReservationTable.Delete d)
        {
            try
            {
                var reservationTable = await _context.ReservationTables.FirstOrDefaultAsync(t => (t.ReservationId == d.ReservationId) && (t.TableId == d.TableId));
                if (reservationTable == null) { return NotFound(); }
                _context.ReservationTables.Remove(reservationTable);
                await _context.SaveChangesAsync();
                return RedirectToAction("Update", "Reservation", new { id = d.SittingId, Area = "Staff" });
            }
            catch (Exception)
            {

                ModelState.AddModelError("Exception", "sth is wrong");
            }
            return View(d);
        }
    }
}
