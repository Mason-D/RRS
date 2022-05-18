#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RRS.Areas.Admin.Models.Sittings;
using RRS.Data;

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
            var applicationDbContext = _context.Sittings.Include(s => s.Restaurant).Include(s => s.SittingType);
            return View(await applicationDbContext.ToListAsync());
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

            return View(sitting);
        }

        // GET: Admin/Sitting/Create
        public IActionResult Create()
        {
            //ViewData["RestaurantId"] = new SelectList(_context.Restaurants, "Id", "Name");
            ViewData["RestaurantId"] = 1;
            ViewData["SittingTypeId"] = new SelectList(_context.SittingTypes, "Id", "Description");
            return View();
        }

        // POST: Admin/Sitting/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Start,Duration,Capacity,RestaurantId,SittingTypeId,Interval,CutOff, NewSitting, NewSittingName, Group, WeeksToRepeat ,SelectedDays , EndDate")] SittingsVm sitting)
        {
 
            
            if(sitting.NewSittingName !=null)
            {
                SittingType st = new SittingType { Description = sitting.NewSittingName };
                _context.Add(st);
                await _context.SaveChangesAsync();
                var newSittingName =  await _context.SittingTypes.Where(s => s.Description == sitting.NewSittingName).FirstOrDefaultAsync();
                sitting.SittingTypeId = newSittingName.Id;
            }
            // probs going to have to add a way to remove sitting types 

            if(sitting.Group  == null)
            {
                var SingleSitting = new Sitting()
                {
                    RestaurantId = sitting.RestaurantId,
                    Start = sitting.Start,
                    Duration = sitting.Duration,
                    IsOpen = sitting.IsOpen,
                    Capacity = sitting.Capacity,
                    SittingTypeId = sitting.SittingTypeId
                };

                _context.Add(SingleSitting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            if(sitting.Group == "Weeks")
            {
                List<string> selectedDays = sitting.SelectedDays.Split(',').ToList();
                var startDate = sitting.Start;
                var endDate = sitting.EndDate;

                var testOutPut = new List<DateTime>();

                List<Sitting> sittings = new List<Sitting>();

                for (DateTime date = startDate; date < endDate; date = date.AddDays(1))
                {
                    var dayOfTheWeek = date.DayOfWeek;

                    if(selectedDays.Contains(dayOfTheWeek.ToString()))
                    {
                        sittings.Add(new Sitting()
                        {
                            RestaurantId = sitting.RestaurantId,
                            Start = date,
                            Duration = sitting.Duration,
                            IsOpen = sitting.IsOpen,
                            Capacity = sitting.Capacity,
                            SittingTypeId = sitting.SittingTypeId
                        });
                    }
                }
                _context.Add(sittings);


            }


            ViewData["SittingTypeId"] = new SelectList(_context.SittingTypes, "Id", "Description", sitting.SittingTypeId);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Start,Duration,IsOpen,Capacity,RestaurantId,SittingTypeId")] Sitting sitting)
        {
            if (id != sitting.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sitting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SittingExists(sitting.Id))
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
            ViewData["RestaurantId"] = new SelectList(_context.Restaurants, "Id", "Id", sitting.RestaurantId);
            ViewData["SittingTypeId"] = new SelectList(_context.SittingTypes, "Id", "Id", sitting.SittingTypeId);
            return View(sitting);
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
            var sitting = await _context.Sittings.FindAsync(id);
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
