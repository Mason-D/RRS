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

        [HttpGet]
        //[Route("AddReservation/")]
        public Task<IActionResult> AddReservation()
        {

            return null;
        }

        [HttpPost]
        //[Route("RemoveReservation")]

        public Task<IActionResult> RemoveResevation()
        {
            return null;
        }



        [HttpGet]
        [Route("area/{id}")]
        public async Task<ActionResult<IEnumerable<TablesDto>>> Area(int id)
        {

            var result =  await _context.Tables
                .Where(t => t.AreaId == id)
                .Select(t => new TablesDto 
                { 
                    Id=t.Id, 
                    AreaId = t.AreaId, 
                    Description=t.Description
                })
                .ToListAsync();



            return result;
        }


    }
}
