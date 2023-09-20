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

        public DbSet<Faculty> FacultiesTable { get; set; }
        public DbSet<Student> StudentsTable { get; set; } //tokie pavadinimai mokymosi tikslais
        public DbSet<Subject> SubjectsTable { get; set; }
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
            // student-faculty 1toM
            modelBuilder.Entity<Faculty>()
                .HasMany(f => f.FacultyStudents)
                .WithOne(s => s.Faculty)
                .HasForeignKey(s => s.Fac_Id);

            //kuriamas bendrinis id
            modelBuilder.Entity<FacultySubject>().HasKey(ab => new { ab.FacultyID, ab.SubjectID });

            modelBuilder.Entity<FacultySubject>()
                .HasOne<Faculty>(ab => ab.Faculty)
                .WithMany(a => a.FacultiesSubjects)
                .HasForeignKey(ab => ab.FacultyID);

            modelBuilder.Entity<FacultySubject>()
                .HasOne<Subject>(ab => ab.Subject)
                .WithMany(b => b.FacultiesSubjects)
                .HasForeignKey(ab => ab.SubjectID);


        }
            

        //public DbSet<Student> { get; set; }
        //public DbSet<Student>
    }
}
