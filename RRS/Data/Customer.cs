namespace RRS.Data
{
    public class Customer : Person
    {
        public List<Reservation> Reservations { get; set; }
        public bool IsAVIP { get; set; }
        public bool IsNotAVIP { get; set; }
        public string Hello1 = "Yo";
        public string Hello2 = "Hello from Atif!";
        public int something { get; set; }
        public int number1 = 123;
        public int number2 = 456;    }
}
