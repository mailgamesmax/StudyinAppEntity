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
    internal class Faculty : CommonFunctions
    {
        public void AddFaculty()
        {
            using var context = new StudiesContext();
            
            Console.Write("Fakulteto krytpis/pavadinimas? ");
            string inputDirection = Console.ReadLine();
            //int newID = idEasyGenerator();

            //var newFaculty = new Faculty(newID, inputDirection);
            var newFaculty = new Faculty(inputDirection);
            var facultyToTable = context.FacultiesTable.Add(newFaculty);
            context.SaveChanges();
        }

        public int idEasyGenerator()
        {
            int newID;
            var faculty = new StudiesContext();
            

            if (faculty.FacultiesTable.Any())
            {
                var currentMaxID = faculty.FacultiesTable.Max(f => f.Fac_Id);
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

        public Faculty SelectFacultyByDirection(string direction) 
        {
            using var context = new StudiesContext();
            var facultyByDirection = context.FacultiesTable.FirstOrDefault(f => f.Direction == direction);
            return facultyByDirection;
        }

        // savybes ir konstruktoriai
        public Faculty() { }
        //public Faculty(int id, string direction)
        public Faculty(string direction)
        {
            //Fac_Id = id;
            Direction = direction;
/*            FacultyStudents = facultyStudents;
            FacultySubjects = facultySubjects;
*/        }

        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Fac_Id { get; set; }

        [Column("Direction(like Title)")]
        public string Direction { get; set; } // instead of name
        public IList<Student> FacultyStudents { get; set; } = new List<Student>();

        //public static List<Faculty> AllFaculties { get; set; } = new List<Faculty>();

        public IList<FacultyStudentSubject> FacultiesStudentsSubjects { get; set; } = new List<FacultyStudentSubject>();
        public IList<FacultySubject> FacultiesSubjects { get; set; } = new List<FacultySubject>();
    }
}
