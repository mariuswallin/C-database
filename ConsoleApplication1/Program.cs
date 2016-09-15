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
            var course = new Course() { Name = "C#" };

            var newId = logic.AddCourse(course);
            logic.AddStudent(new Student() { FirstName = "Lars" });

            logic.AddStudentToCourse(1, newId);
        }
    }
}
