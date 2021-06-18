using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProgrammingProject.Areas.Staff.Models.Reservation;
using ProgrammingProject.Data;

namespace ProgrammingProject.Areas.Staff.Controllers
{
    //t42.azurewebsites.net
    //U: m@e.com
    //P: m123!@#
    [Area("Staff")]
    public class ReservationController : StaffBaseController
    {
        public ReservationController(ApplicationDbContext context, UserManager<ApplicationUser> userManager) : base(context, userManager)
        {

        }
        public async Task<IActionResult> Index()
        {
            //get list of all sittings and send to view - 
            var sittings = await _context.Sittings.Where(s => s.EndTime.Date >= DateTime.Now.Date).Include(s => s.SittingType).OrderBy(s => s.StartTime).ToListAsync();
            var index = new List<Models.Reservation.Sitting>();
            foreach (var s in sittings)
            {
                var reservation = await _context.Reservations.Where(r => r.SittingId == s.Id).ToListAsync();
                int pax = 0;
                foreach (var r in reservation)
                {
                    pax += r.Guests;
                }
                bool reservationFound = (reservation.Count == 0) ? false : true;
                var sitting = new Models.Reservation.Sitting
                {
                    Id =s.Id,
                    SittingTypeId = s.SittingTypeId,
                    SittingType = s.SittingType,
                    StartTime = s.StartTime,
                    EndTime = s.EndTime,
                    Capacity = s.Capacity,
                    Open = s.Open,
                    AreThereReservations = reservationFound,
                    Pax = pax
                };
                index.Add(sitting);
            }
            return View(index);
        }
        //[HttpGet]
        //public async Task<IActionResult> Create(int id)
        //{
        //    //get the chosen sitting from the database - maybe could get it from last view to stop another trip to DB
        //    var sitting = await _context.Sittings.FirstOrDefaultAsync(s => s.Id == id);
        //    //get available times
        //    var times = new List<DateTime>();
        //    for (DateTime i = sitting.StartTime; i < sitting.EndTime.AddMinutes(-15); i = i.AddMinutes(15))
        //    {
        //        times.Add(i);
        //    }

        //    var possibleReservation = new Create
        //    {
        //        SittingId = sitting.Id,
        //        AvailableTimes = new SelectList(times),
        //        Sources = new SelectList(await _context.ReservationSources.ToListAsync(), "Id", "Description")
        //    };
        //    return View(possibleReservation);


        //}
        [HttpPost]
        public async Task<IActionResult> Create(Models.Reservation.Create s)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //check if they have an entry in the db
                    var person = await _context.People.FirstOrDefaultAsync(p => (p.Email == s.Email) && (p.FirstName == s.FirstName) && (p.Surname == s.Surname) && (p.Phone == s.Phone));
                    if (person == null)
                    {   //new person 
                        person = new Person
                        {
                            Email = s.Email,
                            FirstName = s.FirstName,
                            Surname = s.Surname,
                            Phone = s.Phone
                        };
                        _context.People.Add(person);
                        _context.SaveChanges();
                    }



