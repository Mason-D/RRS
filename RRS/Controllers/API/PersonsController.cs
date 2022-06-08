using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RRS.Data;
using RRS.Models;
using RRS.Services;

namespace RRS.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;

        public PersonsController(ApplicationDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        [HttpGet]
        [Route("find-people/{data}")]
        public async Task<ActionResult<IEnumerable<PersonDto>>> FindPeople(string data)
        {
            return await _context.Customers
                .Where(c => (c.FirstName+c.LastName).Replace(" ", string.Empty).Contains(data) || c.Email.Contains(data) || c.PhoneNumber.Contains(data))
                .Select(p => new PersonDto
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    PhoneNumber = p.PhoneNumber,
                    Email = p.Email
                })
                .ToListAsync();
        }


        [HttpGet]
        [Route("get-user")]
        public async Task<ActionResult<PersonDto>> GetUser()
        {
            if (_userService.IsAuthenticated())
            {
                var person = _context.Customers
                    .Where(c => c.Email == _userService.GetUserEmail())
                    .Select(p => new PersonDto
                    {
                        Id = p.Id,
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        PhoneNumber = p.PhoneNumber,
                        Email = p.Email
                    });
                return person;
            }
            else
            {
                return null;
            }

        }


    }
}
