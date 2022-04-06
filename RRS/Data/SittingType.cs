namespace RRS.Data
{
    public class SittingType
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public List<Sitting> Sittings { get; set; } = new List<Sitting>();
    }
}
