﻿// <auto-generated />
using System;
using HygieiaApp.Razor.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HygieiaApp.Razor.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230425115732_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("HygieiaApp.Razor.Models.Immunization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DateOfVaccination")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UsedFor")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId1")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId1");

                    b.ToTable("Immunizations");
                });

            modelBuilder.Entity("HygieiaApp.Razor.Models.MedicalCondition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("NameOfDiagnosis")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid?>("PatientMedicalConditionId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Symptoms")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Treatment")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("PatientMedicalConditionId");

                    b.ToTable("MedicalConditions");
                });

            modelBuilder.Entity("HygieiaApp.Razor.Models.MedicalConditionMedicated", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<decimal>("Dosage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Frequency")
                        .HasColumnType("int");

                    b.Property<int>("MedicalConditionMedicationId")
                        .HasColumnType("int");

                    b.Property<Guid>("MedicalConditionMedicationId1")
                        .HasColumnType("char(36)");

                    b.Property<int>("MedicalConditionPatientId")
                        .HasColumnType("int");

                    b.Property<Guid>("MedicalConditionPatientId1")
                        .HasColumnType("char(36)");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("MedicalConditionMedicationId1");

                    b.HasIndex("MedicalConditionPatientId1");

                    b.ToTable("MedicalConditionMedicateds");
                });

            modelBuilder.Entity("HygieiaApp.Razor.Models.MedicalConditionMedication", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<decimal>("MaximumDosage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MedicalConditionId")
                        .HasColumnType("int");

                    b.Property<Guid>("MedicalConditionId1")
                        .HasColumnType("char(36)");

                    b.Property<int>("MedicationId")
                        .HasColumnType("int");

                    b.Property<Guid>("MedicationId1")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("MedicalConditionId1");

                    b.HasIndex("MedicationId1");

                    b.ToTable("MedicalConditionMedications");
                });

            modelBuilder.Entity("HygieiaApp.Razor.Models.Medication", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Class")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Deleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SideEffects")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Medications");
                });

            modelBuilder.Entity("HygieiaApp.Razor.Models.PatientDoctor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("char(36)");

                    b.Property<int>("DoctorsId")
                        .HasColumnType("int");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("char(36)");

                    b.Property<int>("PatientsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("PatientDoctors");
                });

            modelBuilder.Entity("HygieiaApp.Razor.Models.PatientMedicalCondition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DateOfDiagnosis")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("MedicalConditionId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<Guid>("PatientId1")
                        .HasColumnType("char(36)");

                    b.Property<int>("Stage")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PatientId1");

                    b.ToTable("PatientMedicalConditions");
                });

            modelBuilder.Entity("HygieiaApp.Razor.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("HygieiaApp.Razor.Models.Scheduler", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DateOfAppointment")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<Guid>("DoctorId1")
                        .HasColumnType("char(36)");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<Guid>("PatientId1")
                        .HasColumnType("char(36)");

                    b.Property<string>("Reminder")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId1");

                    b.HasIndex("PatientId1");

                    b.ToTable("Schedulers");
                });

            modelBuilder.Entity("HygieiaApp.Razor.Models.TestResult", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DateOfTesting")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<Guid>("PatientId1")
                        .HasColumnType("char(36)");

                    b.Property<string>("Results")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("PatientId1");

                    b.ToTable("TestResults");
                });

            modelBuilder.Entity("HygieiaApp.Razor.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<Guid>("RoleId1")
                        .HasColumnType("char(36)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RoleId1");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HygieiaApp.Razor.Models.Immunization", b =>
                {
                    b.HasOne("HygieiaApp.Razor.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("HygieiaApp.Razor.Models.MedicalCondition", b =>
                {
                    b.HasOne("HygieiaApp.Razor.Models.PatientMedicalCondition", null)
                        .WithMany("MedicalCondition")
                        .HasForeignKey("PatientMedicalConditionId");
                });

            modelBuilder.Entity("HygieiaApp.Razor.Models.MedicalConditionMedicated", b =>
                {
                    b.HasOne("HygieiaApp.Razor.Models.MedicalConditionMedication", "MedicalConditionMedication")
                        .WithMany()
                        .HasForeignKey("MedicalConditionMedicationId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HygieiaApp.Razor.Models.PatientMedicalCondition", "MedicalConditionPatient")
                        .WithMany()
                        .HasForeignKey("MedicalConditionPatientId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedicalConditionMedication");

                    b.Navigation("MedicalConditionPatient");
                });

            modelBuilder.Entity("HygieiaApp.Razor.Models.MedicalConditionMedication", b =>
                {
                    b.HasOne("HygieiaApp.Razor.Models.MedicalCondition", "MedicalCondition")
                        .WithMany()
                        .HasForeignKey("MedicalConditionId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HygieiaApp.Razor.Models.Medication", "Medication")
                        .WithMany()
                        .HasForeignKey("MedicationId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedicalCondition");

                    b.Navigation("Medication");
                });

            modelBuilder.Entity("HygieiaApp.Razor.Models.PatientDoctor", b =>
                {
                    b.HasOne("HygieiaApp.Razor.Models.User", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HygieiaApp.Razor.Models.User", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HygieiaApp.Razor.Models.PatientMedicalCondition", b =>
                {
                    b.HasOne("HygieiaApp.Razor.Models.User", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HygieiaApp.Razor.Models.Scheduler", b =>
                {
                    b.HasOne("HygieiaApp.Razor.Models.User", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HygieiaApp.Razor.Models.User", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HygieiaApp.Razor.Models.TestResult", b =>
                {
                    b.HasOne("HygieiaApp.Razor.Models.User", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HygieiaApp.Razor.Models.User", b =>
                {
                    b.HasOne("HygieiaApp.Razor.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("HygieiaApp.Razor.Models.PatientMedicalCondition", b =>
                {
                    b.Navigation("MedicalCondition");
                });
#pragma warning restore 612, 618
        }
    }
}
