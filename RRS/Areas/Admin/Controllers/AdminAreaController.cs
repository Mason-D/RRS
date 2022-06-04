using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RRS.Data;

namespace RRS.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "Employee , God")]
    public class AdminAreaController : Controller
    {

        protected readonly ApplicationDbContext _context;
        protected readonly UserManager<IdentityUser> _userManager;
        
        public AdminAreaController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
    }
}
