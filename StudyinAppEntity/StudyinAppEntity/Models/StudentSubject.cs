﻿using System;
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
        
        public string StudentID { get; set; }
        public Student Student { get; set; }

        public string SubjectID { get; set; }
        public Subject Subject { get; set; }
    }
}
