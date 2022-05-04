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
        public ActionResult<IEnumerable<SittingDto>> Available(DateTime start, DateTime end = new DateTime())
        {
            var startLocal = start.ToLocalTime();
            var endLocal = end == new DateTime() ? startLocal.AddMonths(3) : end.ToLocalTime();

                return _context.Sittings
                            .Where(s => s.IsOpen
                                        && s.Start >= startLocal
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

        [HttpGet]
        [Route("distinct-available/{start}/{end?}")]
        public ActionResult<Dictionary<int, List<int>>> DistinctAvailable(DateTime start, DateTime end = new DateTime())
        {          
            var startLocal = start.ToLocalTime();
            var endLocal = end == new DateTime() ? startLocal.AddMonths(3) : end.ToLocalTime();
            var dict = new Dictionary<int, List<int>>();

            var sittings = _context.Sittings
                        .Where(s => s.IsOpen
                                    && s.Start >= startLocal
                                    && s.Start < endLocal)
                        .Select(s => new { Month = s.Start.Month, Day = s.Start.Day })
                        .ToList();

            foreach (var sitting in sittings)
            {
                if (dict.ContainsKey(sitting.Month))
                {
                    if (!dict[sitting.Month].Contains(sitting.Day))
                    {
                        dict[sitting.Month].Add(sitting.Day);
                    }
                }
                else
                {
                    dict.Add(sitting.Month, new List<int>());
                    dict[sitting.Month].Add(sitting.Day);
                }
            }

            return dict;
        }

        [HttpGet]
        [Route("day-types/{date}")]
        public ActionResult<IEnumerable<SittingByDayDto>> DayTypes(DateTime date)
        {
            var dateLocal = date.ToLocalTime();

            return _context.Sittings
                        
                        .Where(s => s.IsOpen
                                && s.Start.Date == dateLocal.Date)
                        .Select(s => new SittingByDayDto { Id = s.Id, Type = s.SittingType.Description, Duration = s.Duration})
                        .ToList();
        }

        // Returns all sittings in day
        //[HttpGet]
        //[Route("available-by-day/{date}")]
        //public ActionResult<IEnumerable<Sitting>> AvailableByDay(DateTime date)
        //{
        //    return _context.Sittings
        //        .Where(s => s.IsOpen && s.Start == date)
        //        .ToList();
        //}
    }
}
