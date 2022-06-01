namespace RRS.Data
{
    public class ReservationTable
    {
        public int id { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
        public int TableId { get; set; }
        public Table Table { get; set; }

    }
}
