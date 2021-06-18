using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProgrammingProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingProject.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class AreaController : ManagerBaseController
    {
        public AreaController(ApplicationDbContext context, UserManager<ApplicationUser> userManager) : base(context, userManager)
        {

        }
        public async Task<IActionResult> Index()
        {
            var areas = await _context.Areas.Include(t => t.Table).ToListAsync();

            return View(areas);
        }

        //[HttpGet]
        //// just a create method
        //public IActionResult Create()
        //{
        //    var a = new Models.Area.Area();
            
        //    return View(a);
            
        //}

        [HttpPost]
        // just to pass in the Restaurant Id and Area Name to database and save it
        public async Task<IActionResult> Create(string Name)
        {
            if (ModelState.IsValid)
            {
                var checkName = await _context.Areas.FirstOrDefaultAsync(a => a.Name == Name);
                if (checkName != null)
                {
                    ViewBag.Message = "Exist";
                    return View();
                }

                var area = new Area
                {
                    Name = Name,
                    RestaurantId = 1

                };
                _context.Areas.Add(area);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Area", new { area = "Manager" });

            }
            
            return View(Name);
        }

        //[HttpGet]
        //public async Task<IActionResult> Edit(int id)
        //{
        //    var area = await _context.Areas.FindAsync(id);
        //    if (area == null)
        //    {
        //        return NotFound();
        //    }

        //    var a = new Models.Area.Edit
        //    {
        //        Id = area.Id,
        //        Name = area.Name

        //    };

        //    return View(a);
        //}

        public JsonResult CheckAreaNameAvailability(string userdata)
        {
            System.Threading.Thread.Sleep(200);
            var searchName = _context.Areas.Where(t => t.Name == userdata).FirstOrDefault();
            if (searchName != null)
            {
                return Json(1);
            }
            else
            {
                return Json(0);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Models.Area.Edit e)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var area = await _context.Areas.FirstOrDefaultAsync(a => a.Id==e.Id);
                    if (area == null)
                    {
                        return NotFound();
                    }

                    area.Name = e.Name;
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
        //    var area = await _context.Areas.FirstOrDefaultAsync(a => a.Id == Id);

        //    if (area == null) { return NotFound(); }
        //    var m = new Models.Area.Delete
        //    {
        //        Id = area.Id,
        //        Name = area.Name,
        //        RestaurantId = 1
        //    };

        //    return View(m);
        //}
        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var area = await _context.Areas.Include(t => t.Table).FirstOrDefaultAsync(a => a.Id == Id);
                if (area == null) { return NotFound(); }
                foreach (var table in area.Table)
                {
                    table.AreaId = 1;
                }
                _context.Areas.Remove(area);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                ModelState.AddModelError("Exception", "Oops, you broke my code");
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteAll(int Id)
        {
            try
            {
                var area = await _context.Areas.Include(t => t.Table).FirstOrDefaultAsync(a => a.Id == Id);
                if (area == null) { return NotFound(); }
                foreach (var table in area.Table)
                {
                    table.Active = false;
                    table.AreaId = 1;
                }
                _context.Remove(area);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                ModelState.AddModelError("Exception", "Oops, you broke my code");
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUnassigned(int Id)
        {
            try
            {
                var area = await _context.Areas.Include(t => t.Table).FirstOrDefaultAsync(a => a.Id == Id);
                if (area == null) { return NotFound(); }
                foreach (var table in area.Table)
                {
                    table.Active = false;
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                ModelState.AddModelError("Exception", "Oops, you broke my code");
            }

            return View();
        }

    }
}
