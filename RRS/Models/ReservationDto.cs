namespace RRS.Models
{
    public class ReservationDto
    {
        public int? ReferenceNo { get; set; }
        public int NoOfGuests { get; set; }
        public int SittingId { get; set; }
        public int ReservationOriginId { get; set; }
        public string CustomerNotes { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int RestaurantId { get; set; }
        public DateTime StartTime { get; set; }
    }
}
