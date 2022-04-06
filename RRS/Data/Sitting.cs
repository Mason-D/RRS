namespace RRS.Data
{
    public class Sitting
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public int Duration { get; set; }
        public DateTime End { get => Start.AddMinutes(Duration);  }
        public bool IsOpen { get; set; }
        public int Capacity { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public List<Reservation> Reservations { get; set; }

    }
}
