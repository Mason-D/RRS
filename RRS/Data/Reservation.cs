namespace RRS.Data
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public int Duration { get; set; }
        public DateTime End { get => Start.AddMinutes(Duration); }
        public int TotalPeople { get; set; }
        public int SittingId { get; set; }
        public Sitting Sitting { get; set; }
        public int ReservationStatusId { get; set; }
        public ReservationStatus ReservationStatus { get; set; }
        public int ReservationOriginId { get; set; }
        public ReservationOrigin ReservationOrigin { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
