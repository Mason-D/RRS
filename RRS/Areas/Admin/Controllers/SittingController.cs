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
using RRS.Models;

namespace RRS.Areas.Admin.Controllers
{
    public class SittingController : AdminAreaController
    {
      
        public SittingController(ApplicationDbContext context, UserManager<IdentityUser> userManager) : base(context, userManager)
        {


        }


        // GET: Admin/Sitting
        public IActionResult Index()
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
            //ViewData["RestaurantId"] = new SelectList(_context.Restaurants, "Id", "Name");
            ViewData["RestaurantId"] = 1;
            ViewData["SittingTypeId"] = new SelectList(_context.SittingTypes, "Id", "Description");
            return View();
        }

        // POST: Admin/Sitting/Create
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
                    SittingTypeId = sitting.SittingTypeId,
                    Cutoff = sitting.CutOff,
                    Interval = sitting.Interval,
                    GroupId = null
                };

                _context.Add(SingleSitting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Edit));
            }


            if(sitting.Group == "Weeks")
            {
                List<string> selectedDays = sitting.SelectedDays.Split(',').ToList();
                var startDate = sitting.Start;
                var endDate = sitting.EndDate.AddDays(1);
                List<Sitting> sittings = new List<Sitting>();

                Guid guid = Guid.NewGuid();

                for (DateTime date = startDate; date  < endDate; date = date.AddDays(1))
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
                            SittingTypeId = sitting.SittingTypeId,
                            Cutoff = sitting.CutOff,
                            Interval = sitting.Interval,
                            GroupId = guid
                        }); ;
                    }
                }
                _context.AddRange(sittings);
                _context.SaveChanges();
                return RedirectToAction(nameof(Edit));
            }


            ViewData["SittingTypeId"] = new SelectList(_context.SittingTypes, "Id", "Description", sitting.SittingTypeId);
            return View(sitting);
        }

        // GET: Admin/Sitting/Edit
        [HttpGet]
        public IActionResult Edit(string? lastSelectedDate)
        {
            ViewData["LastSelectedDate"] = lastSelectedDate == null ? null : lastSelectedDate;
            ViewData["SittingTypeId"] = new SelectList(_context.SittingTypes, "Id", "Description");
            return View(new SittingDto());
        }

        // POST: Admin/Sitting/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            [Bind("Id,Start,Duration,Capacity,IsOpen,SittingTypeId,Interval,Cutoff, GroupId")] SittingDto sittingDto)
        {
            if (sittingDto.Id <= 0)
            {
                return View("Edit");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var s = _context.Sittings.Where(s => s.Id == sittingDto.Id).FirstOrDefaultAsync();

                    if (s.Result == null) // When disabled id input is manipulated to a non-existent id
                    {
                        return NotFound();
                    }

                    s.Result.Start = sittingDto.Start;
                    s.Result.Duration = sittingDto.Duration;
                    s.Result.Capacity = sittingDto.Capacity;
                    s.Result.IsOpen = sittingDto.IsOpen;
                    s.Result.Interval = sittingDto.Interval;
                    s.Result.Cutoff = sittingDto.Cutoff;
                    s.Result.SittingTypeId= sittingDto.SittingTypeId;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SittingExists(sittingDto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Edit), "Sitting", new { LastSelectedDate = sittingDto.Start.ToString("yyyy-MM-dd") });
            }
            ViewData["LastSelectedDateTime"] = ModelState["Start"].ValidationState.ToString() == "Valid" ? sittingDto.Start.ToString("yyyy-MM-ddThh:mm:ss") : null;
            ViewData["LastSelectedDate"] = ModelState["Start"].ValidationState.ToString() == "Valid" ? sittingDto.Start.ToString("yyyy-MM-dd") : null;
            ViewData["LastSelectedSitting"] = sittingDto == null ? null : sittingDto;
            ViewData["SittingTypeId"] = new SelectList(_context.SittingTypes, "Id", "Description");
            return View("Edit");
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
        public async Task<IActionResult> DeleteConfirmed(int id, DateTime start, Guid? groupId, bool selectAllGroupId = false)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            if (selectAllGroupId)
            {
                var sittings = await _context.Sittings.Where(s => s.GroupId == groupId).ToListAsync();
                if (sittings.Count == 0)
                {
                    return NotFound();
                }
                foreach (var s in sittings) 
                {
                    var reservations = await _context.Reservations
                                                .Include(r => r.ReservationStatus)
                                                .Where(r => r.SittingId == id && r.ReservationStatus.Description != "Cancelled")
                                                .ToListAsync();
                    if (reservations.Count > 0)
                    {
                        return View("SittingHasReservationError");
                    }
                }
                foreach (var validS in sittings)
                {
                    _context.Sittings.Remove(validS);
                }
            }
            else
            {
                var sitting = await _context.Sittings.Where(s => s.Id == id).FirstOrDefaultAsync();
                if (sitting == null)
                {
                    return NotFound();
                }
                var reservations = await _context.Reservations
                                            .Include(r => r.ReservationStatus)
                                            .Where(r => r.SittingId == id && r.ReservationStatus.Description != "Cancelled")
                                            .ToListAsync();
                if (reservations.Count > 0)
                {
                    return View("SittingHasReservationError");
                }
                _context.Sittings.Remove(sitting);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Edit), "Sitting", new { LastSelectedDate = start.ToString("yyyy-MM-dd") });
        }

        private bool SittingExists(int id)
        {
            return _context.Sittings.Any(e => e.Id == id);
        }
    }
}
