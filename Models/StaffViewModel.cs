using System.ComponentModel.DataAnnotations;

namespace Formula.Models
{
    public class StaffViewModel
    {
        public int StaffId { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public char Gender { get; set; }
        [Required]
        public string Job { get; set; }
        [Required]
        public int TeamId { get; set; }
    }
}
