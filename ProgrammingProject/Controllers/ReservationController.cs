/// Notes for controller/ajoining views:
/// Validation is currently little to none
/// There's lots of trips to the db - may need either an index or refactoring
/// Views need to hide some info (like sitting ID) and show other info better
/// Client-side validation is buggy
/// maybe use some different input types to make it better
/// There is no capacity strategy


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProgrammingProject.Data;
using ProgrammingProject.Models.Reservation;

namespace ProgrammingProject.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public ReservationController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        //This is kinda moot now - shouldnt ever be accessed
        public async Task<IActionResult> Index()
        {
            //get list of all sittings and send to view
            var sittings = await _context.Sittings.Include(s => s.SittingType).ToListAsync();
            return View(sittings);
        }

        //This is kinda moot now - shouldnt ever be accessed
        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            //get the chosen sitting from the database - maybe could get it from last view to stop another trip to DB
            var sitting = await _context.Sittings.FirstOrDefaultAsync(s => s.Id == id);
            //get available times
            var times = new List<DateTime>();
            for (DateTime i = sitting.StartTime; i < sitting.EndTime.AddMinutes(-15); i = i.AddMinutes(15))
            {
                times.Add(i);
            }
            //if logged in as a member
            if (User.IsInRole("Member"))
            {
                var person = await _context.People.FirstOrDefaultAsync(p => p.Email == User.Identity.Name);
                var possibleReservation = new Create
                {
                    SittingId = sitting.Id,
                    PersonId = person.Id,
                    AvailableTimes = new SelectList(times)
                };
                return View(possibleReservation);
            } //not logged in
            else
            {
                var possibleReservation = new Create
                {
                    SittingId = sitting.Id,
                    AvailableTimes = new SelectList(times)
                };
                return View(possibleReservation);
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> Create(Models.Reservation.Create s)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    dynamic person = "";
                    //check if logged in
                    if (User.IsInRole("Member"))
                    {
                        person = await _context.People.FirstOrDefaultAsync(p => (p.Email == User.Identity.Name) && (p.Verified == true));
                    }
                    else
                    {   //check if they have an entry in the db but aren't a member
                        person = await _context.People.FirstOrDefaultAsync(p => (p.Email == s.Email) && (p.FirstName == s.FirstName) && (p.Surname == s.Surname) && (p.Phone == s.Phone));
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
                    }
                    //cast StartTime to datetime
                    var startTime = DateTime.Parse(s.StartTime);
                    //find the correct sitting to assign to
                    s.SittingId = _context.Sittings.FirstOrDefault(t => t.StartTime <= startTime && t.EndTime > startTime).Id;
                    //cast to reservation object
                    var reservation = new Reservation
                    {
                        PersonId = person.Id,
                        SittingId = s.SittingId,
                        ReservationSourceId = 1,
                        ReservationStatusId = 1,
                        StartTime = startTime,
                        Duration = 90,
                        Guests = s.Guests,
                        Notes = s.Notes
                    };
                    //send to db
                    _context.Reservations.Add(reservation);
                    _context.SaveChanges();
                    //redirect to success page
                    return RedirectToAction("ReservationMade", new { id = reservation.Id, area = "" } );
                }
                catch (Exception)
                {
                    ModelState.AddModelError("Exception", "Oops, there was an error");
                }
                
            }
            //on fail send back to this page.

            //send to current page with error message
            ///maybe should redirect to a create fail page 
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> ReservationMade(int id)
        {
            var reservation = await _context.Reservations.Include(r => r.Person).FirstOrDefaultAsync(r => r.Id == id);

            return View(reservation);
        }

    }
}
