using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RRS.Data;
using RRS.Models;

namespace RRS.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SittingController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SittingController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SittingDto>> GetSittings()
        {
            var t2 = _context.Sittings
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

            return t2;
        }
    }
}
