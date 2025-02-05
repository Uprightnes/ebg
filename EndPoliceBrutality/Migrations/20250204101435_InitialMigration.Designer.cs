﻿// <auto-generated />
using System;
using EndPoliceBrutality;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EndPoliceBrutality.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250204101435_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("EndPoliceBrutality.Models.Escalation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EscalatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("EscalatedToId")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ReportId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EscalatedToId");

                    b.HasIndex("ReportId");

                    b.ToTable("Escalation");
                });

            modelBuilder.Entity("EndPoliceBrutality.Models.Evidences", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("ReportId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UploadedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.HasIndex("ReportId");

                    b.ToTable("Evidences");
                });

            modelBuilder.Entity("EndPoliceBrutality.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<bool>("IsRead")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("ReportId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReportId");

                    b.HasIndex("UserId");

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("EndPoliceBrutality.Models.PoliceStation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("LGA")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("PoliceStationId")
                        .HasColumnType("int");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("PoliceStation");
                });

            modelBuilder.Entity("EndPoliceBrutality.Models.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AssignedToId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("PoliceStationId")
                        .HasColumnType("int");

                    b.Property<int>("ReportTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasDefaultValue("Pending");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AssignedToId");

                    b.HasIndex("PoliceStationId");

                    b.HasIndex("ReportTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Report");
                });

            modelBuilder.Entity("EndPoliceBrutality.Models.ReportType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<int>("ReportTypesId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ReportTypesId");

                    b.ToTable("ReportType");
                });

            modelBuilder.Entity("EndPoliceBrutality.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("MaritalStatus")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NIN")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("longtext")
                        .HasDefaultValue("Nigerian");

                    b.Property<string>("OTPCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("OTPExpiration")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("NIN")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.HasIndex("UserTypeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EndPoliceBrutality.Models.UserType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("UserTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "General user who can submit reports",
                            Type = "Citizen"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Admin with the ability to manage reports and users",
                            Type = "Administrator"
                        },
                        new
                        {
                            Id = 3,
                            Description = "User who can moderate and escalate reports",
                            Type = "Moderator"
                        },
                        new
                        {
                            Id = 4,
                            Description = "User from the police department",
                            Type = "Police Officer"
                        });
                });

            modelBuilder.Entity("EndPoliceBrutality.Models.WhistleblowerProtection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("DeadManSwitch")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<string>("EncryptedIdentity")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ReportId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReportId")
                        .IsUnique();

                    b.ToTable("WhistleblowerProtection");
                });

            modelBuilder.Entity("EndPoliceBrutality.Models.Escalation", b =>
                {
                    b.HasOne("EndPoliceBrutality.Models.User", "EscalatedTo")
                        .WithMany("Escalations")
                        .HasForeignKey("EscalatedToId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EndPoliceBrutality.Models.Report", "Report")
                        .WithMany("Escalations")
                        .HasForeignKey("ReportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EscalatedTo");

                    b.Navigation("Report");
                });

            modelBuilder.Entity("EndPoliceBrutality.Models.Evidences", b =>
                {
                    b.HasOne("EndPoliceBrutality.Models.Report", "Report")
                        .WithMany("Evidences")
                        .HasForeignKey("ReportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Report");
                });

            modelBuilder.Entity("EndPoliceBrutality.Models.Notification", b =>
                {
                    b.HasOne("EndPoliceBrutality.Models.Report", "Report")
                        .WithMany("Notifications")
                        .HasForeignKey("ReportId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("EndPoliceBrutality.Models.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Report");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EndPoliceBrutality.Models.Report", b =>
                {
                    b.HasOne("EndPoliceBrutality.Models.User", "AssignedTo")
                        .WithMany("AssignedReports")
                        .HasForeignKey("AssignedToId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EndPoliceBrutality.Models.PoliceStation", "PoliceStation")
                        .WithMany("Reports")
                        .HasForeignKey("PoliceStationId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("EndPoliceBrutality.Models.ReportType", "ReportType")
                        .WithMany("Reports")
                        .HasForeignKey("ReportTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EndPoliceBrutality.Models.User", "User")
                        .WithMany("Reports")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssignedTo");

                    b.Navigation("PoliceStation");

                    b.Navigation("ReportType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EndPoliceBrutality.Models.ReportType", b =>
                {
                    b.HasOne("EndPoliceBrutality.Models.ReportType", "ReportTypes")
                        .WithMany()
                        .HasForeignKey("ReportTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReportTypes");
                });

            modelBuilder.Entity("EndPoliceBrutality.Models.User", b =>
                {
                    b.HasOne("EndPoliceBrutality.Models.UserType", "UserType")
                        .WithMany("Users")
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("EndPoliceBrutality.Models.WhistleblowerProtection", b =>
                {
                    b.HasOne("EndPoliceBrutality.Models.Report", "Report")
                        .WithOne("WhistleblowerProtection")
                        .HasForeignKey("EndPoliceBrutality.Models.WhistleblowerProtection", "ReportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Report");
                });

            modelBuilder.Entity("EndPoliceBrutality.Models.PoliceStation", b =>
                {
                    b.Navigation("Reports");
                });

            modelBuilder.Entity("EndPoliceBrutality.Models.Report", b =>
                {
                    b.Navigation("Escalations");

                    b.Navigation("Evidences");

                    b.Navigation("Notifications");

                    b.Navigation("WhistleblowerProtection")
                        .IsRequired();
                });

            modelBuilder.Entity("EndPoliceBrutality.Models.ReportType", b =>
                {
                    b.Navigation("Reports");
                });

            modelBuilder.Entity("EndPoliceBrutality.Models.User", b =>
                {
                    b.Navigation("AssignedReports");

                    b.Navigation("Escalations");

                    b.Navigation("Notifications");

                    b.Navigation("Reports");
                });

            modelBuilder.Entity("EndPoliceBrutality.Models.UserType", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
