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
        public DbSet<StudentSubject> StudentsSubjects { get; set; }
        public DbSet<FacultySubject> FacultiesSubjects { get; set; }
        
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
            modelBuilder.Entity<FacultySubject>().HasKey(ab => new {ab.FacultyID, ab.SubjectID});

            modelBuilder.Entity<FacultySubject>()
                .HasOne<Faculty>(ab => ab.Faculty) //nuoroda i sukurga nav.fielda
                .WithMany(a => a.FacultySubjects) //nuoroda i 1toMany rysi
                .HasForeignKey(ab => ab.FacultyID);

            modelBuilder.Entity<FacultySubject>()
                .HasOne<Subject>(ab => ab.Subject) //nuoroda i sukurga nav.fielda
                .WithMany(b => b.SubjectFaculties) //nuoroda i 1toMany rysi
                .HasForeignKey(ab => ab.SubjectID);
            
            
            modelBuilder.Entity<StudentSubject>().HasKey(ab => new { ab.StudentID, ab.SubjectID });

            modelBuilder.Entity<StudentSubject>()
                .HasOne<Student>(ab => ab.Student) 
                .WithMany(b => b.StudentSubjects) 
                .HasForeignKey(ab => ab.StudentID);

            modelBuilder.Entity<StudentSubject>()
                .HasOne<Subject>(ab => ab.Subject) //nuoroda i sukurga nav.fielda
                .WithMany(b => b.SubjectStudents) //nuoroda i 1toMany rysi
                .HasForeignKey(ab => ab.SubjectID);

            //base.OnModelCreating(modelBuilder);
        }

        //public DbSet<Student> { get; set; }
        //public DbSet<Student>
    }
}
