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

                var selectedFaculty = context.FacultiesTable.FirstOrDefault(f => f.Direction == direction);

                if (selectedFaculty != null)
                {
                    var newStudent = new Student(name, direction);
                    selectedFaculty.FacultyStudents.Add(newStudent);
                    context.SaveChanges();
                    AssignStudentToSubject(name, selectedFaculty.Fac_Id);
                }
                else
                {
                    Console.WriteLine("Fakultetas nerastas");
                }

                Console.Write("dar vienas? (+)");
                inputChoice = Console.ReadLine();
            }
            while (inputChoice == "+");
        }

        public void changeStudentFaculty() 
        {
            Console.Write("Stud name? (personal id better....) ");
            string inputedName = Console.ReadLine();
            Console.Write("New fac nr? ");
            int inputedFac = int.Parse(Console.ReadLine());

            using var context = new StudiesContext();

            var targetStudent = context.StudentsTable.FirstOrDefault(f => f.Name == inputedName);
            var targetFac = context.FacultiesTable.Find(inputedFac);
           
            var currentDepartment = context.FacultiesTable.FirstOrDefault(f => f.Fac_Id == targetStudent.Fac_Id);
            
            if (currentDepartment != null)
            {
                currentDepartment.FacultyStudents.Remove(targetStudent);
            }
            
            targetFac.FacultyStudents.Add(targetStudent);            
            context.SaveChanges();

            var currentStudies = context.StudentSubjectTable.Where(ss => ss.Student == targetStudent);
            context.StudentSubjectTable.RemoveRange(currentStudies);
            context.SaveChanges();
            AssignStudentToSubject(inputedName, targetFac.Fac_Id);
            context.SaveChanges();

        }

        public void AssignStudentToSubject(string name, int facID) 
        {
            using var context = new StudiesContext();

            var targetStudent = context.StudentsTable.FirstOrDefault(f => f.Name == name);
            var targetFac = context.FacultiesTable.Find(facID);

            var facultySubejcts = context.FacultiesSubjectsTable.Where(fs => fs.FacultyID ==  facID).Select(fs => fs.Subject).ToList();
                //FacultiesTable.FirstOrDefault(f => f.Fac_Id == targetStudent.Fac_Id);
            if (facultySubejcts != null)
            {
                foreach (var subject in facultySubejcts) 
                {
                    var newStudentSubject = new StudentSubject(targetStudent, subject);
                    context.StudentSubjectTable.Add(newStudentSubject);
                }
                
            }

            targetFac.FacultyStudents.Add(targetStudent);

            context.SaveChanges();

        }
        public Faculty SelectFacultyByDirection(string direction)
        {
            using var context = new StudiesContext();
            var facultyByDirection = context.FacultiesTable.FirstOrDefault(f => f.Direction == direction);
            return facultyByDirection;
        }

        public void AddSubjectsToStudent(Student student, Faculty faculty)
        {
/*            using var context = new StudiesContext();
            var subject = new Subject();

//            var selectedFaculty = context.FacultiesTable.FirstOrDefault(f => f.Fac_Id == facultyID);
            
 //           var selectedStudent = context.StudentsTable.FirstOrDefault(s => s.Id == studentID);

            var selectedSubjects = subject.SelectSubjectsByFaculty(faculty.Fac_Id);
            foreach (var sItem in selectedSubjects) 
            {
                var newStudentFacultySubject = new FacultyStudentSubject(faculty.Fac_Id, sItem.Id, student.S_Id, faculty, subject, student);
                var studentFacultySubject = context.Add(newStudentFacultySubject);
                context.SaveChanges();
            }*/
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

        // savybes ir konstruktoriai
        public Student() { }
        public Student(string name, string direction)
        {
            PersonalId = Guid.NewGuid();
            Name = name;
            Direction = direction;
        }

        [Key]
        [Column(Order = 0 )]
        public int S_Id { get; set; }

        [Column(Order = 2)]
        public Guid PersonalId { get; set; }

        [Column("Student name", Order = 1)]
        [MaxLength(100)]        
        public string Name { get; set; }
        [Required]
              
        [Column("Student's Faculty")]
        public string Direction { get; set; }

        [ForeignKey("FacID")]
        public int Fac_Id { get; set; }
        public Faculty Faculty { get; set; }

        public IList<StudentSubject> StudentSubjects { get; set; } = new List<StudentSubject>();

    }
}
