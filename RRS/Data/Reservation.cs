namespace RRS.Data
{
    public class Reservation
    {
        public int Id { get; set; }
        public int NoOfGuests { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int SittingId { get; set; }
        public Sitting Sitting { get; set; }
        public int ReservationStatusId { get; set; }
        public ReservationStatus ReservationStatus { get; set; }
        public int ReservationOriginId { get; set; }
        public ReservationOrigin ReservationOrigin { get; set; }
        public string? CustomerNotes { get; set; }
        public DateTime StartTime { get; set; }
        public ICollection<Table> Tables { get; set; }

    }
}
