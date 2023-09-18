using StudyinAppEntity.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace StudyinAppEntity.Models
{
    //[Table("AvailibleSubjects")]

    internal class Subject : CommonFunctions
    {
        public void AddSubject()
        {
            using var context = new StudiesContext();

            string inputChoice;
            do 
            {            
            Console.Write("Naujo dalyko pavadinimas? ");
            string inputTitle = NormalizeInputForTitle()[0];

            var subject = context.SubjectsTable.Add(new Subject(inputTitle));
            context.SaveChanges();
                
            int newID = SubjectIdGetterByTitle(inputTitle);

            AddSubjecToFaculty(newID);

            Console.Write("dar vienas? (+)");
            inputChoice = Console.ReadLine();
            }
            while (inputChoice == "+");
        }

        public int SubjectIdGetterByTitle(string title)
        {
            using var context = new StudiesContext();
            var selectedSubject = context.SubjectsTable.FirstOrDefault(abc => abc.Title == title);
            int subjectID = selectedSubject.Id;
            return subjectID;
        }

        public void AddSubjecToFaculty(int subjectID) 
        {
            Console.Write("Kur bus dėstomda? (suvesti ID per kablelį)");
            var inputedFaculties = InputedNrToList();

            using var context = new StudiesContext();

            foreach (var inputedNr in inputedFaculties)
            {                
            var selectedFaculty = context.FacultiesTable.FirstOrDefault(f => f.Fac_Id == inputedNr);

            var selectedSubject = context.SubjectsTable.FirstOrDefault(s => s.Id == subjectID);

            var newFacultySubject = new FacultySubject(inputedNr,  subjectID, selectedFaculty, selectedSubject);

            selectedFaculty.FacultiesSubjects.Add(newFacultySubject);

            context.SaveChanges();
            }        
        }

        public List<Subject> SelectStudiesByFaculty(int facultyID) 
        {
            using var context = new StudiesContext();
            var selectedSubjects = context.FacultiesSubjectsTable.Where(ab => ab.FacultyID == facultyID).Select(ab => ab.Subject).ToList();
            return selectedSubjects;
        }


        // savybes ir konstruktoriai
        public Subject() { }
        public Subject(string title)
        {
            Title = title;
/*            FacultyID = facultyID;
            SubjectFaculties = subjectFaculties;
            SubjectStudents = subjectStudents;
*/      }

        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        //public string FacultyID { get; set; }                

        public IList<FacultyStudentSubject> FacultiesStudentsSubjects { get; set; } = new List<FacultyStudentSubject>();

        public IList<FacultySubject> FacultiesSubjects { get; set; } = new List<FacultySubject>();

    }
}
