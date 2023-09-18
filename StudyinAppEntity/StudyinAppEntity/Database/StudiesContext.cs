using Microsoft.EntityFrameworkCore;
using StudyinAppEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyinAppEntity.Database
{
    internal class StudiesContext : DbContext
    {
        public StudiesContext() 
        {
            ConnectionString = "Data Source=MAXX\\SQLEXPRESS;Database=StudyingAppDB;Integrated Security=True; TrustServerCertificate=True";
        }
        public string ConnectionString { get; set; }

        public DbSet<Student> StudentsTable { get; set; } //tokie pavadinimai mokymosi tikslais
        public DbSet<Faculty> FacultiesTable { get; set; }
        public DbSet<Subject> SubjectsTable { get; set; }
        public DbSet<FacultyStudentSubject> FacultiesStudentsSubjectsTable { get; set; }
        public DbSet<FacultySubject> FacultiesSubjectsTable { get; set; }

        // kodo ir duombazes komunikavimo organizavimas
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
            //base.OnConfiguring(optionsBuilder);
        }

        // klasiu, ju relationshipu ir pan valdymas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //kuriamas bendrinis id
            modelBuilder.Entity<FacultyStudentSubject>().HasKey(abc => new { abc.FacultyID, abc.SubjectID, abc.StudentID }); //bendro id konfiguracija

            modelBuilder.Entity<FacultyStudentSubject>()
                .HasOne<Faculty>(abc => abc.Faculty) //nuoroda i sukurga nav.fielda
                .WithMany(a => a.FacultiesStudentsSubjects) //nuoroda i 1toMany rysi
                .HasForeignKey(abc => abc.FacultyID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FacultyStudentSubject>()
                .HasOne<Subject>(abc => abc.Subject) //nuoroda i sukurga nav.fielda
                .WithMany(b => b.FacultiesStudentsSubjects) //nuoroda i 1toMany rysi
                .HasForeignKey(abc => abc.SubjectID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FacultyStudentSubject>()
                .HasOne<Student>(abc => abc.Student) //nuoroda i sukurga nav.fielda
                .WithMany(c => c.FacultiesStudentsSubjects) //nuoroda i 1toMany rysi
                .HasForeignKey(abc => abc.StudentID)
                .OnDelete(DeleteBehavior.Restrict);
            //
            modelBuilder.Entity<FacultySubject>().HasKey(ab => new { ab.FacultyID, ab.SubjectID });

            modelBuilder.Entity<FacultySubject>()
                .HasOne<Faculty>(ab => ab.Faculty) 
                .WithMany(a => a.FacultiesSubjects) 
                .HasForeignKey(ab => ab.FacultyID);

            modelBuilder.Entity<FacultySubject>()
                .HasOne<Subject>(ab => ab.Subject) 
                .WithMany(b => b.FacultiesSubjects) 
                .HasForeignKey(ab => ab.SubjectID);


            //base.OnModelCreating(modelBuilder);
        }

        //public DbSet<Student> { get; set; }
        //public DbSet<Student>
    }
}
