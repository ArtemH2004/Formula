namespace Formula.Models
{
    public class Manager
    {
        public int ManagerId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Type {  get; set; }
        public int Percent { get; set; }
        public int TeamId { get; set; }
    }
}
