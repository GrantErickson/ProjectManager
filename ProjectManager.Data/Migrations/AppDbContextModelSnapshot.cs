﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectManager.Data;

#nullable disable

namespace ProjectManager.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProjectManager.Data.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAppAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ApplicationUsers");
                });

            modelBuilder.Entity("ProjectManager.Data.Models.Assignment", b =>
                {
                    b.Property<int>("AssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssignmentId"), 1L, 1);

                    b.Property<int>("AssignmentState")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsBillable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFlagged")
                        .HasColumnType("bit");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal?>("PercentAllocated")
                        .HasColumnType("decimal(13,4)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Rate")
                        .HasColumnType("decimal(13,4)");

                    b.Property<string>("RateRange")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isLongTerm")
                        .HasColumnType("bit");

                    b.HasKey("AssignmentId");

                    b.HasIndex("OrganizationUserId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("ProjectManager.Data.Models.AssignmentSkill", b =>
                {
                    b.Property<int>("AssignmentSkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssignmentSkillId"), 1L, 1);

                    b.Property<int>("AssignmentId")
                        .HasColumnType("int");

                    b.Property<int?>("Level")
                        .HasColumnType("int");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.HasKey("AssignmentSkillId");

                    b.HasIndex("AssignmentId");

                    b.HasIndex("SkillId");

                    b.ToTable("AssignmentSkills");
                });

            modelBuilder.Entity("ProjectManager.Data.Models.BillingPeriod", b =>
                {
                    b.Property<int>("BillingPeriodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BillingPeriodId"), 1L, 1);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("BillingPeriodId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("BillingPeriods");
                });

            modelBuilder.Entity("ProjectManager.Data.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientId"), 1L, 1);

                    b.Property<string>("AgreementUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BillingContact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PrimaryContact")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("ProjectManager.Data.Models.Organization", b =>
                {
                    b.Property<string>("OrganizationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrganizationId");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("ProjectManager.Data.Models.OrganizationUser", b =>
                {
                    b.Property<string>("OrganizationUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal?>("DefaultRate")
                        .HasColumnType("decimal(13,4)");

                    b.Property<int>("EmploymentStatus")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOrganizationAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("OrganizationUserId");

                    b.HasIndex("AppUserId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("OrganizationUsers");
                });

            modelBuilder.Entity("ProjectManager.Data.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"), 1L, 1);

                    b.Property<decimal?>("Amount")
                        .HasColumnType("decimal(13,4)");

                    b.Property<string>("BillingContact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BillingInformation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("ContractUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsBillableDefault")
                        .HasColumnType("bit");

                    b.Property<string>("LeadId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimaryContact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Probability")
                        .HasColumnType("decimal(13,4)");

                    b.Property<int>("ProjectState")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ProjectId");

                    b.HasIndex("ClientId");

                    b.HasIndex("LeadId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ProjectManager.Data.Models.ProjectNote", b =>
                {
                    b.Property<int>("ProjectNoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectNoteId"), 1L, 1);

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("DocumentUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("ProjectNoteId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectNotes");
                });

            modelBuilder.Entity("ProjectManager.Data.Models.ProjectRole", b =>
                {
                    b.Property<int>("ProjectRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectRoleId"), 1L, 1);

                    b.Property<bool>("IsManager")
                        .HasColumnType("bit");

                    b.Property<string>("OrganizationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("ProjectRoleId");

                    b.HasIndex("OrganizationUserId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectRoles");
                });

            modelBuilder.Entity("ProjectManager.Data.Models.Skill", b =>
                {
                    b.Property<int>("SkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SkillId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SkillId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("ProjectManager.Data.Models.TimeEntry", b =>
                {
                    b.Property<int>("TimeEntryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TimeEntryId"), 1L, 1);

                    b.Property<DateTimeOffset?>("ApprovedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Hours")
                        .HasColumnType("decimal(13,4)");

                    b.Property<bool>("IsBillable")
                        .HasColumnType("bit");

                    b.Property<string>("OrganizationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("StartDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("TimeEntryId");

                    b.HasIndex("OrganizationUserId");

                    b.HasIndex("ProjectId");

                    b.ToTable("TimeEntries");
                });

            modelBuilder.Entity("ProjectManager.Data.Models.UserSkill", b =>
                {
                    b.Property<int>("UserSkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserSkillId"), 1L, 1);

                    b.Property<bool>("IsAreaOfInterest")
                        .HasColumnType("bit");

                    b.Property<int?>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.HasKey("UserSkillId");

                    b.HasIndex("OrganizationUserId");

                    b.HasIndex("SkillId");

                    b.ToTable("UserSkills");
                });

            modelBuilder.Entity("ProjectManager.Data.Models.Assignment", b =>
                {
                    b.HasOne("ProjectManager.Data.Models.OrganizationUser", "User")
                        .WithMany("Assignments")
                        .HasForeignKey("OrganizationUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ProjectManager.Data.Models.Project", "Project")
                        .WithMany("Assignments")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProjectManager.Data.Models.AssignmentSkill", b =>
                {
                    b.HasOne("ProjectManager.Data.Models.Assignment", "Assignment")
                        .WithMany("Skills")
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProjectManager.Data.Models.Skill", "Skill")
                        .WithMany("Assignments")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Assignment");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("ProjectManager.Data.Models.BillingPeriod", b =>
                {
                    b.HasOne("ProjectManager.Data.Models.Organization", "Organization")
                        .WithMany("BillingPeriods")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("ProjectManager.Data.Models.Client", b =>
                {
                    b.HasOne("ProjectManager.Data.Models.Organization", "Organization")
                        .WithMany("Clients")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("ProjectManager.Data.Models.OrganizationUser", b =>
                {
                    b.HasOne("ProjectManager.Data.Models.ApplicationUser", "AppUser")
                        .WithMany("Organizations")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ProjectManager.Data.Models.Organization", "Organization")
                        .WithMany("Users")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("ProjectManager.Data.Models.Project", b =>
                {
                    b.HasOne("ProjectManager.Data.Models.Client", "Client")
                        .WithMany("Projects")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProjectManager.Data.Models.OrganizationUser", "Lead")
                        .WithMany("Projects")
                        .HasForeignKey("LeadId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Client");

                    b.Navigation("Lead");
                });

            modelBuilder.Entity("ProjectManager.Data.Models.ProjectNote", b =>
                {
                    b.HasOne("ProjectManager.Data.Models.Project", "Project")
                        .WithMany("Notes")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ProjectManager.Data.Models.ProjectRole", b =>
                {
                    b.HasOne("ProjectManager.Data.Models.OrganizationUser", "User")
                        .WithMany("ProjectRoles")
                        .HasForeignKey("OrganizationUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProjectManager.Data.Models.Project", "Project")
                        .WithMany("Roles")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProjectManager.Data.Models.TimeEntry", b =>
                {
                    b.HasOne("ProjectManager.Data.Models.OrganizationUser", "User")
                        .WithMany()
                        .HasForeignKey("OrganizationUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProjectManager.Data.Models.Project", "Project")
                        .WithMany("TimeEntries")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProjectManager.Data.Models.UserSkill", b =>
                {
                    b.HasOne("ProjectManager.Data.Models.OrganizationUser", "User")
                        .WithMany("Skills")
                        .HasForeignKey("OrganizationUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProjectManager.Data.Models.Skill", "Skill")
                        .WithMany("Users")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Skill");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProjectManager.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("Organizations");
                });

            modelBuilder.Entity("ProjectManager.Data.Models.Assignment", b =>
                {
                    b.Navigation("Skills");
                });

            modelBuilder.Entity("ProjectManager.Data.Models.Client", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("ProjectManager.Data.Models.Organization", b =>
                {
                    b.Navigation("BillingPeriods");

                    b.Navigation("Clients");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("ProjectManager.Data.Models.OrganizationUser", b =>
                {
                    b.Navigation("Assignments");

                    b.Navigation("ProjectRoles");

                    b.Navigation("Projects");

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("ProjectManager.Data.Models.Project", b =>
                {
                    b.Navigation("Assignments");

                    b.Navigation("Notes");

                    b.Navigation("Roles");

                    b.Navigation("TimeEntries");
                });

            modelBuilder.Entity("ProjectManager.Data.Models.Skill", b =>
                {
                    b.Navigation("Assignments");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
