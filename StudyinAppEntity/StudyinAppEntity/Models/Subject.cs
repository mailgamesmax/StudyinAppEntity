﻿using StudyinAppEntity.Database;
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

            var newSubject = new Subject(inputTitle);
            context.SubjectsTable.Add(newSubject);
            context.SaveChanges();
                
            int newID = newSubject.Id;
            AddSubjecToFaculty(newID);

            Console.Write("dar vienas? (+)");
            inputChoice = Console.ReadLine();
            }
            while (inputChoice == "+");
        }

        public void AddSubjecToFaculty(int subjectID) 
        {
            Console.Write("Kur bus dėstomda? (suvesti ID per kablelį)");
            var inputedFaculties = InputedNrToList();

            using var context = new StudiesContext();

            var selectedSubject = context.SubjectsTable.Find(subjectID);

            foreach (var inputedNr in inputedFaculties)
            {                
            var selectedFaculty = context.FacultiesTable.Find(inputedNr);

                if (selectedFaculty != null)
                {                    
                    var newFacultySubject = new FacultySubject(selectedFaculty,selectedSubject);
                    selectedFaculty.FacultiesSubjects.Add(newFacultySubject);
                    context.SaveChanges();
                }
                //            new FacultySubject(selectedFaculty, selectedSubject, inputedNr,  subjectID);

                //selectedFaculty.FacultiesSubjects.Add(selectedSubject);
                context.SaveChanges();
            }        
        }

        public static void ShowSubjectsByFacultyID(int facID)
        {
            using var context = new StudiesContext();

            var facultySubjects = context.FacultiesSubjectsTable.Where(f => f.FacultyID == facID).ToList();            

            Console.WriteLine("Dalykų sąrašas:");

            foreach (var facultySubject in facultySubjects)
            {
                var subjectName = context.SubjectsTable.Where(s => s.Id == facultySubject.SubjectID).Select(s => s.Title).FirstOrDefault(); 
                Console.WriteLine($"pavadinimas -> {subjectName}, Subject ID: {facultySubject.SubjectID}");
            }
        }

        public static void ShowSubjectsByStudent(string name)
        {
            using var context = new StudiesContext();

            var studentSubjects = context.StudentSubjectTable.Where(ss => ss.Student.Name == name).ToList();

            Console.Write("Studento fac:");
            Console.WriteLine($"{(context.StudentsTable.FirstOrDefault(s => s.Name == name)).Direction}");

            Console.WriteLine("Dalykų sąrašas:");

            foreach (var subject in studentSubjects)
            {
                var subjectName = context.SubjectsTable.Where(s => s.Id == subject.SubjectID).Select(s => s.Title).FirstOrDefault();
                Console.WriteLine($"-> {subjectName}");
            }
        }
        public int SubjectIdGetterByTitle(string title)
        {
            using var context = new StudiesContext();
            var selectedSubject = context.SubjectsTable.FirstOrDefault(a => a.Title == title);
            int subjectID = selectedSubject.Id;
            return subjectID;
        }
        /*        public List<Subject> SelectSubjectsByFaculty(int facultyID) 
                {
                    using var context = new StudiesContext();
                    var selectedSubjects = context.FacultiesSubjectsTable.Where(ab => ab.FacultyID == facultyID).Select(ab => ab.Subject).ToList();
                    return selectedSubjects;
                }*/


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
        //public int FacultyID { get; set; }                

        public IList<FacultySubject> FacultiesSubjects { get; set; } = new List<FacultySubject>();
        public IList<Faculty> Faculties
        {
            get { return FacultiesSubjects.Select(fs => fs.Faculty).ToList(); }
        }

        public IList<StudentSubject> SubjectStudents { get; set; } = new List<StudentSubject>();
    }
}
