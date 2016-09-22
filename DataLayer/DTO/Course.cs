using System.Collections.Generic;

namespace StudentService
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} Course: {Name}";
        }

    }
}
