using System.ComponentModel.DataAnnotations;

namespace Formula.Models
{
    public class ManagerViewModel
    {
        public int ManagerId { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public int Percent { get; set; }
        [Required]
        public int TeamId { get; set; }
    }
}
