namespace EndPoliceBrutality.Models
{
    public class User
    {
        public int Id { get; set; }
        public string NIN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }

        public string Nationality { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string OTPCode { get; set; }
        public DateTime? OTPExpiration { get; set; }
        public bool IsVerified { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }



        public int UserTypeId { get; set; }
        public UserType UserType { get; set; }

        public ICollection<Report> Reports { get; set; }
        public ICollection<Report> AssignedReports { get; set; }

        public ICollection<Notification> Notifications { get; set; }

        public ICollection<Escalation> Escalations { get; set; }



    }
}
