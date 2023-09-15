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
    //[Table("AvailibleSubjects")]

    internal class Subject
    {
        public int idEasyGenerator()
        {
            int newID;
            var subject = new StudiesContext();
            var currentMaxID = subject.SubjectsTable.Max(s => s.Id);

            if (currentMaxID > 0)
            {
                newID = currentMaxID + 1;
                return newID;
            }
            else
            {
                Console.Write("sąrašas tuščias, įveskite naują int id: ");
                newID = int.Parse(Console.ReadLine());
                return newID;
            }
        }


        // savybes ir konstruktoriai
        public Subject() { }
        public Subject(int id, string title)
        {
            Id = id;
            Title = title;
/*            FacultyID = facultyID;
            SubjectFaculties = subjectFaculties;
            SubjectStudents = subjectStudents;
*/        }

        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string FacultyID { get; set; }        
        //public List<string> FacultyName { get; set; } // turbūt naudočiau, bet mokymosi tikslais trauksiu iš objektų       

        //public static List<Subject> AllSubjects { get; set; } = new List<Subject>();

        public IList<FacultySubject> SubjectFaculties { get; set; } = new List<FacultySubject>();
        public IList<StudentSubject> SubjectStudents { get; set; } = new List<StudentSubject>();
        // public List<Student> SubjectStudents { get; set; } = new List<Student>(); //not sure its needed

    }
}
