using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class ListStudentCommandHandler : ICommandItem
    {
        private StudentLogic _logic;

        public ListStudentCommandHandler(StudentLogic logic)
        {
            _logic = logic;
        }

        public bool HandleCommand(string command)
        {
            if(command == "l")
            {
                var students = _logic.GetAllStudents();
                foreach (var student in students)
                    Console.WriteLine(student.ToString());

                return true;
            }
            return false;
        }
    }
}
