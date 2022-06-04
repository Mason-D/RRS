namespace RRS.Models.Tables
{
    public class TablesDto
    {
        public int Id { get; set; } 
        public string Description { get; set; }
        public int AreaId { get; set; }
        public int[]? ReservationId { get; set; }
    }
}
