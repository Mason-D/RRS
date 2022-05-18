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
    }
}
