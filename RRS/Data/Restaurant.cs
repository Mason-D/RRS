namespace RRS.Data
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Person> People { get; set; } = new List<Person>();
        public List<Area> Areas { get; set; } = new List<Area>();
        public List<Sitting> Sittings { get; set; } = new List<Sitting>();
    }
}
