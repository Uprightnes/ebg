using EndPoliceBrutality.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

namespace EndPoliceBrutality
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<User>  Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure UserTypes table
            modelBuilder.Entity<UserType>(entity =>
            {
                entity.HasKey(ut => ut.Id); // Primary Key
                entity.Property(ut => ut.Type)
                      .IsRequired()
                      .HasMaxLength(50);
                entity.Property(ut => ut.Description)
                      .HasMaxLength(500);
            });

            modelBuilder.Entity<UserType>().HasData(
            new UserType { Id = 1, Type = "Citizen", Description = "General user who can submit reports" },
            new UserType { Id = 2, Type = "Administrator", Description = "Admin with the ability to manage reports and users" },
            new UserType { Id = 3, Type = "Moderator", Description = "User who can moderate and escalate reports" },
            new UserType { Id = 4, Type = "Police Officer", Description = "User from the police department" }
        );

            // Configure Users table
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id); // Primary Key
                entity.HasIndex(u => u.NIN).IsUnique(); // Unique constraint
                entity.HasIndex(u => u.Email).IsUnique(); // Unique constraint
                entity.HasIndex(u => u.PhoneNumber).IsUnique(); // Unique constraint

                entity.Property(u => u.FirstName)
                      .IsRequired()
                      .HasMaxLength(50);
                entity.Property(u => u.LastName)
                      .IsRequired()
                      .HasMaxLength(50);
                entity.Property(u => u.MiddleName)
                      .HasMaxLength(50); // Optional
                entity.Property(u => u.DateOfBirth)
                      .IsRequired();
                entity.Property(u => u.Gender)
                      .IsRequired();
                entity.Property(u => u.MaritalStatus)
                      .IsRequired();
                entity.Property(u => u.Nationality)
                      .HasDefaultValue("Nigerian");
                entity.Property(u => u.CreatedAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(u => u.UpdatedAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP")
                      .ValueGeneratedOnUpdate();

                // Relationship: User -> UserType
                entity.HasOne(u => u.UserType)
                      .WithMany(ut => ut.Users)
                      .HasForeignKey(u => u.UserTypeId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            



            // Configure ReportTypes table
            modelBuilder.Entity<ReportType>(entity =>
            {
                entity.HasKey(rt => rt.Id); // Primary Key
                entity.Property(rt => rt.Type)
                      .IsRequired()
                      .HasMaxLength(50);
                entity.Property(rt => rt.Description)
                      .HasMaxLength(500);
            });

            // Configure Reports table
            modelBuilder.Entity<Report>(entity =>
            {
                entity.HasKey(r => r.Id); // Primary Key

                entity.Property(r => r.Description)
                      .IsRequired();

                entity.Property(r => r.Status)
                      .HasDefaultValue("Pending")
                      .HasMaxLength(50);

                entity.Property(r => r.CreatedAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(r => r.UpdatedAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP")
                      .ValueGeneratedOnUpdate();

                // Relationship: Report -> User (Submitted by)
                entity.HasOne(r => r.User)
                      .WithMany(u => u.Reports)
                      .HasForeignKey(r => r.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Relationship: Report -> ReportType
                entity.HasOne(r => r.ReportType)
                      .WithMany(rt => rt.Reports)
                      .HasForeignKey(r => r.ReportTypeId)
                      .OnDelete(DeleteBehavior.Restrict);

                // Relationship: Report -> User (Assigned To)
                entity.HasOne(r => r.AssignedTo)
                      .WithMany(u => u.AssignedReports)
                      .HasForeignKey(r => r.AssignedToId)
                      .OnDelete(DeleteBehavior.Restrict);


                entity.HasOne(r => r.PoliceStation)
                      .WithMany(ps => ps.Reports)
                      .HasForeignKey(r => r.PoliceStationId)
                      .OnDelete(DeleteBehavior.SetNull);
            });

            // Configure Evidence table
            modelBuilder.Entity<Evidences>(entity =>
            {
                entity.HasKey(e => e.Id); // Primary Key

                entity.Property(e => e.FileType)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.FilePath)
                      .IsRequired();

                entity.Property(e => e.UploadedAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                // Relationship: Evidence -> Report
                entity.HasOne(e => e.Report)
                      .WithMany(r => r.Evidences)
                      .HasForeignKey(e => e.ReportId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure PoliceStations table
            modelBuilder.Entity<PoliceStation>(entity =>
            {
                entity.HasKey(ps => ps.Id); // Primary Key

                entity.Property(ps => ps.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(ps => ps.Region)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(ps => ps.LGA)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(ps => ps.Area)
                      .IsRequired()
                      .HasMaxLength(100);

            });

            // Configure Notifications table
            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasKey(n => n.Id); // Primary Key

                entity.Property(n => n.Message)
                      .IsRequired();

                entity.Property(n => n.CreatedAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(n => n.IsRead)
                      .HasDefaultValue(false);

                // Relationship: Notification -> User
                entity.HasOne(n => n.User)
                      .WithMany(u => u.Notifications)
                      .HasForeignKey(n => n.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Relationship: Notification -> Report
                entity.HasOne(n => n.Report)
                      .WithMany(r => r.Notifications)
                      .HasForeignKey(n => n.ReportId)
                      .OnDelete(DeleteBehavior.SetNull);
            });

            // Configure Escalations table
            modelBuilder.Entity<Escalation>(entity =>
            {
                entity.HasKey(e => e.Id); // Primary Key

                entity.Property(e => e.Reason)
                      .IsRequired();

                entity.Property(e => e.EscalatedAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                // Relationship: Escalation -> Report
                entity.HasOne(e => e.Report)
                      .WithMany(r => r.Escalations)
                      .HasForeignKey(e => e.ReportId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Relationship: Escalation -> User
                entity.HasOne(e => e.EscalatedTo)
                      .WithMany(u => u.Escalations)
                      .HasForeignKey(e => e.EscalatedToId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure WhistleblowerProtection table
            modelBuilder.Entity<WhistleblowerProtection>(entity =>
            {
                entity.HasKey(wp => wp.Id); // Primary Key

                entity.Property(wp => wp.EncryptedIdentity)
                      .IsRequired();

                entity.Property(wp => wp.DeadManSwitch)
                      .HasDefaultValue(false);

                // Relationship: WhistleblowerProtection -> Report
                entity.HasOne(wp => wp.Report)
                      .WithOne(r => r.WhistleblowerProtection)
                      .HasForeignKey<WhistleblowerProtection>(wp => wp.ReportId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }


}
