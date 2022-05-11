using RRS.Data;

namespace RRS.Areas.Admin.Models.Sittings
{
    public class SittingsVm
    { 
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public int Duration { get; set; }
        public DateTime End { get => Start.AddMinutes(Duration); }
        public bool IsOpen { get => true; }
        public int Capacity { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public int SittingTypeId { get; set; }
        public SittingType SittingType { get; set; }
        public int Interval { get; set; }
        public int CutOff { get; set; }
        public bool Group { get; set; }
        public string  NewSittingName { get; set; }

    }
}
