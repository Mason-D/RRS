namespace RRS.Data
{
    public class Table
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Seats { get; set; }
        public int AreaId { get; set; }
        public Area Area { get; set; }
    }
}
