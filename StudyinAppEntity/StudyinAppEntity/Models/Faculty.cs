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

            var newFaculty = new Faculty(inputDirection);
            var facultyToTable = context.FacultiesTable.Add(newFaculty);
            context.SaveChanges();
        }

 /*       public Faculty SelectFacultyByDirection(string direction) 
        {
            using var context = new StudiesContext();
            var facultyByDirection = context.FacultiesTable.FirstOrDefault(f => f.Direction == direction);
            return facultyByDirection;
        }
*/

        // savybes ir konstruktoriai
        public Faculty() { }
        
        public Faculty(string direction)
        {
            //Fac_Id = id;
            Direction = direction;
        }

        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Fac_Id { get; set; }

        [Column("Direction(like Title)")]
        public string Direction { get; set; } // instead of name

        [InverseProperty("Faculty")]
        public ICollection<Student> FacultyStudents { get; set; } = new List<Student>();

        public IList<FacultySubject> FacultiesSubjects { get; set; } = new List<FacultySubject>();

/*        public IList<FacultyStudentSubject> FacultiesStudentsSubjects { get; set; } = new List<FacultyStudentSubject>();*/
        //public IList<FacultySubject> FacultiesSubjects { get; set; } = new List<FacultySubject>();
    }
}
