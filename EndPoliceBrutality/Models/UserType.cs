namespace EndPoliceBrutality.Models
{
    public class UserType
    {
        public int Id { get; set; }
        public string Type { get; set; } // ctizen, adminstrator, and moderator
        public string Description { get; set; }


        public ICollection<User> Users { get; set; }
    }
}
