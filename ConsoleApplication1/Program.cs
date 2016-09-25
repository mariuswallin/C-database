using StudentService;
using System;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteOptions();
            var line = Console.ReadLine().ToLower();
            while (line != "q")
            {
                ParseCommand(line);
                line = Console.ReadLine().ToLower();
            }
        }

        private static void ParseCommand(string command)
        {
            switch (command)
            { 
                case "h":
                    ShowHelp();
                    break;

                case "c":
                    AddCourse();
                    break;

                case "s":
                    AddStudent();
                    break;

                case "ac":
                    ListAllCourses();
                    break;

                case "as":
                    ListAllStudents();
                    break;

                case "sc":
                    AddStudentToCourse();
                    break;

                default:
                    UnknownCommand();
                    break;
            }
        }

        private static StudentLogic logic = new StudentLogic();


        private static void WriteOptions()
        {
            Console.WriteLine("Trykk q for quit eller h for hjelp");
        }

        private static void UnknownCommand()
        {
            Console.WriteLine("Ukjent kommando. Press h for hjelp");
        }

        private static void ShowHelp()
        {
            Console.WriteLine(@"Tilgjengelige kommandoer: 
                                h - hjelp, 
                                ac - vis alle kurs, 
                                as - vis alle studenter, 
                                s - legg til student,
                                c - legg til kurs, 
                                sc - legg til student til kurs
                                q - quit");
        }
   
        private static void AddStudent()
        {
            Console.WriteLine("Skriv inn studentnavn:");
            var name = Console.ReadLine();
            if (name.Length > 0)
            {
                logic.AddStudent(new Student() { Name = name });
            } else
            {
                Console.WriteLine("Du må skrive et studentnavn");
                AddStudent();
            }
        }

        private static void AddCourse()
        {
            Console.WriteLine("Skriv inn kursnavn:");
            var name = Console.ReadLine();
            if (name.Length > 0)
            {
                logic.AddCourse(new Course() { Name = name });
            }
            else
            {
                Console.WriteLine("Du må skrive et kursnavn");
                AddCourse();
            }
        }

        private static void AddStudentToCourse()
        {
            while (true) {
                ListAllCourses();
                Console.WriteLine("\n");
                ListAllStudents();
                Console.WriteLine("Velg nr studentnr og kursnummer (skilt med mellomrom):");
                var choice = Console.ReadLine();
                try
                {
                    var arguments = choice.Split(' ');
                    var arg1 = arguments[0];
                    var arg2 = arguments[1];
                    int number;
                    int number2;
                    bool result1 = Int32.TryParse(arg1, out number);
                    bool result2 = Int32.TryParse(arg2, out number2);
                    if (result1 && result2 && logic.AddStudentToCourse(number, number2))
                    {
                        Console.WriteLine("Studenten ble lagt til");
                        break;
                    } else
                    {
                        Console.WriteLine("-------");
                        Console.WriteLine("Feil eller ugyldig nummer. Prøv igjen");
                        Console.WriteLine("-------");
                    }

                } catch(IndexOutOfRangeException)
                {
                    Console.WriteLine("-------");
                    Console.WriteLine("Fyll in to tall");
                    Console.WriteLine("-------");
                }
            }
        }

        private static void ListAllStudents()
        {
            Console.WriteLine("StudentListe:");
            logic.GetAllStudents().ForEach(student => Console.WriteLine(student.ToString()));
        }

        private static void ListAllCourses()
        {
            Console.WriteLine("KursListe:");
            logic.GetAllCourses().ForEach(course => Console.WriteLine(course.ToString()));
        }
    }
}
