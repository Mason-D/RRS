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
            ReservationTable reservation =  _context.ReservationTables.Where(rt => rt.TableId == tableId && rt.ReservationId == resId).FirstOrDefault();
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
        [Route("available-dates/{start}")]
        public async Task<ActionResult<IEnumerable<DateTime>>> AvailableDates(DateTime start = new DateTime())
        {
            var available = await _context.Sittings
                .Where(s => s.Start >= start)
                .Select(s => s.Start.Date)
                .ToListAsync();

            return available;
        }

    }
}
