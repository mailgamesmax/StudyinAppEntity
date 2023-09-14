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
        // savybes ir konstruktoriai
        [Key]     
        public Guid Id { get; set; }

        [Column("Student name", Order = 0)]
        [MaxLength(100)]        
        public string Name { get; set; }
        [Required]

        public string FacultyID { get; set; }                
        public string FacultyName { get; set; } 
        public IList<StudentSubject> StudentSubjects { get; set; } = new List<StudentSubject>();
        
        public static List<Student> Students { get; set;} = new List<Student>();


    }
}
