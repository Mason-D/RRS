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
        public int Duration { get; set; }
        public bool IsOpen { get; set; }
        public int Capacity { get; set; }
        public int SittingTypeId { get; set; }
        public string? SittingTypeDescription { get; set; }
    }
}
