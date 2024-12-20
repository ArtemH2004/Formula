namespace Formula.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public byte[]? Photo { get; set; }
        public ICollection<Driver> Drivers { get; set; } = new List<Driver>();
        public ICollection<Manager> Managers { get; set; } = new List<Manager>();
        public ICollection<Staff> Staffs { get; set; } = new List<Staff>();
        public int RaceId { get; set; }
        public Race Race { get; set; }

    }
}
