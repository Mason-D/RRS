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
        private readonly ILogger<ReservationsController> _logger;

        public ReservationsController(
            ApplicationDbContext context, 
            PersonService personService,
            ILogger<ReservationsController> logger)
        {
            _context = context;
            _personService = personService;
            _logger = logger;
        }

        [HttpPost]
        //[ValidateAntiForgeryToken] //- Token blocks requests from 'Make Reservation' SPA on seperate server
        public async Task<ReservationDto> Create(ReservationDto resDTO)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(
                    $"{System.Environment.NewLine}" +
                    $"ATOLog: {DateTime.Now}" +
                    $"{System.Environment.NewLine}" +
                    $"Endpoint: 'server/api/Reservations/resDTO'" +
                    $"{System.Environment.NewLine}" +
                    $"{ex.Message}");
                throw;

                //var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                //response.Content = new StringContent(ex.Message);
                //_logger.LogError($"Endpoint: 'server/api/Reservations/resDTO' | {ex.Message}");
                //return Task.FromResult(response);
            }
        }
    }
}
