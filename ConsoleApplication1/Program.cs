using DataLayer;
using DataLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Skriv inn fornavn:");
            var firstname = Console.ReadLine();

            var logic = new StudentLogic();
            logic.AddStudent(new Student() { FirstName = firstname });

            Console.WriteLine("Ny student lagt til");

            foreach (var i in logic.GetAllStudents())
            {
                Console.WriteLine(i.ToString());
            }*/

            var logic = new StudentLogic();
            //var course = new Course() { Name = "C#" };
            //var course2 = new Course() { Name = "Java" };

            //var newId = logic.AddCourse(course);
            //var newIde = logic.AddCourse(course2);
            //logic.AddStudent(new Student() { FirstName = "Lars" });
            //logic.AddStudent(new Student() { FirstName = "Kåre" });

            var course2 = new Course() { Name = "Swift" };
            var newIde = logic.AddCourse(course2);
            logic.AddStudent(new Student() { FirstName = "Finn" });

            logic.AddStudentToCourse(4, newIde);
            //logic.AddStudentToCourse(2, newIde);

            Console.WriteLine(logic.GetAllStudents());
        }
    }
}
