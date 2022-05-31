using System.ComponentModel.DataAnnotations;

namespace RRS.Areas.Admin.Models.Employee
{
    public class RegisterVM
    {
        [Required, EmailAddress, Display(Name = "Email")]
        public string Email  { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password)]
        [Compare (nameof(Password), ErrorMessage="Passwords do not match.")]
        public string  ConfirmPassword { get; set; }
        [Required, Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required, Display(Name ="Last Name")]
        public string LastName { get; set; }
        [Required, Phone, Display(Name ="Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        public DateTime HireDate { get; set; }
        [Required, Display(Name ="Tax File Number")]
        public string TaxFileNumber { get; set; }
    }
}
