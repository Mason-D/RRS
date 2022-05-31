using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RRS.Areas.Member.Data;
using RRS.Data;

namespace RRS.Areas.Member.Controllers
{
    public class HomeController : MemberAreaController
    {
        public HomeController(
            ApplicationDbContext context, 
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        : base(context, userManager, signInManager)
        {

        }

        public async Task<IActionResult> Index()
        {           
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return View("/Views/Shared/BeanError.cshtml", "");
                //return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            var hasPassword = await _userManager.HasPasswordAsync(user);
            if (!hasPassword)
            {
                return RedirectToPage("./SetPassword");
            }

            var currentDate = DateTime.Now;
            var reservations = getUserReservations(user.Id).Result;

            var past = reservations.Where(r => r.Sitting.Start < currentDate).ToList();
            var upcoming = reservations.Where(r => r.Sitting.Start >= currentDate).ToList();

            return View(new ProfileVM { PastReservations = past, UpcomingReservations = upcoming, PhoneNumber = phoneNumber});
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDetails(ProfileVM profile)
        {           
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                //return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
                return View("/Views/Shared/BeanError.cshtml");
            }

            //Maintain reservations state
            var currentDate = DateTime.Now;
            var reservations = getUserReservations(user.Id).Result;
            ViewData["phoneNumber"] = await _userManager.GetPhoneNumberAsync(user);
            ViewData["past"] = reservations.Where(r => r.Sitting.Start < currentDate).ToList();
            ViewData["upcoming"] = reservations.Where(r => r.Sitting.Start >= currentDate).ToList();

            if (!ModelState.IsValid)
            {
                return View("Index", profile);
            }

            var phoneNumber = ViewData["phoneNumber"] as string;
            if (profile.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, profile.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    return View("Index", profile);
                }
            }

            if (profile.OldPassword != null && profile.NewPassword != null)
            {
                var changePasswordResult = await _userManager.ChangePasswordAsync(user, profile.OldPassword, profile.NewPassword);
                if (!changePasswordResult.Succeeded)
                {
                    foreach (var error in changePasswordResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View("Index", profile);
                }
            }

            await _signInManager.RefreshSignInAsync(user);

            return View("Index", profile);
        }

        private async Task<List<RRS.Data.Reservation>> getUserReservations(string userId)
        {
            var customer = await _context.People.Where(p => p.UserId == userId).FirstOrDefaultAsync();

            if (customer == null)
            {
                return null;
            }

            return await _context.Reservations
                                        .Include(r => r.Customer)
                                        .Where(r => r.CustomerId == customer.Id)
                                        .Include(r => r.Sitting)
                                            .ThenInclude(s => s.SittingType)
                                        .Include(r => r.ReservationOrigin)
                                        .Include(r => r.ReservationStatus)
                                        .ToListAsync();
        }
    }
}
