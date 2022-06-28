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

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult CustomNotFound()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult BeanError()
        {
            return View();
        }


        private async Task CreateRoles()
        {

            string[] roles = { "God", "Manager", "Employee", "Member" };

            foreach(var r in roles )
            {
                var role = new IdentityRole();
                role.Name = r;
                await _roleManager.CreateAsync(role);
                var user = new IdentityUser { UserName = $"{r}@gmail.com", Email = $"{r}@gmail.com" };
                user.EmailConfirmed = true;
                await _userManager.CreateAsync(user, "123");
                await _userManager.AddToRoleAsync(user, r);
            }

        }

    }
}