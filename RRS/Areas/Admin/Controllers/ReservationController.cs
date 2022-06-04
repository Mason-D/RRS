#nullable disable
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RRS.Data;
using RRS.Models;

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
                return View("/Views/Shared/BeanError.cshtml");
            }

            var reservation = await _context.Reservations
                .Include(r => r.Customer)
                .Include(r => r.ReservationOrigin)
                .Include(r => r.ReservationStatus)
                .Include(r => r.Sitting)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                return View("/Views/Shared/BeanError.cshtml");
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
                return View("/Views/Shared/BeanError.cshtml");
            }

            var reservation = await _context.Reservations
                .Include(r => r.Customer)
                .Include(r => r.ReservationOrigin)
                .Include(r => r.ReservationStatus)
                .Include(r => r.Sitting)
                    .ThenInclude(s => s.SittingType)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (reservation == null)
            {
                return View("/Views/Shared/BeanError.cshtml");
            }
            ViewData["ReservationStatusId"] = new SelectList(_context.ReservationStatuses, "Id", "Description", reservation.ReservationStatus);
            return View(reservation);
        }

        // POST: Admin/Reservation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("Id,NoOfGuests,CustomerId,SittingId,ReservationStatusId,ReservationOriginId,CustomerNotes,StartTime")] ReservationEditDto reservation)
        {
            Trace.Listeners.Add(new TextWriterTraceListener("AdminReservationEdit.log"));
            Debug.WriteLine("Debugging in Admin/ReservationController/Edit Post");
            Debug.WriteLine("Checking that the passed Reservation data object exists");
            Debug.Assert(reservation != null, "ReservationEditDto is null");
            Debug.WriteLine("Checking that the passed Id is the same as the model's Id");
            Debug.Assert(reservation.Id == id, "Ids do not match");
            if (id != reservation.Id)
            {
                Debug.WriteLine("Exiting post to error screen");
                Trace.Close();
                return View("/Views/Shared/BeanError.cshtml");
            }
            Debug.WriteLine("Checking that the number of people passed is an acceptable amount");
            Debug.Assert(reservation.NoOfGuests > 0, $"{reservation.NoOfGuests} is less than 1");
            Debug.Assert(reservation.NoOfGuests < 2147483647, $"{reservation.NoOfGuests} breaks the database integer data type limit");
            if (reservation.NoOfGuests < 0 || reservation.NoOfGuests >= 2147483647)
            {
                Debug.WriteLine("Exiting post to error screen");
                Trace.Close();
                return View("/Views/Shared/BeanError.cshtml");
            }
            Debug.WriteLine("Checking that the ModelState is valid");
            Debug.Assert(ModelState.IsValid, "ReservationEditDto is invalid");
            if (ModelState.IsValid)
            {
                Debug.WriteLine($"Attempting to post a new reservation with the ReservationEditDto of: {reservation}");
                try
                {
                    Debug.WriteLine("Searching for reservation in the data base with matching Id as passed model");
                    var r = _context.Reservations.Where(r => r.Id == reservation.Id).FirstOrDefaultAsync();
                    Debug.Assert(r.Result is not null, "Could not find reservation matching model to edit in database");
                    if (r.Result is null)
                    {
                        Debug.WriteLine("Exiting post to error screen");
                        Trace.Close();
                        return View("/Views/Shared/BeanError.cshtml");
                    }

                    Debug.WriteLine("Converting UTC time to local time format");
                    Debug.WriteLine($"UTC date time ({reservation.StartTime})");
                    //Converts UTC time recieved from JS into local time format
                    DateTime localDateTime = reservation.StartTime.ToLocalTime();
                    Debug.WriteLine($"Local date time ({localDateTime})");


                    Debug.WriteLine("Updating reservation in data base with passed model and converted start datetime");
                    r.Result.Id = reservation.Id;
                    r.Result.NoOfGuests = reservation.NoOfGuests;
                    r.Result.CustomerId = reservation.CustomerId;
                    r.Result.SittingId = reservation.SittingId;
                    r.Result.ReservationStatusId = reservation.ReservationStatusId;
                    r.Result.ReservationOriginId = reservation.ReservationOriginId;
                    r.Result.CustomerNotes = reservation.CustomerNotes;
                    r.Result.StartTime = localDateTime;


                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    Debug.WriteLine("Error caught and exiting Post");
                    Trace.Close();
                    if (!ReservationExists(reservation.Id))
                    {
                        return View("/Views/Shared/BeanError.cshtml");
                    }
                    else
                    {
                        throw;
                    }
                }
                Debug.WriteLine("Reservation successfully edited in database");
                Trace.Close();
                var sitting = await _context.Sittings
                    .FirstOrDefaultAsync(s => s.Id == reservation.SittingId);
                return RedirectToAction("Index", new { date = sitting.Start });
            }
            Debug.WriteLine("Returning to Edit Reservation page");
            Trace.Close();
            ViewData["ReservationStatusId"] = new SelectList(_context.ReservationStatuses, "Id", "Description");
            return RedirectToAction("Edit", reservation.Id);
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservations.Any(e => e.Id == id);
        }
    }
}
