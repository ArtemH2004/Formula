using System.ComponentModel.DataAnnotations;

namespace Formula.Models
{
    public class RaceViewModel
    {
        public int RaceId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int StageNumber { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int AudienceCount { get; set; }
        [Required]
        public string Result { get; set; }
        [Required]
        public string Weather { get; set; }
        [Required]
        public int TrackId { get; set; }
    }
}
