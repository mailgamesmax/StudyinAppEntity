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
    internal class Faculty
    {
        public void AddFaculty()
        {
            using var context = new StudiesContext();
            
            Console.Write("Fakulteto krytpis/pavadinimas? ");
            string inputDirection = Console.ReadLine();
            int newID = idEasyGenerator();
                        
            var faculty = context.FacultiesTable.Add(new Faculty(newID, inputDirection));
            context.SaveChanges();
        }

        public int idEasyGenerator()
        {
            int newID;
            var faculty = new StudiesContext();
            var currentMaxID = faculty.FacultiesTable.Max(f => f.Id);

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

        public IList<FacultySubject> selectFacultySubjects(string direction ) 
        {
            using var context = new StudiesContext();
            var facultySubjects = context.FacultiesTable.FirstOrDefault(f => f.Direction == direction);
            return facultySubjects.FacultySubjects;
        }

        // savybes ir konstruktoriai
        public Faculty() { }
        public Faculty(int id, string direction)
        {
            Id = id;
            Direction = direction;
/*            FacultyStudents = facultyStudents;
            FacultySubjects = facultySubjects;
*/        }

        [Key]
        public int Id { get; set; }

        [Column("Direction(like Title)")]
        public string Direction { get; set; } // instead of name
        public List<Student> FacultyStudents { get; set; } = new List<Student>();

        //public static List<Faculty> AllFaculties { get; set; } = new List<Faculty>();

        public IList<FacultySubject> FacultySubjects { get; set; } = new List<FacultySubject>();
        //public IList<Subject> FacultySubjects { get; set; }
    }
}
