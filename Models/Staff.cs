namespace Formula.Models
{
    public class Staff
    {
        public int StaffId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime Birthday { get; set; }
        public char Gender { get; set; }
        public string Job { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
