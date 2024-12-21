using System.ComponentModel.DataAnnotations;

namespace Formula.Models
{
    public class TeamViewModel
    {
        public int TeamId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public int RaceId { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
