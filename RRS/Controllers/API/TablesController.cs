using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RRS.Data;
using RRS.Models.Tables;

namespace RRS.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TablesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("AddReservation/{tableId}/{resId}")]
        public async Task<ReservationTable> AddReservation(int tableId, int resId)
        {
            var resTable = new ReservationTable { TableId = tableId, ReservationId = resId };
            await _context.AddAsync(resTable);
            _context.SaveChanges();
            return resTable;
        }

        [HttpPost]
        [Route("RemoveReservation/{tableId}/{resId}")]

        public async Task<ReservationTable> RemoveResevation( int tableId, int resId)
        {
            ReservationTable reservation = _context.ReservationTables.Where(rt => rt.TableId == tableId && rt.ReservationId == resId).FirstOrDefault();
            _context.Remove(reservation);
            _context.SaveChanges();

            return reservation;
        }



        [HttpGet]
        [Route("area/{id}")]
        public async Task<ActionResult<IEnumerable<TablesDto>>> Area(int id)
        {

            var result = await _context.Tables
                .Where(t => t.AreaId == id)
                .Include(t => t.Reservations)
                .Select(t => new TablesDto
                {
                    Id = t.Id,
                    AreaId = t.AreaId,
                    Description = t.Description,
                    ReservationId = t.Reservations.FirstOrDefault().Id
                })
                .ToListAsync();

            return result;
        }


        [HttpGet]
        [Route("available-dates/{start?}")]
        public async Task<ActionResult<IEnumerable<DateTime>>> AvailableDates(DateTime start = new DateTime())
        {
            var startLocal = start.ToLocalTime();
            return await _context.Sittings
                .Where(s => s.Start.Date >= startLocal.Date)
                .Select(s => s.Start)
                .ToListAsync();
        }


        [HttpGet]
        [Route("available-sittings/{date}")]
        public async Task<ActionResult<IEnumerable<SittingByDateDto>>> AvailableSittings(DateTime date)
        {
            var dateLocal = date.ToLocalTime();
            return await _context.Sittings
                .Include(s => s.SittingType)
                .Where(s => s.Start.Date == dateLocal.Date)
                .OrderBy(s => s.Start)
                .Select(s => new SittingByDateDto
                {
                    Id = s.Id,
                    Type = s.SittingType.Description
                })
                .ToListAsync();
        }

        [HttpGet]
        [Route("available-areas/{RestaurantId}")]
        public async Task<ActionResult<IEnumerable<AreaDto>>> AvailableAreas(int RestaurantId)
        {
            return await _context.Areas
                .Where(a => a.RestaurantId == RestaurantId)
                .OrderBy(a => a.Description)
                .Select(a => new AreaDto
                {
                    Id = a.Id,
                    Type = a.Description
                })
                .ToListAsync();
        }


        [HttpGet]
        [Route("available-reservations/{sittingId}")]
        public async Task<ActionResult<IEnumerable<ReservationBySittingIdDto>>> getReservations(int sittingId)
        {

            return await _context.Reservations
                .Include(r => r.ReservationStatus)
                .Include(r => r.Customer)
                .Where(r => r.SittingId == sittingId && r.ReservationStatus.Description != "Cancelled" && r.ReservationStatus.Description != "Completed")
                .Select(r => new ReservationBySittingIdDto
                {
                    NoOfGuests = r.NoOfGuests,
                    ReservationStatus = r.ReservationStatus.Description,
                    CustomerNotes = r.CustomerNotes,
                    FirstName = r.Customer.FirstName,
                    LastName = r.Customer.LastName,
                    PhoneNumber = r.Customer.PhoneNumber,
                    Email = r.Customer.Email,
                    StartTime = r.StartTime
                })
                .ToListAsync();
        }

    }
}
