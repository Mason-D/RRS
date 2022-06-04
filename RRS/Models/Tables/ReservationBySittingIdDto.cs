namespace RRS.Models.Tables
{
    public class ReservationBySittingIdDto
    {
        public int Id { get; set; }
        public int? ReferenceNo { get; set; }
        public int NoOfGuests { get; set; }
        public string ReservationStatus { get; set; }
        public string CustomerNotes { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string StartTime { get; set; }
        public int? tableId { get; set; }
    }
}
