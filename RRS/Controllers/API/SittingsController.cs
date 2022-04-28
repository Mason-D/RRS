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
        public ActionResult<IEnumerable<SittingDto>> Available(int year, int month, int day)
        {
            var startDate = new DateTime(year, month, day);
            var endDate = startDate.AddDays(29); //Excludes sittings on 29th day

            return _context.Sittings
                        .Where(s => s.IsOpen)
                        .Where(s => DateTime.Compare(s.Start, startDate) >= 0 && DateTime.Compare(s.Start, endDate) <= 0 )
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
}
