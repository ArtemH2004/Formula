using System.ComponentModel.DataAnnotations;

namespace Formula.Models
{
    public class TrackViewModel
    {
        public int TrackId { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int RaceId { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
