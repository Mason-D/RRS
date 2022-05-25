using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RRS.Data;
using RRS.Areas.Admin.Models.Employee;

namespace RRS.Areas.Admin.Controllers
{
    public class EmployeeController : AdminAreaController
    {

        public EmployeeController(ApplicationDbContext context, UserManager<IdentityUser> userManager) : base(context, userManager)
        {
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _context.Employee.ToListAsync();

            return View();
        }




        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM m)
        {
           if(!ModelState.IsValid)
            {
                return View(m);
            }


            var user = new IdentityUser { UserName = m.Email, Email = m.Email };
            var result = await _userManager.CreateAsync(user, m.Password);
        //maybe remove i am sure this is bad practice
            user.EmailConfirmed = true;

            _context.Add(new Employee
            {
                FirstName = m.FirstName,
                LastName = m.LastName,
                PhoneNumber = m.PhoneNumber,
                Address = m.Address,
                TaxFileNumber = m.TaxFileNumber,
                HireDate = new DateTime(),
                Email = m.Email,
                UserId = user.Id,
                RestaurantId = 1
            });

            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Employee");
                _context.SaveChanges();
                return (RedirectToAction("Index", "Employee", new { area = "Admin" }));
            }
            return View(m);
        }


    }
}
