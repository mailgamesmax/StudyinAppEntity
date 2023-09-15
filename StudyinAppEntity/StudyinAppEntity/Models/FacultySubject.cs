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
        public int FacultyID { get; set; }
        public Faculty Faculty { get; set; }

        public int SubjectID { get; set; }
        public Subject Subject { get; set; }
    }
}
