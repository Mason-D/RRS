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
    public class PersonsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PersonsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("find-people/{data}")]
        public async Task<ActionResult<IEnumerable<PersonDto>>> FindPeople(string data)
        {
            return await _context.Customers
                .Where(c => (c.FirstName+c.LastName).Replace(" ", string.Empty).Contains(data))
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

    }
}
