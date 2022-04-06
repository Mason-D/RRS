namespace RRS.Data
{
    public class Customer : Person
    {
        public List<Reservation> Reservations { get; set; }

        public bool IsNotAVIP { get; set; }

        public string Hello = "Hello from Atif!";
    }
}
