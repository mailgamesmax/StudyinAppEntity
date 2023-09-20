using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyinAppEntity.Models
{
    [Table("Faculties and Subjects")]
    internal class FacultySubject
    {

        //savybes ir konstruktoriai
        public FacultySubject() { }
        public FacultySubject(Faculty faculty, Subject subject)
        {
            Faculty = faculty;
            Subject = subject;
        }
        public FacultySubject(Faculty faculty, Subject subject, int facultyID, int subjectID) : this(faculty, subject)
        {
            FacultyID = facultyID;
            SubjectID = subjectID;
        }

        public int FacultyID { get; set; }
        public Faculty Faculty { get; set; }

        public int SubjectID { get; set; }
        public Subject Subject { get; set; }
    }
}
