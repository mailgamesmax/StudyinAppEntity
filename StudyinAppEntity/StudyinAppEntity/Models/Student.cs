using Microsoft.EntityFrameworkCore;
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
        public void AddStudent() 
        {
            string inputChoice;
            do
            { 
            Console.Write("Student name? ");
            string name = Console.ReadLine();
            Console.Write("Faculty direction? ");
            string direction = Console.ReadLine();

            using var context = new StudiesContext();

            var faculty = new Faculty();
            var selectFaculty = faculty.SelectFacultyByDirection(direction);
            //var selectedFaculty = context.FacultiesTable.FirstOrDefault(f => f.Direction == direction);
//            int facultyID = selectFaculty.Fac_Id;
            //var newStudent = context.StudentsTable.Add(new Student(name, direction));
            var newStudent = new Student(name, direction, selectFaculty.Fac_Id, selectFaculty);

            var student = context.StudentsTable.Add(newStudent);
                context.SaveChanges();
            //AddSubjectsToStudent(newStudent, selectFaculty);

                Console.Write("dar vienas? (+)");
                inputChoice = Console.ReadLine();
            }
            while (inputChoice == "+");
        }

        public void AddSubjectsToStudent(Student student, Faculty faculty)
        {
            using var context = new StudiesContext();
            var subject = new Subject();

//            var selectedFaculty = context.FacultiesTable.FirstOrDefault(f => f.Fac_Id == facultyID);
            
 //           var selectedStudent = context.StudentsTable.FirstOrDefault(s => s.Id == studentID);

            var selectedSubjects = subject.SelectStudiesByFaculty(faculty.Fac_Id);
            foreach (var sItem in selectedSubjects) 
            {
                var newStudentFacultySubject = new FacultyStudentSubject(faculty.Fac_Id, sItem.Id, student.Id, faculty, subject, student);
                var studentFacultySubject = context.Add(newStudentFacultySubject);
                context.SaveChanges();
            }
        }

        public void RemoveSubjectsFromStudent(Guid studentID, int facultyID)
        {
/*            using var context = new StudiesContext();
            var studentToRemove = context.StudentsTable.Include(s => s.StudentSubjects).FirstOrDefault(s => s.Id == studentID);
            //context.StudentsTable.Remove(studentToRemove);

            foreach (var studentSubject in studentToRemove.StudentSubjects.ToList())
            {
                context.FacultiesStudentsSubjectsTable.Remove(studentSubject);
            }
            context.SaveChanges();*/
        }

        /*        public void AddStudentToFaculty(Guid studentID)
                {
                    Console.Write("Kur mokysis studentas? (įvesti faculty ID");
                    var convertedToNr = int.TryParse(Console.ReadLine(), out int itemID);

                    using var context = new StudiesContext();

                    var selectedFaculty = context.FacultiesTable.FirstOrDefault(f => f.F_id == itemID);

                    var selectedStudent = context.StudentsTable.FirstOrDefault(s => s.Id == studentID);

                    var newStudentSuFacultySubject = new FacultySubject(itemID, selectedFaculty, subjectID, selectedSubject);
                        selectedFaculty.FacultySubjects.Add(newFacultySubject);

                        context.SaveChanges();
                    }*/

        public Student() { }
        public Student(string name, string direction)
        {
            Name = name;
            Direction = direction;
        }

        public Student(string name, string direction, int facultyID, Faculty faculty) : this(name, direction)
        {
            F_id = facultyID;
            Faculty = faculty;
        }


        // savybes ir konstruktoriai

        //[Key]     
        [Column(Order = 3)]
        public Guid Id { get; set; }

        [Column("Student name", Order = 0)]
        [MaxLength(100)]        
        public string Name { get; set; }
        [Required]
              
        [Column("Student's Faculty")]
        public string Direction { get; set; }
        
        [Column("Faculty ID")]
        public int F_id{ get; set; }
        public Faculty Faculty { get; set; }
        
        [Column("Student Subjects")]
        public IList<Subject> StudentSubjects { get; set; } = new List<Subject>();
        public IList<FacultyStudentSubject> FacultiesStudentsSubjects { get; set; } = new List<FacultyStudentSubject>();
        
        //public static List<Student> AllStudents { get; set;} = new List<Student>();


    }
}
