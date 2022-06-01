using RRS.Data;

namespace RRS.Models
{
    public class CustomerReservationDto
    {
        public List<ResVM> Upcoming { get; set; } = new List<ResVM>();
        public List<ResVM> Past { get; set; } = new List<ResVM>();
    }

    public class ResVM
    {
        public int ReferenceNo { get; set; }
        public int NoOfGuests { get; set; }
        public string? CustomerNotes { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime StartTime { get; set; }
        public string Time => StartTime.ToShortTimeString();
        public string Date => StartTime.ToString("D");
        public string Status { get; set; }
        public string Origin { get; set; }
        public string Type { get; set; }
    }
}
