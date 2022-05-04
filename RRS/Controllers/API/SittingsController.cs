using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<IEnumerable<SittingDto>> Available(DateTime start, DateTime end)
        {
            //Consider giving end a default value of e.g., start + 3 months to limit excess data.
            var startLocal = start.ToLocalTime();

            if (end == new DateTime()) // Get 'All' available sittings
            {
                return _context.Sittings
                            .Where(s => s.IsOpen
                                        && s.Start > startLocal)
                            .Select(s => new SittingDto
                            {
                                Id = s.Id,
                                Start = s.Start,
                                Duration = s.Duration,
                                Capacity = s.Capacity,
                                IsOpen = s.IsOpen,
                                SittingTypeDescription = s.SittingType.Description
                            })
                            .ToList();
            }
            else // Get sittings within start <-> end range
            {
                var endLocal = end.ToLocalTime();

                return _context.Sittings
                            .Where(s => s.IsOpen)
                            .Where(s => s.Start >= startLocal
                                        && s.Start < endLocal)
                            .Select(s => new SittingDto
                            {
                                Id = s.Id,
                                Start = s.Start,
                                Duration = s.Duration,
                                Capacity = s.Capacity,
                                IsOpen = s.IsOpen,
                                SittingTypeDescription = s.SittingType.Description
                            })
                            .ToList();
            }
        }

        [HttpGet]
        [Route("distinct-available/{start}/{end?}")]
        public ActionResult<IEnumerable<DistinctDto>> DistinctAvailable(DateTime start, DateTime end)
        {          
            var startLocal = start.ToLocalTime();

            if (end == new DateTime()) // Get 'All' distinct available sittings
            {
                
                var temp = _context.Sittings
                            .Where(s => s.IsOpen
                                        && s.Start > startLocal)
                            .GroupBy(s => s.Start.Month)
                            .Select(s => new DistinctDto { })
                            .ToList();

                            //                .Select(s => new DistinctDto
                            //                 {
                            //                     Month = s.Start.Month,
                            //                     Day = s.Start.Day
                            //                 })
                            //.Distinct()
                return null;
            }
            else // Get distinct available sittings within start <-> end range
            {
                var endLocal = end.ToLocalTime();

                return _context.Sittings
                            .Where(s => s.IsOpen)
                            .Where(s => s.Start >= startLocal
                                        && s.Start < endLocal)
                            .Select(s => new DistinctDto
                            {

                            })
                            .ToList();
            }

            //var distinctMonths = 
            //_context.Sittings
            //    .Where(s => s.IsOpen && s.Start.Month == month)
            //    .Select(s => s.Start.Date)
            //    .Distinct()
            //    .ToList();

            return null;
        }

        [HttpGet]
        [Route("day-types/{date}")]
        public ActionResult<IEnumerable<SittingByDayDto>> DayTypes(DateTime date)
        {
            return _context.Sittings
                        
                        .Where(s => s.IsOpen
                                && s.Start.Date == date.Date)
                        .Select(s => new SittingByDayDto { Id = s.Id, Type = s.SittingType.Description, Duration = s.Duration , Start = s.Start.ToString("HH:mm")})
                        .ToList();
        }

        // Returns all sittings in day
        [HttpGet]
        [Route("available-by-day/{date}")]
        public ActionResult<IEnumerable<Sitting>> AvailableByDay(DateTime date)
        {
            return _context.Sittings
                .Where(s => s.IsOpen && s.Start == date)
                .ToList();
        }
    }
}
