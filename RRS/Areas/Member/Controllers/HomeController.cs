using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RRS.Data;

namespace RRS.Areas.Member.Controllers
{
    public class HomeController : MemberAreaController
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
