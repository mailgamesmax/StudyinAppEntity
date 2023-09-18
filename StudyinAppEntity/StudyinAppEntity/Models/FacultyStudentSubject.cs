using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyinAppEntity.Models
{
    [Table("Faculties, Students and Subjects")]
    internal class FacultyStudentSubject
    {

        //savybes ir konstruktoriai
        public FacultyStudentSubject() { }

        public FacultyStudentSubject(int facultyID, int subjectID, Faculty faculty, Subject subject)
        {
            FacultyID = facultyID;
            SubjectID = subjectID;
            Faculty = faculty;
            Subject = subject;
        }

        public FacultyStudentSubject(int facultyID, int subjectID, Guid studentID)
        {
            FacultyID = facultyID;            
            SubjectID = subjectID;
            StudentID = studentID;
        }
        public FacultyStudentSubject(int facultyID, int subjectID, Guid studentID, Faculty faculty, Subject subject, Student student) : this(facultyID, subjectID, studentID)
        {
            Subject = subject;
            StudentID = studentID;
            Student = student;
        }

        public int FacultyID { get; set; }
        public Faculty Faculty { get; set; }

        public int SubjectID { get; set; }
        public Subject Subject { get; set; }

        public Guid StudentID { get; set; }
        public Student Student { get; set; }
    }
}
