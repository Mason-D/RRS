using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RRS.Data;
using RRS.Models;

namespace RRS.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReservationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Reservation/People
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

        // Reservation/Details
        [HttpPost]
        public ReservationDto CreateReservation(ReservationDto resDTO)
        {
            var customer = findOrCreateCustomer(resDTO);

            var reservation = new Reservation
            {
                CustomerNotes = resDTO.CustomerNotes,
                NoOfGuests = resDTO.NoOfGuests,
                SittingId = resDTO.SittingId,
                ReservationOriginId = resDTO.ReservationOriginId,
                ReservationStatusId = 1,
                Customer = customer,
                CustomerId = customer.Id
            };

            _context.Reservations
                .Add(reservation);

            _context.SaveChanges();

            resDTO.ReferenceNo = reservation.Id;

            return resDTO;
        }

        private Customer findOrCreateCustomer(ReservationDto resDto)
        {
            var customer = _context.People.Where(p => p.Email == resDto.Email).ToList();

            return customer.Count > 0 ? 
                (Customer) customer.First()
                : new Customer
                {
                    FirstName = resDto.FirstName,
                    LastName = resDto.LastName,
                    Email = resDto.Email,
                    PhoneNumber = resDto.PhoneNumber,
                    RestaurantId = resDto.RestaurantId
                };
        }
    }
}
