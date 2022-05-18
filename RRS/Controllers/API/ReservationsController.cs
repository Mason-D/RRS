using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RRS.Data;
using RRS.Models;
using RRS.Services;

namespace RRS.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly PersonService _personService;

        public ReservationsController(ApplicationDbContext context, PersonService personService)
        {
            _context = context;
            _personService = personService;
        }

        [HttpPost]
        //[ValidateAntiForgeryToken] //- Token blocks requests from 'Make Reservation' SPA on seperate server
        public async Task<ReservationDto> Create(ReservationDto resDTO)
        {
            var obj = _personService.FindOrCreatePerson<Customer>(
                new PersonVM
                {
                    Email = resDTO.Email,
                    FirstName = resDTO.FirstName,
                    LastName = resDTO.LastName,
                    PhoneNumber = resDTO.PhoneNumber,
                    RestaurantId = resDTO.RestaurantId
                });

            //Unpack anonymous object
            Type type = obj.GetType();
            var customer = (Person)type.GetProperty("Person").GetValue(obj, null);


            var customerTemp = (Customer)customer;
            

            var reservation = new Reservation
            {
                CustomerNotes = resDTO.CustomerNotes,
                NoOfGuests = resDTO.NoOfGuests,
                SittingId = resDTO.SittingId,
                ReservationOriginId = resDTO.ReservationOriginId,
                ReservationStatusId = 1,
                Customer = customerTemp,
                CustomerId = customerTemp.Id,
                StartTime = resDTO.StartTime
            };

            await _context.Reservations
                .AddAsync(reservation);

            await _context.SaveChangesAsync();

            resDTO.ReferenceNo = reservation.Id;

            return resDTO;
        }


        [HttpGet]
        [Route("any/{start}/{end?}")]
        public async Task<ActionResult<IEnumerable<ReservationDto>>> Any(DateTime start, DateTime end = new DateTime())
        {
            var startLocal = start;
            var endLocal = end == new DateTime() ? startLocal : end;

            return await _context.Reservations
                            .Include(r => r.Customer)
                            .Include(r => r.ReservationOrigin)
                            .Include(r => r.ReservationStatus)
                            .Include(r => r.Sitting)
                                .ThenInclude(s => s.SittingType)
                            //Change to res Start Time
                            //.Where(r => r.StartTime >= startLocal.Date && r.StartTime <= endLocal.Date.AddDays(1))
                            .Where(r => r.Sitting.Start.Date >= startLocal.Date && r.Sitting.Start.Date <= endLocal.Date)
                            .OrderBy(r => r.StartTime)
                            //.AsNoTracking()
                            .Select(r => new ReservationDto
                            {
                                ReferenceNo = r.Id,
                                NoOfGuests = r.NoOfGuests,
                                SittingId = r.SittingId,
                                ReservationOriginId = r.ReservationOriginId,
                                CustomerNotes = r.CustomerNotes,
                                FirstName = r.Customer.FirstName,
                                LastName = r.Customer.LastName,
                                PhoneNumber = r.Customer.PhoneNumber,
                                Email = r.Customer.Email,
                                RestaurantId = r.Sitting.RestaurantId,
                                StartTime = r.StartTime,
                                ResStatus = r.ReservationStatus.Description,
                                ResOrigin = r.ReservationOrigin.Description,
                                ResType = r.Sitting.SittingType.Description

                            })
                            .ToListAsync();
        }
    }
}
