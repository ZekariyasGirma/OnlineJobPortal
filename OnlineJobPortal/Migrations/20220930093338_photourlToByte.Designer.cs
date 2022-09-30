﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineJobPortal.Models;

namespace OnlineJobPortal.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220930093338_photourlToByte")]
    partial class photourlToByte
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OnlineJobPortal.Models.Admin", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Username");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("OnlineJobPortal.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("OnlineJobPortal.Models.Company", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CityId")
                        .HasColumnType("bigint");

                    b.Property<int?>("CityId1")
                        .HasColumnType("int");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CityId1");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("OnlineJobPortal.Models.Credential", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("CGPA")
                        .HasColumnType("real");

                    b.Property<string>("CvUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EducationLevelID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<string>("Field")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("JobSeekerId")
                        .HasColumnType("bigint");

                    b.Property<string>("Skills")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("JobSeekerId");

                    b.ToTable("Credentials");
                });

            modelBuilder.Entity("OnlineJobPortal.Models.EducationLevel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EducationLevelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EducationLevels");
                });

            modelBuilder.Entity("OnlineJobPortal.Models.Job", b =>
                {
                    b.Property<long>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("CGPA")
                        .HasColumnType("real");

                    b.Property<long>("CityId")
                        .HasColumnType("bigint");

                    b.Property<int?>("CityId1")
                        .HasColumnType("int");

                    b.Property<long>("CompanyId")
                        .HasColumnType("bigint");

                    b.Property<string>("EducationLevelId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("EducationLevelId1")
                        .HasColumnType("bigint");

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<string>("Field")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PostedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Vaccancy")
                        .HasColumnType("int");

                    b.Property<int?>("WorkHourEnd")
                        .HasColumnType("int");

                    b.Property<int?>("WorkHourStart")
                        .HasColumnType("int");

                    b.HasKey("JobId");

                    b.HasIndex("CityId1");

                    b.HasIndex("CompanyId");

                    b.HasIndex("EducationLevelId1");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("OnlineJobPortal.Models.JobNotification", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AppliedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("ApprovalStatus")
                        .HasColumnType("bit");

                    b.Property<bool?>("C_ReadStatus")
                        .HasColumnType("bit");

                    b.Property<long>("CompanyId")
                        .HasColumnType("bigint");

                    b.Property<bool?>("JS_Readtatus")
                        .HasColumnType("bit");

                    b.Property<long>("JobId")
                        .HasColumnType("bigint");

                    b.Property<long>("JobSeekerId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("JobNotifications");
                });

            modelBuilder.Entity("OnlineJobPortal.Models.JobSeeker", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CityId")
                        .HasColumnType("bigint");

                    b.Property<int?>("CityId1")
                        .HasColumnType("int");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CityId1");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("JobSeeker");
                });

            modelBuilder.Entity("OnlineJobPortal.Models.Company", b =>
                {
                    b.HasOne("OnlineJobPortal.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId1");

                    b.Navigation("City");
                });

            modelBuilder.Entity("OnlineJobPortal.Models.Credential", b =>
                {
                    b.HasOne("OnlineJobPortal.Models.JobSeeker", "JobSeeker")
                        .WithMany()
                        .HasForeignKey("JobSeekerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobSeeker");
                });

            modelBuilder.Entity("OnlineJobPortal.Models.Job", b =>
                {
                    b.HasOne("OnlineJobPortal.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId1");

                    b.HasOne("OnlineJobPortal.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineJobPortal.Models.EducationLevel", "EducationLevel")
                        .WithMany()
                        .HasForeignKey("EducationLevelId1");

                    b.Navigation("City");

                    b.Navigation("Company");

                    b.Navigation("EducationLevel");
                });

            modelBuilder.Entity("OnlineJobPortal.Models.JobSeeker", b =>
                {
                    b.HasOne("OnlineJobPortal.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId1");

                    b.Navigation("City");
                });
#pragma warning restore 612, 618
        }
    }
}
