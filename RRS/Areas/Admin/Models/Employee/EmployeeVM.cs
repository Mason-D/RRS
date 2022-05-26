using System.ComponentModel.DataAnnotations;

namespace RRS.Areas.Admin.Models.Employee
{
    public class EmployeeVM
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Phone")]
        public string  PhoneNumber { get; set; }
        public string Email { get; set; }


    }
}
