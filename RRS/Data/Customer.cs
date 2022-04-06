namespace RRS.Data
{
    public class Customer : Person
    {
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
