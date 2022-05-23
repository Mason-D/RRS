using RRS.Data;
using System.ComponentModel.DataAnnotations;

namespace RRS.Areas.Member.Data
{
    public class ProfileVM
    {
        //Change password
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        //Change Phone Number
        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        //Readonly reservations
        public List<Reservation>? UpcomingReservations { get; set; }
        public List<Reservation>? PastReservations { get; set; }
    }
}
