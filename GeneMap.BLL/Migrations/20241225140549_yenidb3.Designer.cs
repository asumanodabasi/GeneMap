﻿// <auto-generated />
using System;
using GeneMap.BLL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GeneMap.BLL.Migrations
{
    [DbContext(typeof(PatientDataContext))]
    [Migration("20241225140549_yenidb3")]
    partial class yenidb3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DoctorPatient", b =>
                {
                    b.Property<int>("DoctorsDoctorId")
                        .HasColumnType("int");

                    b.Property<int>("PatientsPatientId")
                        .HasColumnType("int");

                    b.HasKey("DoctorsDoctorId", "PatientsPatientId");

                    b.HasIndex("PatientsPatientId");

                    b.ToTable("DoctorPatient");
                });

            modelBuilder.Entity("GeneMap.BLL.Data.Entities.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("GeneMap.BLL.Data.Entities.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GeneMap.BLL.Data.Entities.AppUserRole", b =>
                {
                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoleId", "UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("GeneMap.BLL.Data.Entities.Diagnosis", b =>
                {
                    b.Property<int>("DiagnosisId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiagnosisId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly?>("DiagnosisDate")
                        .HasColumnType("date");

                    b.Property<int>("IlnessId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("DiagnosisId");

                    b.HasIndex("IlnessId");

                    b.HasIndex("PatientId");

                    b.ToTable("Diagnosiss");
                });

            modelBuilder.Entity("GeneMap.BLL.Data.Entities.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoctorId"));

                    b.Property<string>("Degree")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalIdentity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DoctorId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("GeneMap.BLL.Data.Entities.Ilness", b =>
                {
                    b.Property<int>("IlnessId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IlnessId"));

                    b.Property<int>("DiseaseStage")
                        .HasColumnType("int");

                    b.Property<int?>("IlnessId1")
                        .HasColumnType("int");

                    b.Property<string>("IlnessName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("IlnessId");

                    b.HasIndex("IlnessId1");

                    b.HasIndex("PatientId");

                    b.ToTable("Ilnesses");
                });

            modelBuilder.Entity("GeneMap.BLL.Data.Entities.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientId"));

                    b.Property<string>("Complaints")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("DiseaseStatus")
                        .HasColumnType("bit");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NationalIdentity")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("PatientEndDate")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("PatientStartDate")
                        .HasColumnType("date");

                    b.Property<string>("Symptoms")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("GeneMap.BLL.Data.Entities.PatientIlness", b =>
                {
                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<int>("IlnessId")
                        .HasColumnType("int");

                    b.HasKey("PatientId", "IlnessId");

                    b.HasIndex("IlnessId");

                    b.ToTable("PatientIlnesses");
                });

            modelBuilder.Entity("GeneMap.BLL.Data.Entities.PatientPatientRelative", b =>
                {
                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<int>("PatientRelativeId")
                        .HasColumnType("int");

                    b.Property<string>("Relation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientId", "PatientRelativeId");

                    b.HasIndex("PatientRelativeId");

                    b.ToTable("PatientPatientRelatives");
                });

            modelBuilder.Entity("GeneMap.BLL.Data.Entities.PatientRelative", b =>
                {
                    b.Property<int>("PatientRelativeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientRelativeId"));

                    b.Property<int>("Degree")
                        .HasColumnType("int");

                    b.Property<int>("IllnessId")
                        .HasColumnType("int");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientRelativeId");

                    b.HasIndex("IllnessId");

                    b.ToTable("PatientRelatives");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("DoctorPatient", b =>
                {
                    b.HasOne("GeneMap.BLL.Data.Entities.Doctor", null)
                        .WithMany()
                        .HasForeignKey("DoctorsDoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GeneMap.BLL.Data.Entities.Patient", null)
                        .WithMany()
                        .HasForeignKey("PatientsPatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GeneMap.BLL.Data.Entities.Diagnosis", b =>
                {
                    b.HasOne("GeneMap.BLL.Data.Entities.Ilness", "Ilness")
                        .WithMany()
                        .HasForeignKey("IlnessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GeneMap.BLL.Data.Entities.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ilness");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("GeneMap.BLL.Data.Entities.Ilness", b =>
                {
                    b.HasOne("GeneMap.BLL.Data.Entities.Ilness", null)
                        .WithMany("Patients")
                        .HasForeignKey("IlnessId1");

                    b.HasOne("GeneMap.BLL.Data.Entities.Patient", null)
                        .WithMany("Ilnesses")
                        .HasForeignKey("PatientId");
                });

            modelBuilder.Entity("GeneMap.BLL.Data.Entities.PatientIlness", b =>
                {
                    b.HasOne("GeneMap.BLL.Data.Entities.Ilness", "Ilness")
                        .WithMany()
                        .HasForeignKey("IlnessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GeneMap.BLL.Data.Entities.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ilness");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("GeneMap.BLL.Data.Entities.PatientPatientRelative", b =>
                {
                    b.HasOne("GeneMap.BLL.Data.Entities.Patient", "Patient")
                        .WithMany("PatientPatientRelative")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GeneMap.BLL.Data.Entities.PatientRelative", "PatientRelative")
                        .WithMany("PatientPatientRelative")
                        .HasForeignKey("PatientRelativeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");

                    b.Navigation("PatientRelative");
                });

            modelBuilder.Entity("GeneMap.BLL.Data.Entities.PatientRelative", b =>
                {
                    b.HasOne("GeneMap.BLL.Data.Entities.Ilness", "Ilness")
                        .WithMany()
                        .HasForeignKey("IllnessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ilness");
                });

            modelBuilder.Entity("GeneMap.BLL.Data.Entities.Ilness", b =>
                {
                    b.Navigation("Patients");
                });

            modelBuilder.Entity("GeneMap.BLL.Data.Entities.Patient", b =>
                {
                    b.Navigation("Ilnesses");

                    b.Navigation("PatientPatientRelative");
                });

            modelBuilder.Entity("GeneMap.BLL.Data.Entities.PatientRelative", b =>
                {
                    b.Navigation("PatientPatientRelative");
                });
#pragma warning restore 612, 618
        }
    }
}
