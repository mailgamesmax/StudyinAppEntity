using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyinAppEntity.Models
{
    [Table("Students and Subjects")]
    internal class StudentSubject
    {
        public StudentSubject() { }
        public StudentSubject(Student student, Subject subject)
        {
            Student = student;
            Subject = subject;
        }

        public StudentSubject(Student student, Subject subject, Guid studentID, int subjectID) : this(student, subject) 
        {
            StudentID = studentID;        
            SubjectID = subjectID;
        }

        public Guid StudentID { get; set; }
        public Student Student { get; set; }

        public int SubjectID { get; set; }
        public Subject Subject { get; set; }
    }
}
