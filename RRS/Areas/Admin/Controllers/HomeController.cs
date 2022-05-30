using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RRS.Data;

namespace RRS.Areas.Admin.Controllers
{
    public class HomeController : AdminAreaController
    {
        public HomeController(
            ApplicationDbContext context,
            UserManager<IdentityUser> userManager,
            ILogger<AdminAreaController> logger)
            : base(context, userManager, logger)
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
