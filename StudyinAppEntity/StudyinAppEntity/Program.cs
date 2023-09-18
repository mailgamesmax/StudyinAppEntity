using StudyinAppEntity.Database;
using StudyinAppEntity.Models;

namespace StudyinAppEntity
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, my StydyingApp on Entity!");

            //using var context = new StudiesContext();
            var student = new Student();
            var faculty = new Faculty();
            var subject = new Subject();

            /*faculty.AddFaculty();
            faculty.AddFaculty();
            faculty.AddFaculty();*/
            //            subject.AddSubject();
            student.AddStudent();

            //student.AddStudent("Mantas", "Ekonomika");

/*            var userInput = Console.ReadLine();

            List<string> inputedElements = userInput.Split(',').Select(x => x.Trim()).Where(x => !string.IsNullOrEmpty(x)).ToList();

            foreach (var inputedElement in inputedElements)
            {
                Console.WriteLine(inputedElement);
            }*/

            //            Console.Write("Kur bus dėstomda? (išvardinti per kablelį)");

        }
    }
}