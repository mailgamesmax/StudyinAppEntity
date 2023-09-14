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


        // savybes ir konstruktoriai
        [Key]
        public Guid Id { get; set; }

        [Column("Direction(like Title)")]
        public string Direction { get; set; } // instead of name
        public List<Student> FacultyStudents { get; set; } = new List<Student>();

        public static List<Faculty> Faculties { get; set; } = new List<Faculty>();

        public IList<FacultySubject> FacultySubjects { get; set; }
        //public IList<Subject> FacultySubjects { get; set; }
    }
}
