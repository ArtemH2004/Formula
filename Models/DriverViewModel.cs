using System.ComponentModel.DataAnnotations;

namespace Formula.Models
{
    public class DriverViewModel
    {
        public int DriverId { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public char Gender { get; set; }
        [Required]
        public int PodiumCount { get; set; }
        [Required]
        public int TeamId { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
