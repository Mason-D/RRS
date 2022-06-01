using System.ComponentModel.DataAnnotations;
namespace RRS.Models
{
    public class ReservationEditDto
    {
        public int Id { get; set; }
        [Range(1, 1000, ErrorMessage = "Number of guests must be a valid number")]
        public int NoOfGuests { get; set; }
        public int CustomerId { get; set; }
        public int SittingId { get; set; }
        public int ReservationStatusId { get; set; }
        public int ReservationOriginId { get; set; }
        public string? CustomerNotes { get; set; }
        public DateTime StartTime { get; set; }

    }
}
