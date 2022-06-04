using RRS.Data;
using System.ComponentModel.DataAnnotations;

namespace RRS.Areas.Admin.Models.Sittings
{
    public class SittingsVm
    { 
        public int Id { get; set; }
        public DateTime Start { get; set; }
        [Required, Display(Name ="Duration")]
        public int Duration { get; set; }
        public DateTime End { get => Start.AddMinutes(Duration); }
        public bool IsOpen { get => true; }
        [Required(ErrorMessage = "Invalid Input")]
        public  int  Hours { get; set; }
        public int Minutes { get; set; }
        [Display(Name ="Capacity"), Required]
        public int Capacity { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        [Display(Name ="Sitting Type")]
        public int SittingTypeId { get; set; }
        public SittingType SittingType { get; set; }
        public int Interval { get; set; }
        public int CutOff { get; set; }
        public string Group { get; set; }
        public DateTime EndDate { get; set; }

        [Display(Name ="New Sitting")]
        public string NewSittingName { get; set; }

        public string SelectedDays { get; set; }

    }
}
