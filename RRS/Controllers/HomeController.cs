using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RRS.Models;
using System.Diagnostics;

namespace RRS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        protected readonly RoleManager<IdentityRole> _roleManager;
        protected readonly UserManager<IdentityUser> _userManager;
        public HomeController(ILogger<HomeController> logger, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            if(_roleManager.Roles.Count() == 0)
            {
                await Task.Run(() => CreateRoles());
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        private async Task CreateRoles()
        {
            bool roleCheck = await _roleManager.RoleExistsAsync("God");
            if (!roleCheck)
            {
                var role = new IdentityRole();
                role.Name = "God";
                await _roleManager.CreateAsync(role);
            }
            roleCheck = await _roleManager.RoleExistsAsync("Manager");
            if (!roleCheck)
            {
                var role = new IdentityRole();
                role.Name = "Manager";
                await _roleManager.CreateAsync(role);
            }
            roleCheck = await _roleManager.RoleExistsAsync("Employee");
            if(!roleCheck)
            {
                var role = new IdentityRole();
                role.Name = "Employee";
                await _roleManager.CreateAsync(role);
            }
            roleCheck = await _roleManager.RoleExistsAsync("Customer");
            if (!roleCheck)
            {
                var role = new IdentityRole();
                role.Name = "Customer";
                await _roleManager.CreateAsync(role);
            }
            var user = new IdentityUser { UserName = "God@gmail.com", Email = "God@gmail.com" };
            user.EmailConfirmed = true;
            await _userManager.CreateAsync(user, "qwe");
            await _userManager.AddToRoleAsync(user, "God");
        }

    }
}