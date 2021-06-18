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
    public class TableController : ManagerBaseController
    {
        public TableController(ApplicationDbContext context, UserManager<ApplicationUser> userManager) : base(context, userManager)
        {

        }
        public async Task<IActionResult> Index()
        {
            var tables = await _context.Tables.Include(a => a.Area).ToListAsync();
            return View(tables);
        }


        //[HttpGet]

        //// Create form for table with select list of Area
        //public async Task<IActionResult> Create()
        //{
        //    var t = new Models.Table.Table();
        //    t.Areas = new SelectList(await _context.Areas.ToListAsync(), "Id", "Name");
        //    return View(t);

        //}

        [HttpPost]
        //Pass the table name and seat number with a select list of an 'Area' to assgin for
        public async Task<IActionResult> Create(Models.Table.Table t)
        {
            if (ModelState.IsValid)
            {
               

                var tableCheck = await _context.Tables.FirstOrDefaultAsync(n => n.Name == t.Name);
                if (tableCheck != null)
                {
                    tableCheck.Active = true;
                    tableCheck.Seats = t.Seats;
                    tableCheck.AreaId = t.AreaId;
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Area", new { area = "Manager" });
                }
                var checkName = await _context.Tables.FirstOrDefaultAsync(c => c.Name == t.Name);
                if (checkName != null)
                {
                    ViewBag.Message = "Exist";
                    return View();
                }
                else
                {
                    var table = new Table
                    {
                        Name = t.Name,
                        Seats = t.Seats,
                        AreaId = t.AreaId,
                        Active = true

                    };
                    _context.Tables.Add(table);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Area", new { area = "Manager" });
                }
                //var table = new Table
                //{
                //    Name = t.Name,
                //    Seats = t.Seats,
                //    AreaId = t.AreaId,
                //    Active = true

                //};
                //_context.Tables.Add(table);
                //await _context.SaveChangesAsync();
                //return RedirectToAction("Index", "Area", new { area = "Manager" });


            }
            //t.Areas = new SelectList(await _context.Areas.ToListAsync(), "Id", "Name", t.AreaId);


            return View(t);
        }

        public JsonResult CheckNameAvailability(string userdata)
        {
            System.Threading.Thread.Sleep(200);
            var searchName = _context.Tables.FirstOrDefault(t => t.Name == userdata);
            if(searchName != null)
            {
                if(searchName.Active == true) { return Json(1); }  
            }
            return Json(0);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var table = await _context.Tables.FindAsync(id);
            if (table == null)
            {
                return NotFound();
            }

            var t = new Models.Table.Edit
            {
                Id = table.Id,
                Name = table.Name,
                Seats = table.Seats,
                AreaId = table.AreaId,
                Areas = new SelectList(await _context.Areas.ToListAsync(), "Id", "Name", table.AreaId)

            };

            return View(t);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Models.Table.Edit e)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var table = await _context.Tables.FindAsync(e.Id);
                    if (table == null)
                    {
                        return NotFound();
                    }
                    table.Name = e.Name;
                    table.Seats = e.Seats;
                    table.AreaId = e.AreaId;
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Area", new { area = "Manager" });
                }
                catch (Exception)
                {

                    ModelState.AddModelError("Exception", "Error of edit");
                }
            }
            e.Areas = new SelectList(await _context.Areas.ToListAsync(), "Id", "Description", e.AreaId);
            return View(e);
        }

        //[HttpGet]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var table = await _context.Tables.Include(a => a.Area).FirstOrDefaultAsync(t => t.Id == id);
        //    if (table == null) { return NotFound(); }
        //    var t = new Models.Table.Delete
        //    {
        //        Id = table.Id,
        //        Name = table.Name,
        //        Seats = table.Seats,
        //        AreaId = table.AreaId,
        //        Areas = table.Area.Name
        //    };
        //    //t.Areas = table.Area.Name;
        //    return View(t);
        //}

        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var table = await _context.Tables.Include(a => a.Area).FirstOrDefaultAsync(t => t.Id == Id);
                if (table == null) { return NotFound(); }
                table.Active = false;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Area", new { area = "Manager" });
            }
            catch (Exception)
            {

                ModelState.AddModelError("Exception", "Oops, you broke my code");
            }
            return View();
        }
        //just testing comment for Cam
    }
}
