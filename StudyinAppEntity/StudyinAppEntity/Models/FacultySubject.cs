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
        public string FacultyID { get; set; }
        public Faculty Faculty { get; set; }

        public string SubjectID { get; set; }
        public Subject Subject { get; set; }
    }
}
