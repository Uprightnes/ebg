namespace EndPoliceBrutality.Models
{
    public class PoliceStation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public int PoliceStationId { get; set; }
        public string LGA { get; set; }
        public string Area { get; set; }


        public ICollection<Report> Reports { get; set; }
    }
}
