﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OurProjects.Data.Repository;

#nullable disable

namespace OurProjects.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231022170929_NullableColumnOnProject")]
    partial class NullableColumnOnProject
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("OurProjects.Data.Models.Area", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("createdAt");

                    b.Property<Guid>("IdCompany")
                        .HasColumnType("char(36)")
                        .HasColumnName("idCompany");

                    b.Property<bool>("Idle")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("idle");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("IdCompany");

                    b.ToTable("area", (string)null);
                });

            modelBuilder.Entity("OurProjects.Data.Models.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("createdAt");

                    b.Property<bool>("Idle")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("idle");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("company", (string)null);
                });

            modelBuilder.Entity("OurProjects.Data.Models.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("createdAt");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("endDate");

                    b.Property<Guid>("IdArea")
                        .HasColumnType("char(36)")
                        .HasColumnName("idArea");

                    b.Property<Guid>("IdCompany")
                        .HasColumnType("char(36)")
                        .HasColumnName("idCompany");

                    b.Property<Guid>("IdLeader")
                        .HasColumnType("char(36)")
                        .HasColumnName("idLeader");

                    b.Property<bool>("Idle")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("idle");

                    b.Property<bool>("Show")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("show");

                    b.Property<bool>("ShowLeader")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("showLeader");

                    b.Property<bool>("ShowTeam")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("showTeam");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("startDate");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("title");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updatedAt");

                    b.HasKey("Id");

                    b.HasIndex("IdArea");

                    b.HasIndex("IdCompany");

                    b.HasIndex("IdLeader");

                    b.ToTable("project", (string)null);
                });

            modelBuilder.Entity("OurProjects.Data.Models.ProjectTeamMember", b =>
                {
                    b.Property<Guid>("IdProject")
                        .HasColumnType("char(36)")
                        .HasColumnName("idArea");

                    b.Property<Guid>("IdTeamMember")
                        .HasColumnType("char(36)")
                        .HasColumnName("idTeamMember");

                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.HasKey("IdProject", "IdTeamMember");

                    b.HasIndex("IdTeamMember");

                    b.ToTable("projectTeamMember", (string)null);
                });

            modelBuilder.Entity("OurProjects.Data.Models.ProjectTechnology", b =>
                {
                    b.Property<Guid>("IdProject")
                        .HasColumnType("char(36)")
                        .HasColumnName("idProject");

                    b.Property<Guid>("IdTechnology")
                        .HasColumnType("char(36)")
                        .HasColumnName("idCompany");

                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.HasKey("IdProject", "IdTechnology");

                    b.HasIndex("IdTechnology");

                    b.ToTable("projectTechnology", (string)null);
                });

            modelBuilder.Entity("OurProjects.Data.Models.Technology", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("createdAt");

                    b.Property<Guid>("IdCompany")
                        .HasColumnType("char(36)")
                        .HasColumnName("idCompany");

                    b.Property<bool>("Idle")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("idle");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("IdCompany");

                    b.ToTable("technology", (string)null);
                });

            modelBuilder.Entity("OurProjects.Data.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("IdCompany")
                        .HasColumnType("char(36)");

                    b.Property<bool>("Idle")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("IdCompany");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("OurProjects.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("OurProjects.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OurProjects.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("OurProjects.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OurProjects.Data.Models.Area", b =>
                {
                    b.HasOne("OurProjects.Data.Models.Company", "Company")
                        .WithMany("Areas")
                        .HasForeignKey("IdCompany")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_area_company");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("OurProjects.Data.Models.Project", b =>
                {
                    b.HasOne("OurProjects.Data.Models.Area", "Area")
                        .WithMany("Projects")
                        .HasForeignKey("IdArea")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_project_area");

                    b.HasOne("OurProjects.Data.Models.Company", "Company")
                        .WithMany("Projects")
                        .HasForeignKey("IdCompany")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_project_company");

                    b.HasOne("OurProjects.Data.Models.User", "UserLeader")
                        .WithMany("ProjectsLeader")
                        .HasForeignKey("IdLeader")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_project_userLeader");

                    b.Navigation("Area");

                    b.Navigation("Company");

                    b.Navigation("UserLeader");
                });

            modelBuilder.Entity("OurProjects.Data.Models.ProjectTeamMember", b =>
                {
                    b.HasOne("OurProjects.Data.Models.Project", "Project")
                        .WithMany("ProjectTeamMembers")
                        .HasForeignKey("IdProject")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_projectTeamMember_project");

                    b.HasOne("OurProjects.Data.Models.User", "TeamMember")
                        .WithMany("ProjectTeamMembers")
                        .HasForeignKey("IdTeamMember")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_projectTeamMember_user");

                    b.Navigation("Project");

                    b.Navigation("TeamMember");
                });

            modelBuilder.Entity("OurProjects.Data.Models.ProjectTechnology", b =>
                {
                    b.HasOne("OurProjects.Data.Models.Project", "Project")
                        .WithMany("ProjectTechnologies")
                        .HasForeignKey("IdProject")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_projectTechnology_project");

                    b.HasOne("OurProjects.Data.Models.Technology", "Technology")
                        .WithMany("ProjectTechnologies")
                        .HasForeignKey("IdTechnology")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_projectTechnology_technology");

                    b.Navigation("Project");

                    b.Navigation("Technology");
                });

            modelBuilder.Entity("OurProjects.Data.Models.Technology", b =>
                {
                    b.HasOne("OurProjects.Data.Models.Company", "Company")
                        .WithMany("Technologies")
                        .HasForeignKey("IdCompany")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_technology_company");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("OurProjects.Data.Models.User", b =>
                {
                    b.HasOne("OurProjects.Data.Models.Company", "Company")
                        .WithMany("Users")
                        .HasForeignKey("IdCompany")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_user_company");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("OurProjects.Data.Models.Area", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("OurProjects.Data.Models.Company", b =>
                {
                    b.Navigation("Areas");

                    b.Navigation("Projects");

                    b.Navigation("Technologies");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("OurProjects.Data.Models.Project", b =>
                {
                    b.Navigation("ProjectTeamMembers");

                    b.Navigation("ProjectTechnologies");
                });

            modelBuilder.Entity("OurProjects.Data.Models.Technology", b =>
                {
                    b.Navigation("ProjectTechnologies");
                });

            modelBuilder.Entity("OurProjects.Data.Models.User", b =>
                {
                    b.Navigation("ProjectTeamMembers");

                    b.Navigation("ProjectsLeader");
                });
#pragma warning restore 612, 618
        }
    }
}
