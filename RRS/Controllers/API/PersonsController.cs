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
        private readonly UserManager<IdentityUser> _userManager;

        public PersonsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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
        public async Task<IQueryable<PersonDto>> GetUser()
        {
            var userEmail = _userManager.GetUserName(HttpContext.User);
            return _context.Customers
                .Where(c => c.Email == userEmail)
                .Select(c => new PersonDto
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    PhoneNumber = c.PhoneNumber,
                    Email = c.Email
                });

        }
    }
}
