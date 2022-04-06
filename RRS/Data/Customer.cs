namespace RRS.Data
{
    public class Customer : Person
    {
        public List<Reservation> Reservations { get; set; }
        public bool IsVIP { get; set; }
    }
}
