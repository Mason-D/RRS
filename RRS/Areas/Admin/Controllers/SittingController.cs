#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RRS.Data;
using RRS.Models;

namespace RRS.Areas.Admin.Controllers
{
    public class SittingController : AdminAreaController
    {
      
        public SittingController(ApplicationDbContext context, UserManager<IdentityUser> userManager) : base(context, userManager)
        {


        }


        // GET: Admin/Sitting
        public async Task<IActionResult> Index()
        {
            //var applicationDbContext = _context.Sittings.Include(s => s.Restaurant).Include(s => s.SittingType);
            //return View(await applicationDbContext.ToListAsync());
            ViewData["SittingTypeId"] = new SelectList(_context.SittingTypes, "Id", "Description");
            return View(new SittingDto());
        }

        // GET: Admin/Sitting/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sitting = await _context.Sittings
                .Include(s => s.Restaurant)
                .Include(s => s.SittingType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sitting == null)
            {
                return NotFound();
            }

            ViewData["SittingTypeId"] = new SelectList(_context.SittingTypes, "Id", "Id");
            return View(sitting);
        }

        // GET: Admin/Sitting/Create
        public IActionResult Create()
        {
            ViewData["RestaurantId"] = new SelectList(_context.Restaurants, "Id", "Id");
            ViewData["SittingTypeId"] = new SelectList(_context.SittingTypes, "Id", "Id");
            return View();
        }

        // POST: Admin/Sitting/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Start,Duration,IsOpen,Capacity,RestaurantId,SittingTypeId")] Sitting sitting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sitting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RestaurantId"] = new SelectList(_context.Restaurants, "Id", "Id", sitting.RestaurantId);
            ViewData["SittingTypeId"] = new SelectList(_context.SittingTypes, "Id", "Id", sitting.SittingTypeId);
            return View(sitting);
        }

        // GET: Admin/Sitting/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sitting = await _context.Sittings.FindAsync(id);
            if (sitting == null)
            {
                return NotFound();
            }
            ViewData["RestaurantId"] = new SelectList(_context.Restaurants, "Id", "Id", sitting.RestaurantId);
            ViewData["SittingTypeId"] = new SelectList(_context.SittingTypes, "Id", "Id", sitting.SittingTypeId);
            return View(sitting);
        }

        // POST: Admin/Sitting/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,Start,Duration,Capacity,IsOpen,SittingTypeId")] SittingDto sittingDto)
        {
            var s = _context.Sittings.Where(s => s.Id == sittingDto.Id).FirstOrDefaultAsync();

            if (s == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    s.Result.Start = sittingDto.Start;
                    s.Result.Duration = sittingDto.Duration;
                    s.Result.Capacity = sittingDto.Capacity;
                    s.Result.IsOpen = sittingDto.IsOpen;

                    //Sitting Type ID not implemented, requires select list in index.cshtml
                    s.Result.SittingTypeId= sittingDto.SittingTypeId;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SittingExists(s.Result.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["RestaurantId"] = new SelectList(_context.Restaurants, "Id", "Id", sitting.RestaurantId);
            ViewData["SittingTypeId"] = new SelectList(_context.SittingTypes, "Id", "Id", sittingDto.SittingTypeId);
            return View(sittingDto);
        }

        // GET: Admin/Sitting/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sitting = await _context.Sittings
                .Include(s => s.Restaurant)
                .Include(s => s.SittingType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sitting == null)
            {
                return NotFound();
            }

            return View(sitting);
        }

        // POST: Admin/Sitting/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sitting = await _context.Sittings.FindAsync(id);

            if (sitting == null)
            {
                return NotFound();
            }

            _context.Sittings.Remove(sitting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SittingExists(int id)
        {
            return _context.Sittings.Any(e => e.Id == id);
        }
    }
}
