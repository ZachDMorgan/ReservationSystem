using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProgrammingProject.Data;

namespace ProgrammingProject.Areas.Manager.Controllers
{
    public class SittingController : ManagerBaseController
    {
        public SittingController(ApplicationDbContext context, UserManager<ApplicationUser> userManager) : base(context, userManager)
        {

        }

        public async Task<IActionResult> Index()
        {
            // index page to show the sitting that created
            var sitting = await _context.Sittings.Where(s => s.EndTime >= DateTime.Now).Include(s => s.SittingType).Include(s => s.Reservations).ToListAsync();
            sitting.Sort((x, y) => DateTime.Compare(x.StartTime, y.StartTime));
            return View(sitting);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {


            // Create method of sitting with a select list of sitting type

            var m = new Models.Sitting.Create
            {
                SittingType = new SelectList(await _context.SittingTypes.ToListAsync(), "Id", "Description"),
                StartTime = DateTime.Now,
                EndTime = DateTime.Now

            };

            return View(m);
        }


        [HttpPost]
        //post info to database with the restaurant Id = 1 (required) 
        public async Task<IActionResult> Create(Models.Sitting.Create m)
        {

            if (ModelState.IsValid)
            {
                if (m.SittingTypeId == -1)
                {
                    var sittingType = await _context.SittingTypes.FirstOrDefaultAsync(s => s.Description == m.CustomSittingType);
                    if(sittingType != null)
                    {
                        sittingType.Active = true;
                        var sitting = new Sitting
                        {
                            RestaurantId = 1,
                            SittingTypeId = sittingType.Id,
                            StartTime = m.StartTime,
                            EndTime = m.EndTime,
                            Capacity = m.Capacity,
                            Open = m.Open
                        };
                        _context.Sittings.Add(sitting);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        var st = new SittingType { Description = m.CustomSittingType, Active = true };
                        _context.SittingTypes.Add(st);
                        await _context.SaveChangesAsync();
                        var sitting = new Sitting
                        {
                            RestaurantId = 1,
                            SittingTypeId = st.Id,
                            StartTime = m.StartTime,
                            EndTime = m.EndTime,
                            Capacity = m.Capacity,
                            Open = m.Open
                        };
                        _context.Sittings.Add(sitting);
                        await _context.SaveChangesAsync();
                    }
                    
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var sitting = new Sitting
                    {
                        RestaurantId = 1,
                        SittingTypeId = m.SittingTypeId,
                        StartTime = m.StartTime,
                        EndTime = m.EndTime,
                        Capacity = m.Capacity,
                        Open = m.Open
                    };
                    _context.Sittings.Add(sitting);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            m.SittingType = new SelectList(await _context.SittingTypes.ToListAsync(), "Id", "Description", m.SittingTypeId);

            return View(m);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            _context.Remove(await _context.Sittings.FirstOrDefaultAsync(s => s.Id == Id));
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }


        //refactor if possible to make safer - bad redirects
        [HttpPost]
        public async Task<IActionResult> Edit(Models.Sitting.Edit e)
        {
            if (ModelState.IsValid)
            {
                if (e.EditSittingTypeId == -1)
                {
                    var st = new SittingType { Description = e.CustomSittingType, Active = true };
                    _context.SittingTypes.Add(st);
                    await _context.SaveChangesAsync();
                    e.EditSittingTypeId = st.Id;
                }
                var sitting = await _context.Sittings.Include(s => s.SittingType).Include(s => s.Reservations).FirstOrDefaultAsync(s => s.Id == e.EditId);
                if (sitting != null)
                {
                    sitting.SittingTypeId = e.EditSittingTypeId;
                    sitting.StartTime = e.EditEndTime;
                    sitting.EndTime = e.EditEndTime;
                    sitting.Capacity = e.EditCapacity;
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}

