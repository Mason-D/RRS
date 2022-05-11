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

        public List<Reservation>? UpcomingReservations { get; set; }
        public List<Reservation>? PastReservations { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {

        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var currentDate = DateTime.Now;
            var customer = await _context.People.Where(p => p.UserId == user.Id).FirstOrDefaultAsync();
            var reservations = await _context.Reservations
                .Include(r => r.Customer)
                .Where(r => r.CustomerId == customer.Id)
                .Include(r => r.Sitting)
                    .ThenInclude(s => s.SittingType)
                .Include(r => r.ReservationOrigin)
                .Include(r => r.ReservationStatus)
                .ToListAsync();

            var past = reservations.Where(r => r.Sitting.Start < currentDate).ToList();
            var upcoming = reservations.Where(r => r.Sitting.Start >= currentDate).ToList();

            PastReservations = past;
            UpcomingReservations = upcoming;

            return Page();
        }


    }
}
