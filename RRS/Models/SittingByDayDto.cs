namespace RRS.Models
{
    public class SittingByDayDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Duration { get; set; }
        public string Start { get; set; }
        public int Capacity { get; set; }
        public int TotalGuests { get; set; }
    }
}
