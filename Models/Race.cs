namespace Formula.Models
{
    public class Race
    {
        public int RaceId { get; set; }
        public DateTime Date { get; set; }
        public int StageNumber { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public int AudienceCount { get; set; }
        public string Result { get; set; } // ???   mb name of win team 
        public string Weather { get; set; }
        public int TrackId { get; set; }
        public Track Track { get; set; }
        public ICollection<Team> Teams { get; set; } = new List<Team>();
    }
}
