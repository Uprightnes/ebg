namespace EndPoliceBrutality.Models
{
    public class Evidences
    {
        public int Id { get; set; }
        public string FileType { get; set; } // Type of the file (e.g., 'image', 'video', 'document')
        public string FilePath { get; set; } // Path to the file storage location
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow; // Default value is the current timestamp

        // Foreign key to Report
        public int ReportId { get; set; }
        public Report Report { get; set; }
    }
}
