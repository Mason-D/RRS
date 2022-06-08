using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RRS.Data;
using RRS.Models;
using RRS.Services;
using System.Linq;

namespace RRS.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        protected readonly UserManager<IdentityUser> _userManager;
        //private readonly IUserService _userService;

        public PersonsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)//IUserService userService
        {
            _context = context;
            _userManager = userManager;
            //_userService = userService;
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

            var userId = _userManager.GetUserId(HttpContext.User);

            var email = _context.Users
                .Where(u => u.Id == userId)
                .Select(u => u.Email).ToString();

            return _context.Customers
                .Where(c => c.Email == email)
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
