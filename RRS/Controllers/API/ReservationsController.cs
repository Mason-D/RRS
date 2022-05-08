using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public ReservationDto Create(ReservationDto resDTO)
        {
            //var customer = findOrCreateCustomer(resDTO);
            var customer = _personService.FindOrCreatePerson<Customer>(
                resDTO.FirstName, resDTO.LastName, resDTO.Email, resDTO.PhoneNumber, resDTO.RestaurantId);

            var reservation = new Reservation
            {
                CustomerNotes = resDTO.CustomerNotes,
                NoOfGuests = resDTO.NoOfGuests,
                SittingId = resDTO.SittingId,
                ReservationOriginId = resDTO.ReservationOriginId,
                ReservationStatusId = 1,
                Customer = (Customer) customer,
                CustomerId = customer.Id
            };

            _context.Reservations
                .Add(reservation);

            _context.SaveChanges();

            resDTO.ReferenceNo = reservation.Id;

            return resDTO;
        }

        //private Customer findOrCreateCustomer(ReservationDto resDto)
        //{
        //    var customer = _context.People.Where(p => p.Email == resDto.Email).ToList();

        //    return customer.Count > 0 ? 
        //        (Customer) customer.First()
        //        : new Customer
        //        {
        //            FirstName = resDto.FirstName,
        //            LastName = resDto.LastName,
        //            Email = resDto.Email,
        //            PhoneNumber = resDto.PhoneNumber,
        //            RestaurantId = resDto.RestaurantId
        //        };
        //}


    }
}
