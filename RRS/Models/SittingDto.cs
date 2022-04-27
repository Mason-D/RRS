namespace RRS.Models
{
    public class SittingDto
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public int Duration { get; set; }
        public DateTime End { get => Start.AddMinutes(Duration); }
        public bool IsOpen { get; set; }
        public int Capacity { get; set; }
        public string SittingTypeDescription { get; set; }
    }
}
