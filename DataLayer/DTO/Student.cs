using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTO
{
    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }

        public ICollection<Course> Courses { get; set; }

        public override string ToString()
        {
            return $"ID: {ID} Firstname: {FirstName}";
        }
    }
}
