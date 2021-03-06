using System.ComponentModel.DataAnnotations;

namespace RRS.Models
{
    public class SittingDto
    {
        [Range(1, uint.MaxValue, ErrorMessage = "Id must be a valid number")]
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public int Year { get => Start.Year; }
        public int Month { get => Start.Month; }
        public int Day { get => Start.Day; }
        [Range(1, uint.MaxValue, ErrorMessage = "Duration must be atleast one minute")]
        public int Duration { get; set; }
        public bool IsOpen { get; set; }
        [Range(1, uint.MaxValue, ErrorMessage = "Capacity must be for atleast one person")]
        public int Capacity { get; set; }
        public int SittingTypeId { get; set; }
        public string? SittingTypeDescription { get; set; }
        public int TotalGuests { get; set; }
        [Range(5, uint.MaxValue, ErrorMessage = "Interval between reservations must be atleast five minutes")]
        public int Interval { get; set; }
        [Range(0, uint.MaxValue, ErrorMessage = "Cutoff must be zero or higher")]
        public int Cutoff { get; set; }
        public Guid GroupId { get; set; }
        public bool SelectAllGroupId { get; set; } = false;
    }
}
