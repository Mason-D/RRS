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
        // Programmatically get current date. 
        public ActionResult<IEnumerable<SittingDto>> Available(DateTime start, DateTime end)
        {
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
        [Route("distinct-available/{month}")]
        public ActionResult<IEnumerable<DateTime>> DistinctAvailable(int month)
        {
            return _context.Sittings
                .Where(s => s.IsOpen && s.Start.Month == month)
                .Select(s => s.Start.Date)
                .Distinct()
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
