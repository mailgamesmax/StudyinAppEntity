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
            ConnectionString = "Data Source=MAXX\\SQLEXPRESS;Database=StudyingAppDB;Integrated Security=True";
        }
        public string ConnectionString { get; set; }


        public DbSet<Student> Students { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Subject> Subjects { get; set; }
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
            
            //base.OnModelCreating(modelBuilder);
        }

        //public DbSet<Student> { get; set; }
        //public DbSet<Student>
    }
}
