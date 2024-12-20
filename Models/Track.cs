namespace Formula.Models
{
    public class Track
    {
        public int TrackId { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public string Address { get; set; }
        public byte[]? Photo { get; set; }
        public int RaceId { get; set; }
        public Race Race { get; set; }
    }
}
