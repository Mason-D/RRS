using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RRS.Data;

namespace RRS.Areas.Member.Controllers
{
    [Area("Member")] 
    [Authorize(Roles = "Member")]
    public class MemberAreaController : Controller
    {
        protected readonly ApplicationDbContext _context;
        protected readonly UserManager<IdentityUser> _userManager;
        protected readonly SignInManager<IdentityUser> _signInManager;

        public MemberAreaController(
            ApplicationDbContext context, 
            UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
            _context = context;
            _userManager = userManager;
        }
    }
}
