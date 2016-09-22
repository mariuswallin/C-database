using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace StudentService
{
    public class Student
    {
        public Student()
        {
            Courses = new Collection<Course>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} Navn: {Name}";
        }
    }
}
