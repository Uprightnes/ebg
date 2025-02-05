namespace EndPoliceBrutality.Models
{
    public class WhistleblowerProtection
    {
        public int Id { get; set; }
        public int ReportId { get; set; } // Foreign key for Report
        public string EncryptedIdentity { get; set; }
        public bool DeadManSwitch { get; set; } = false;

        // Navigation Property
        public Report Report { get; set; }
    }
}
