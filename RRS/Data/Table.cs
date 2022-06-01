namespace RRS.Data
{
    public class Table
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int AreaId { get; set; }
        public Area Area { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
