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
            

            var reservation = new Reservation
            {
                CustomerNotes = resDTO.CustomerNotes,
                NoOfGuests = resDTO.NoOfGuests,
                SittingId = resDTO.SittingId,
                ReservationOriginId = resDTO.ReservationOriginId,
                ReservationStatusId = 1,
                Customer = (Customer) customer,
            };

            await _context.Reservations
                .AddAsync(reservation);

            await _context.SaveChangesAsync();

            resDTO.ReferenceNo = reservation.Id;

            return resDTO;
        }
    }
}
