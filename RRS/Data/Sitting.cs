namespace RRS.Data
{
    public class Sitting
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public int Duration { get; set; }
        public DateTime End { get => Start.AddMinutes(Duration); }
        public bool IsOpen { get; set; }
        public int Capacity { get; set; }
        public Guid GroupId { get; set; } = Guid.Empty;
        public int Interval { get; set; } //Gap between reservations
        public int Cutoff { get; set; } //How long before sitting ends should reservations not be accepted
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public int SittingTypeId { get; set; }
        public SittingType SittingType { get; set; }
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
        public int TotalGuests => Reservations.Sum(r => r.ReservationStatus.Description=="Cancelled"? 0 : r.NoOfGuests);
    }
}
