using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RRS.Data;

namespace RRS.Areas.Admin.Controllers
{
    public class HomeController : AdminAreaController
    {
        public HomeController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
            : base(context, userManager)
        {

        }
        public IActionResult Index()
        {
            return View();
        }

    }
}
