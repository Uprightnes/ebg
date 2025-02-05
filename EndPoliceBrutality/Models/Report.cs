namespace EndPoliceBrutality.Models
{
    public class Report
    {
        public int Id { get; set; }
        public int UserId { get; set; } // Foreign Key
        public int ReportTypeId { get; set; }
        public int? AssignedToId { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } = "Pending"; // Default value
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;


        public int? PoliceStationId { get; set; }

       

        // Navigation property
        public User User { get; set; }
        public ReportType ReportType { get; set; }
        public PoliceStation PoliceStation { get; set; }
        public User AssignedTo { get; set; }
        public ICollection<Evidences> Evidences{ get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<Escalation> Escalations { get; set; }
        public WhistleblowerProtection WhistleblowerProtection { get; set; }
    }
}
