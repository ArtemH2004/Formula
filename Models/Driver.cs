namespace Formula.Models
{
    public class Driver
    {
        public int DriverId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime Birthday { get; set; }
        public char Gender { get; set; }
        public int PodiumCount { get; set; }
        public byte[]? Photo { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
