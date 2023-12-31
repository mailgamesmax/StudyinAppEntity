﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudyinAppEntity.Database;

#nullable disable

namespace StudyinAppEntity.Migrations
{
    [DbContext(typeof(StudiesContext))]
    [Migration("20230918204553_StudentsSubjectsRemoved")]
    partial class StudentsSubjectsRemoved
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StudyinAppEntity.Models.Faculty", b =>
                {
                    b.Property<int>("Fac_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Fac_Id"));

                    b.Property<string>("Direction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Direction(like Title)");

                    b.HasKey("Fac_Id");

                    b.ToTable("FacultiesTable");
                });

            modelBuilder.Entity("StudyinAppEntity.Models.FacultyStudentSubject", b =>
                {
                    b.Property<int>("FacultyID")
                        .HasColumnType("int");

                    b.Property<int>("SubjectID")
                        .HasColumnType("int");

                    b.Property<Guid>("StudentID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FacultyID", "SubjectID", "StudentID");

                    b.HasIndex("StudentID");

                    b.HasIndex("SubjectID");

                    b.ToTable("Faculties, Students and Subjects");
                });

            modelBuilder.Entity("StudyinAppEntity.Models.FacultySubject", b =>
                {
                    b.Property<int>("FacultyID")
                        .HasColumnType("int");

                    b.Property<int>("SubjectID")
                        .HasColumnType("int");

                    b.HasKey("FacultyID", "SubjectID");

                    b.HasIndex("SubjectID");

                    b.ToTable("Faculties and Subjects");
                });

            modelBuilder.Entity("StudyinAppEntity.Models.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(3);

                    b.Property<string>("Direction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Student's Faculty");

                    b.Property<int>("F_id")
                        .HasColumnType("int")
                        .HasColumnName("Faculty ID");

                    b.Property<int>("FacultyFac_Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Student name")
                        .HasColumnOrder(0);

                    b.HasKey("Id");

                    b.HasIndex("FacultyFac_Id");

                    b.ToTable("StudentsTable");
                });

            modelBuilder.Entity("StudyinAppEntity.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid?>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("SubjectsTable");
                });

            modelBuilder.Entity("StudyinAppEntity.Models.FacultyStudentSubject", b =>
                {
                    b.HasOne("StudyinAppEntity.Models.Faculty", "Faculty")
                        .WithMany("FacultiesStudentsSubjects")
                        .HasForeignKey("FacultyID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("StudyinAppEntity.Models.Student", "Student")
                        .WithMany("FacultiesStudentsSubjects")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("StudyinAppEntity.Models.Subject", "Subject")
                        .WithMany("FacultiesStudentsSubjects")
                        .HasForeignKey("SubjectID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Faculty");

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("StudyinAppEntity.Models.FacultySubject", b =>
                {
                    b.HasOne("StudyinAppEntity.Models.Faculty", "Faculty")
                        .WithMany("FacultiesSubjects")
                        .HasForeignKey("FacultyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudyinAppEntity.Models.Subject", "Subject")
                        .WithMany("FacultiesSubjects")
                        .HasForeignKey("SubjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("StudyinAppEntity.Models.Student", b =>
                {
                    b.HasOne("StudyinAppEntity.Models.Faculty", "Faculty")
                        .WithMany("FacultyStudents")
                        .HasForeignKey("FacultyFac_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("StudyinAppEntity.Models.Subject", b =>
                {
                    b.HasOne("StudyinAppEntity.Models.Student", null)
                        .WithMany("StudentSubjects")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("StudyinAppEntity.Models.Faculty", b =>
                {
                    b.Navigation("FacultiesStudentsSubjects");

                    b.Navigation("FacultiesSubjects");

                    b.Navigation("FacultyStudents");
                });

            modelBuilder.Entity("StudyinAppEntity.Models.Student", b =>
                {
                    b.Navigation("FacultiesStudentsSubjects");

                    b.Navigation("StudentSubjects");
                });

            modelBuilder.Entity("StudyinAppEntity.Models.Subject", b =>
                {
                    b.Navigation("FacultiesStudentsSubjects");

                    b.Navigation("FacultiesSubjects");
                });
#pragma warning restore 612, 618
        }
    }
}