                    //cast to reservation object
                    var reservation = new Reservation
                    {
                        PersonId = person.Id,
                        SittingId = _context.Sittings.FirstOrDefault(t => t.StartTime <= s.StartTime && t.EndTime > s.StartTime).Id,
                        ReservationSourceId = s.SourceId,
                        ReservationStatusId = 1,
                        StartTime = s.StartTime,
                        Duration = s.Duration,
                        Guests = s.Guests,
                        Notes = s.Notes
                    };
                    //send to db
                    _context.Reservations.Add(reservation);
                    _context.SaveChanges();
                    //redirect to success page
                    return RedirectToAction("Update", "Reservation", new { area = "Staff", id = reservation.SittingId});
                }
                catch (Exception)
                {
                    ModelState.AddModelError("Exception", "Oops, there was an error");
                }

            }
            //on fail send back to this page.

            //need to build up selectList
            var sitting = await _context.Sittings.FirstOrDefaultAsync(i => i.Id == s.SittingId);
            var times = new List<DateTime>();
            for (DateTime i = sitting.StartTime; i < sitting.EndTime.AddMinutes(-15); i = i.AddMinutes(15))
            {
                times.Add(i);
            }
            s.AvailableTimes = new SelectList(times);
            s.Sources = new SelectList(await _context.ReservationSources.ToListAsync(), "Id", "Description");
            //send to current page with error message
            return View(s);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            //get all the reservations for the chosen sitting
            var reservations = await _context.Reservations.Where(r => r.SittingId == id).Include(r => r.ReservationTables).ThenInclude(rt => rt.Table).Include(r => r.Person).Include(rs => rs.ReservationStatus).ToListAsync();

            
            

            //cast to model
            var reservationsUpdateModel = new List<Update>();
            foreach (var r in reservations)
            {
                var updateTables = new List<Table>();
                foreach (var rt in r.ReservationTables)
                {
                    updateTables.Add(rt.Table);
                }
                var update = new Update
                {
                    Id = r.Id,
                    SittingId = r.SittingId,
                    FirstName = r.Person.FirstName,
                    Surname = r.Person.Surname,
                    Phone = r.Person.Phone,
                    Email = r.Person.Email,
                    StartTime = r.StartTime,
                    Duration = r.Duration,
                    Guests = r.Guests,
                    Notes = r.Notes,
                    StatusId = r.ReservationStatusId,
                    ReservationStatus = r.ReservationStatus,
                    Tables = updateTables
                };
                
                reservationsUpdateModel.Add(update);
            }

            return View(reservationsUpdateModel);


        }

        [HttpGet]
        public async Task<IActionResult> UpdateStatus(int id)
        {   //build up model again from chosen reservation
            var r = await _context.Reservations.Include(s => s.Person).Include(s => s.ReservationStatus).Include(s => s.ReservationTables).ThenInclude(s => s.Table).FirstOrDefaultAsync(s => s.Id == id);
            var updateTables = new List<Table>();
            foreach (var rt in r.ReservationTables)
            {
                updateTables.Add(rt.Table);
            }
            var statuses = await _context.ReservationStatuses.ToListAsync();
            if (updateTables.Count == 0)
            {
                var removeOne = statuses.Find(e => e.Description == "Seated");
                var removeTwo = statuses.Find(e => e.Description == "Completed");
                statuses.Remove(removeOne);
                statuses.Remove(removeTwo);
            }
            Update reservation = new Update
            {
                Id = r.Id,
                SittingId = r.SittingId,
                FirstName = r.Person.FirstName,
                Surname = r.Person.Surname,
                Phone = r.Person.Phone,
                Email = r.Person.Email,
                StartTime = r.StartTime,
                Duration = r.Duration,
                Guests = r.Guests,
                Notes = r.Notes,
                StatusId = r.ReservationStatusId,
                ReservationStatus = r.ReservationStatus,
                Status = new SelectList(statuses, "Id", "Description"),
                Tables = updateTables
            };
            
            return View(reservation);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatus(Update update)
        {
            if (ModelState.IsValid)
            {
                try
                { //update the status
                    var reservation = await _context.Reservations.FindAsync(update.Id);
                    if (reservation == null) { return NotFound(); }
                    reservation.ReservationStatusId = update.StatusId;
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Update", new { id = reservation.SittingId});
                }
                catch (Exception)
                {
                    ModelState.AddModelError("Exception", "Oops, there was an error");
                }
            } // build up model if theres an exception
            //var r = await _context.Reservations.Include(s => s.Person).Include(s => s.ReservationStatus).FirstOrDefaultAsync(s => s.Id == update.Id);
            //Update res = new Update
            //{
            //    Id = r.Id,
            //    FirstName = r.Person.FirstName,
            //    Surname = r.Person.Surname,
            //    Phone = r.Person.Phone,
            //    Email = r.Person.Email,
            //    StartTime = r.StartTime,
            //    Duration = r.Duration,
            //    Guests = r.Guests,
            //    Notes = r.Notes,
            //    StatusId = r.ReservationStatusId,
            //    ReservationStatus = r.ReservationStatus,
            //    Status = new SelectList(await _context.ReservationStatuses.ToListAsync(), "Id", "Description")
            //};

            return View();
        }
        
        public IActionResult ReservationMade()
        {
            return View();
        }

    }
}

