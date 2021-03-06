using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RRS.Data;
using RRS.Models;

namespace RRS.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SittingsController : ControllerBase        
    {
        private readonly ApplicationDbContext _context;

        public SittingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("available/{start}/{end?}")]
        public async Task<ActionResult<IEnumerable<SittingDto>>> Available(DateTime start, DateTime end = new DateTime())
        {
            var startLocal = start.ToLocalTime();
            var endLocal = end == new DateTime() ? startLocal.AddDays(28 * 3) : end.ToLocalTime();

                return await _context.Sittings
                                .Where(s => s.IsOpen && s.Start.Date >= startLocal.Date && s.Start.Date <= endLocal.Date)
                                .Select(s => new SittingDto
                                {
                                    Id = s.Id,
                                    Start = s.Start,
                                    Duration = s.Duration,
                                    Capacity = s.Capacity,
                                    IsOpen = s.IsOpen,
                                    SittingTypeDescription = s.SittingType.Description
                                })
                                .ToListAsync();
        }

        [HttpGet]
        [Route("any/{start}/{end?}")]
        public async Task<ActionResult<IEnumerable<SittingDto>>> Any(DateTime start, DateTime end = new DateTime())
        {
            var startLocal = start.ToLocalTime();
            var endLocal = end == new DateTime() ? startLocal : end.ToLocalTime();

            return await _context.Sittings
                            .Include(s => s.Reservations)
                                .ThenInclude(r => r.ReservationStatus)
                            .Where(s => s.Start.Date >= startLocal.Date && s.Start.Date <= endLocal.Date)
                            .Select(s => new SittingDto
                            {
                                Id = s.Id,
                                Start = s.Start,
                                Duration = s.Duration,
                                Capacity = s.Capacity,
                                Interval = s.Interval,
                                Cutoff = s.Cutoff,
                                IsOpen = s.IsOpen,
                                SittingTypeDescription = s.SittingType.Description,
                                SittingTypeId = s.SittingType.Id,
                                TotalGuests = s.TotalGuests,
                                GroupId = s.GroupId
                            })
                            .ToListAsync();
        }

        [HttpGet]
        [Route("distinct-available/{start}/{end?}")]
        public async Task<ActionResult<Dictionary<int, Dictionary<int, IEnumerable<int>>>>> DistinctAvailable(DateTime start, DateTime end = new DateTime())
        {          
            var startLocal = start.ToLocalTime();
            var endLocal = end == new DateTime() ? startLocal.AddDays(28 * 3) : end.ToLocalTime();

            var sittings = await _context.Sittings.Where(s => s.IsOpen && s.Start.Date >= startLocal.Date && s.Start.Date <= endLocal.Date)
                                                    .Select( s => new { Start = s.Start})
                                                    .ToArrayAsync();

            return sittings.GroupBy(s => s.Start.Year).ToDictionary(x => x.Key, 
                        x => x.GroupBy(s => s.Start.Month).ToDictionary(x => x.Key, 
                            x => x.GroupBy(s => s.Start.Day).Select(x => x.Key)));
        }

        [HttpGet]
        [Route("day-types/{year}/{month}/{day}")]
        public async Task<ActionResult<IEnumerable<SittingByDayDto>>> DayTypes(int year, int month, int day)
        {
            DateTime reservationDate;
            try
            {
                reservationDate = new DateTime(year, month, day);
            }
            catch (ArgumentOutOfRangeException)
            {
                return BadRequest();
            }

            //var dateLocal = reservationDate.ToLocalTime();

            return await _context.Sittings
                            .Where(s => s.IsOpen && s.Start.Date == reservationDate.Date)
                            .Include(s => s.Reservations)
                                .ThenInclude(r => r.ReservationStatus)
                            .Select(s => new SittingByDayDto { 
                                Id = s.Id, 
                                Type = s.SittingType.Description, 
                                Duration = s.Duration, Start = s.Start.ToString("HH:mm"),
                                Capacity = s.Capacity,
                                TotalGuests = s.TotalGuests,
                                Cutoff = s.Cutoff,
                                Interval = s.Interval
                            })
                            .ToListAsync();
        }

        //Anti forgery token attribute
        [Route("toggle-availability/{id}")]
        public async Task<ActionResult<IEnumerable<SittingByDayDto>>> ToggleAvailability(int id)
        {
            var sitting = await _context.Sittings.Where(s => s.Id == id).FirstOrDefaultAsync();
            sitting.IsOpen = sitting.IsOpen == true ? false : true;
            await _context.SaveChangesAsync();
            return Ok(sitting);
        }


        [HttpGet]
        [Route("capacity-warnings")]
        public async Task<ActionResult<IEnumerable<SittingDto>>> CapacityWarnings()
        {
            var warning =  await _context.Sittings
                .Include(s => s.Reservations)
                    .ThenInclude(r => r.ReservationStatus)
                .Where(s => s.Start.Date >= DateTime.UtcNow.Date && s.IsOpen == true && s.Reservations.Sum(r => r.ReservationStatus.Description == "Cancelled" ? 0 : r.NoOfGuests) >= s.Capacity*0.9)
                .OrderByDescending(s => (double)s.Reservations.Sum(r => r.ReservationStatus.Description == "Cancelled" ? 0 : r.NoOfGuests)/s.Capacity)   
                .Select(s => new SittingDto
                {
                    Id = s.Id,
                    Start = s.Start,
                    Duration = s.Duration,
                    Capacity = s.Capacity,
                    Interval = s.Interval,
                    Cutoff = s.Cutoff,
                    IsOpen = s.IsOpen,
                    SittingTypeDescription = s.SittingType.Description,
                    SittingTypeId = s.SittingType.Id,
                    TotalGuests = s.TotalGuests,
                    GroupId = s.GroupId
                })
                .ToListAsync();
            return warning;
        }


        [HttpGet]
        [Route("any-capacity-warnings")]
        public ActionResult<bool> AnyCapacityWarnings()
        {
            var warning = _context.Sittings
                .Include(s => s.Reservations)
                    .ThenInclude(r => r.ReservationStatus)
                .FirstOrDefault(s => s.Start.Date >= DateTime.UtcNow.Date && s.IsOpen == true && s.Reservations.Sum(r => r.ReservationStatus.Description == "Cancelled" ? 0 : r.NoOfGuests) >= s.Capacity * 0.9);
               
            return warning is null?false:true;
        }

    }
}
