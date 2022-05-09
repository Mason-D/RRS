using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RRS.Data;
using RRS.Services;

namespace RRS.Areas.Identity.Pages.Account.Manage
{
    public class ReservationsModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public ReservationsModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public List<Reservation> Reservations { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public List<Reservation>? UpcomingReservations { get; set; }
            public List<Reservation>? PastReservations { get; set; }
        }
        private async Task LoadAsync(IdentityUser user)
        {          
            var currentDate = DateTime.Now;
            var reservations = await _context.Reservations.Include(r => r.Sitting).Where(r => "93a658ff-1307-471d-a810-695a7a76587c" == user.Id).ToListAsync();
            var past = reservations.Where(r => r.Sitting.Start < currentDate).ToList();
            var upcoming = reservations.Where(r => r.Sitting.Start >= currentDate).ToList();

            Input = new InputModel
            {
                PastReservations = past,
                UpcomingReservations = upcoming
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }


    }
}
