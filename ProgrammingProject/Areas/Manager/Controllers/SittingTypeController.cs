using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingProject.Areas.Manager.Controllers
{
    public class SittingTypeController : ManagerBaseController
    {
        public SittingTypeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager) : base(context, userManager)
        {

        }
        public async Task<IActionResult> Index()
        {
            var type = await _context.SittingTypes.ToListAsync();
            return View(type);
        }
        //[HttpGet]
        //public IActionResult Create()
        //{
        //    var sitType = new Models.SittingType.SittingType();
        //    return View(sitType);
        //}
        [HttpPost]
        public async Task<IActionResult> Create(string Description)
        {
            if (ModelState.IsValid)
            {

                var type = new SittingType
                {
                    Description = Description

                };
                _context.SittingTypes.Add(type);
                await _context.SaveChangesAsync();
                //DOESN't REDIRECT PROPERLY
                return RedirectToAction("Index", "SittingType", new { area = "Manager" });


            }

            return View(Description);
        }

        //[HttpGet]
        //public async Task<IActionResult> Edit(int id)
        //{
        //    var type = await _context.SittingTypes.FindAsync(id);
        //    if (type == null)
        //    {
        //        return NotFound();
        //    }

        //    var a = new Models.SittingType.Edit
        //    {
        //        Id = type.Id,
        //        Name = type.Description

        //    };

        //    return View(a);
        //}

        [HttpPost]
        public async Task<IActionResult> Edit(Models.SittingType.Edit e)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var type = await _context.SittingTypes.FirstOrDefaultAsync(s=> s.Id==e.Id);
                    if (type == null)
                    {
                        return NotFound();
                    }

                    
                    type.Description = e.Name;

                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {

                    ModelState.AddModelError("Exception", "Error of edit");
                }
            }

            return View(e);
        }
        //[HttpGet]
        //public async Task<IActionResult> Delete(int Id)
        //{
        //    var type = await _context.SittingTypes.FirstOrDefaultAsync(a => a.Id == Id);

        //    if (type == null) { return NotFound(); }
        //    var m = new Models.SittingType.Delete
        //    {
        //        Id = type.Id,
        //        Name = type.Description

        //    };

        //    return View(m);
        //}
        [HttpPost]
        public async Task<IActionResult> Delete(Models.SittingType.Delete m)
        {
            try
            {
                var type = await _context.SittingTypes.FirstOrDefaultAsync(a => a.Id == m.Id);
                if (type == null) { return NotFound(); }
                _context.SittingTypes.Remove(type);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "SittingType", new { area = "Manager" });
            }
            catch (Exception)
            {

                ModelState.AddModelError("Exception", "Oops, you broke my code");
            }

            return View(m);
        }

    }
}
