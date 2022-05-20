#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RRS.Data;

namespace RRS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Reservation
        public IActionResult Index(DateTime date)
        {
            if (date == new DateTime())
            {
                date = DateTime.Now;
            }

            ViewData["getReservationsByDate"] = date.ToString("yyyy-MM-dd");

            //var applicationDbContext = _context.Reservations
            //    .Include(r => r.Customer)
            //    .Include(r => r.ReservationOrigin)
            //    .Include(r => r.ReservationStatus)
            //    .Include(r => r.Sitting)
            //        .ThenInclude(s => s.SittingType)
            //    .Where(r => r.Sitting.Start.Date == date.Date)
            //    .OrderBy(r=>r.Sitting.Start)
            //    .AsNoTracking()
            //    .ToArrayAsync();


            return View();
        }

        // GET: Admin/Reservation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .Include(r => r.Customer)
                .Include(r => r.ReservationOrigin)
                .Include(r => r.ReservationStatus)
                .Include(r => r.Sitting)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: Admin/Reservation/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Set<Customer>(), "Id", "Id");
            ViewData["ReservationOriginId"] = new SelectList(_context.ReservationOrigins, "Id", "Id");
            ViewData["ReservationStatusId"] = new SelectList(_context.ReservationStatuses, "Id", "Id");
            ViewData["SittingId"] = new SelectList(_context.Sittings, "Id", "Id");
            return View();
        }

        // POST: Admin/Reservation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NoOfGuests,CustomerId,SittingId,ReservationStatusId,ReservationOriginId,CustomerNotes")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Set<Customer>(), "Id", "Id", reservation.CustomerId);
            ViewData["ReservationOriginId"] = new SelectList(_context.ReservationOrigins, "Id", "Id", reservation.ReservationOriginId);
            ViewData["ReservationStatusId"] = new SelectList(_context.ReservationStatuses, "Id", "Id", reservation.ReservationStatusId);
            ViewData["SittingId"] = new SelectList(_context.Sittings, "Id", "Id", reservation.SittingId);
            return View(reservation);
        }

        // GET: Admin/Reservation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .Include(r => r.Customer)
                .Include(r => r.ReservationOrigin)
                .Include(r => r.ReservationStatus)
                .Include(r => r.Sitting)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (reservation == null)
            {
                return NotFound();
            }
            ViewData["ReservationStatusId"] = new SelectList(_context.ReservationStatuses, "Id", "Description", reservation.ReservationStatus);
            return View(reservation);
        }

        // POST: Admin/Reservation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NoOfGuests,CustomerId,SittingId,ReservationStatusId,ReservationOriginId,CustomerNotes,StartTime")] Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return NotFound();
            }
            try
            {
                //Converts UTC time recieved from JS into local time format
                reservation.StartTime = reservation.StartTime.ToLocalTime();
                _context.Update(reservation);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(reservation.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            var sitting = await _context.Sittings
                .FirstOrDefaultAsync(r => r.Id == reservation.SittingId);
            return RedirectToAction("Index", new {date = sitting.Start});
            
            ViewData["CustomerId"] = new SelectList(_context.Set<Customer>(), "Id", "Id", reservation.CustomerId);
            ViewData["ReservationOriginId"] = new SelectList(_context.ReservationOrigins, "Id", "Id", reservation.ReservationOriginId);
            ViewData["ReservationStatusId"] = new SelectList(_context.ReservationStatuses, "Id", "Id", reservation.ReservationStatusId);
            ViewData["SittingId"] = new SelectList(_context.Sittings, "Id", "Id", reservation.SittingId);
            return View(reservation);
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservations.Any(e => e.Id == id);
        }
    }
}
