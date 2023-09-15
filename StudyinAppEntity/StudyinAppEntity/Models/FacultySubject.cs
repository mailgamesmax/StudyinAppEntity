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
<<<<<<< HEAD
        public int FacultyID { get; set; }
        public Faculty Faculty { get; set; }

        public int SubjectID { get; set; }
=======
        public string FacultyID { get; set; }
        public Faculty Faculty { get; set; }

        public string SubjectID { get; set; }
>>>>>>> 459e5489078cb0675b0b1eeb9d2fa739fac65d51
        public Subject Subject { get; set; }
    }
}
