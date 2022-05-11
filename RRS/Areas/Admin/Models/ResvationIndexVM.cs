namespace RRS.Areas.Admin.Models
{
    public class EditReservationVM
    {
        public int ReservationId { get; set; }
        public int NoOfGuests { get; set; }
        public int CustomerId { get; set; }
        public int SittingId { get; set; }
        public int ReservationStatusId { get; set; }
        public int ReservationOriginId { get; set; }
        public string CustomerNotes { get; set; }

    }
}
