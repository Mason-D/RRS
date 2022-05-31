using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RRS.Data;
using RRS.Areas.Admin.Models.Employee;
using System.Security.Claims;

namespace RRS.Areas.Admin.Controllers
{
    public class EmployeeController : AdminAreaController
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public EmployeeController(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager) : base(context, userManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            List<Employee> employees = await _context.Employee.ToListAsync();
            return View(employees);
        }


        //[HttpPost]
        //public async Task<IActionResult> Index(int id)
        //{
        //    return View();
        //}

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM m)
        {
            if (!ModelState.IsValid)
            {
                return View(m);
            }


            var user = new IdentityUser { UserName = m.Email, Email = m.Email };
            var result = await _userManager.CreateAsync(user, m.Password);
            // remove i am sure this is bad practice
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

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Employee");
                _context.SaveChanges();
                return (RedirectToAction("Index", "Employee", new { area = "Admin" }));
            }
            return View(m);
        }




        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var Employee = await _context.Employee.Where(e => e.Id == id).FirstOrDefaultAsync();
            var user =  await _userManager.FindByIdAsync(Employee.UserId);
            

            return View(Employee);
        }

        [HttpPost]
        public IActionResult Edit()
        {
            return View();
        }
    }
}
