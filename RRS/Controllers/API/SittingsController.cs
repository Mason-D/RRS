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
        [Route("all")]
        public ActionResult<IEnumerable<SittingDto>> All()
        {
            return _context.Sittings
                        .Where(s => s.IsOpen)
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
        [Route("available/{year}-{month}-{day}")]
        //HACK, use iso-string
        public ActionResult<IEnumerable<SittingDto>> Available(int year, int month, int day)
        {
            var startDate = new DateTime(year, month, day);
            var endDate = startDate.AddDays(29); //Excludes sittings on 29th day

            return _context.Sittings
                        .Where(s => s.IsOpen)
                        .Where(s => DateTime.Compare(s.Start, startDate) >= 0 && DateTime.Compare(s.Start, endDate) <= 0)
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
        [Route("available-soon/{earliest}")]
        //NOT IMPLEMENTED
        public ActionResult<IEnumerable<SittingDto>> AvailableSoon(DateTime earliest)
        {
            return _context.Sittings
                        .Where(s => s.IsOpen)
                        .Where(s => isAvailableSoon(s.Start, earliest))
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

        private bool isAvailableSoon(DateTime sitting, DateTime earliest)
        {
            return sitting >= earliest
                && sitting.Year == earliest.Year 
                && (sitting.Month == earliest.Month || sitting.Month == earliest.Month + 1);
        }

        // Returns all days in month that have any open sittings 
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
