namespace EndPoliceBrutality.Models
{
    public class Notification
    {

        public int Id { get; set; }
        public int UserId { get; set; } // Foreign key for User
        public int? ReportId { get; set; } // Nullable Foreign key for Report (if applicable)
        public string Message { get; set; }
        public bool IsRead { get; set; } = false; // Renamed from 'Read' to avoid conflicts
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public User User { get; set; }
        public Report Report { get; set; }
    }
}
