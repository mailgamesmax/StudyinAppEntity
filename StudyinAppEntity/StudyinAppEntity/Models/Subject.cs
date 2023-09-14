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
        // savybes ir konstruktoriai
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string FacultyID { get; set; }        
        //public List<string> FacultyName { get; set; } // turbūt naudočiau, bet mokymosi tikslais trauksiu iš objektų       

        public static List<Subject> Subjects { get; set; } = new List<Subject>();

        public IList<FacultySubject> SubjectFaculties { get; set; }
        public IList<StudentSubject> SubjectStudents { get; set; }
        // public List<Student> SubjectStudents { get; set; } = new List<Student>(); //not sure its needed

    }
}
