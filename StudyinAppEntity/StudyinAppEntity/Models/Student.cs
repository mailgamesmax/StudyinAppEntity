using StudyinAppEntity.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyinAppEntity.Models
{
    internal class Student
    {
        public void AddStudent(string name, string direction) 
        {
            using var context = new StudiesContext();
            var newStudent = new Student(name, direction);

            var selectedFaculty = context.FacultiesTable.FirstOrDefault(f => f.Direction == direction);
            selectedFaculty.FacultyStudents.Add(newStudent);
            //var newStudent = context.StudentsTable.Add(new Student(name, direction));
            context.SaveChanges();
            //AllStudents.Add(newStudent);            
        }
                

        public Student() { }
        public Student(string name, string direction)
        {
            Name = name;
            FacultyName = direction;
        }
        
        // savybes ir konstruktoriai
        
        [Key]     
        [Column(Order = 3)]
        public Guid Id { get; set; }

        [Column("Student name", Order = 0)]
        [MaxLength(100)]        
        public string Name { get; set; }
        [Required]

        //public string FacultyID { get; set; }                
        [Column("Student's Faculty")]
        public string FacultyName { get; set; }

        [Column("Student Subjects")]
        public List<StudentSubject> StudentSubjects { get; set; } = new List<StudentSubject>();
        //public IList<StudentSubject> StudentSubjects { get; set; } = new List<StudentSubject>();
        
        //public static List<Student> AllStudents { get; set;} = new List<Student>();


    }
}
