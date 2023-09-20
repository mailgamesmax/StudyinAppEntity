using StudyinAppEntity.Database;
using StudyinAppEntity.Models;

namespace StudyinAppEntity
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, my StydyingApp on Entity!");

            do 
            {
            Console.Write("Pasirinkite veiksma TIK SKAICIAI");
            ActionMeniu();
            int userInput = int.Parse(Console.ReadLine());

                switch (userInput)                 
                    { 
                    case 1:
                        AddFaculty();
                        break;
                    case 2:
                        AddSubject();
                        break;
                    case 3:
                        AddStudent();
                        break;
                    case 4:
                        changeStudentFaculty();
                        break;
                    case 0:
                    Console.WriteLine("chao");
                    Environment.Exit(0);
                    break;
                    default:
                    Console.WriteLine("chao");
                    Environment.Exit(0);
                    break;
                }
                Console.WriteLine();
            }
            while (true);

        }

        public static void ActionMeniu()
        {
            Console.WriteLine
                (
            "\n\t0 - close program\n1 - prideti fakultete\n 2 - prideti dalyka/paskaita\n" +
                "3 - prideti studenta\n 4 - duoti fuxui antra sansa"
        
                );
        }
        public static void AddFaculty() 
        {
            string inputChoice;
            do 
            {
            var faculty = new Faculty();
            faculty.AddFaculty();

            Console.Write("dar vienas? (+)");
            inputChoice = Console.ReadLine();
            }
            while (inputChoice == "+");
        }

        public static void AddSubject()
        {         
            var subject = new Subject();         
            subject.AddSubject();           
        }

        public static void AddStudent()
        {
        var student = new Student();
        student.AddStudent();
        }

        public static void changeStudentFaculty() 
        {
            var student = new Student();
            student.changeStudentFaculty();
        }
    }
}