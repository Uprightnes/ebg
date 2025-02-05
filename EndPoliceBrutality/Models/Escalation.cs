using System.Globalization;

namespace EndPoliceBrutality.Models
{
    public class Escalation
    {
        public int Id { get; set; }
        public int EscalatedToId     { get; set; }
        public int ReportId { get; set; }
        public String Reason { get; set; }
        public DateTime EscalatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public Report Report { get; set; } // Relationship to Report
        public User EscalatedTo { get; set; } // Relationship to User

    }
}
