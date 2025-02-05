namespace EndPoliceBrutality.Models
{
    public class ReportType
    {
        public int Id { get; set; }

        public string Type { get; set; }
        public string Description { get; set; }

        public ReportType ReportTypes { get; set; }
        public ICollection<Report> Reports { get; set; }
        
    }
}
