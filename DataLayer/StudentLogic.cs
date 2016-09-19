using DataLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{

    public class StudentLogic
    {

        private int? SelectedStudent { get; set; }


        private static void HandleDBContext(Action<DataContext> action)
        {
            using (var dataContext = new DataContext())
                action(dataContext);
        }

        private static T HandleDBContext<T>(Func<DataContext, T> function)
        {
            using (var dataContext = new DataContext())
                return function(dataContext);
        }

        public void AddStudent(Student student)
        {
            HandleDBContext(dataContext => {
                dataContext.Students.Add(student);
                dataContext.SaveChanges();
            });

            Console.WriteLine($"{student.Name} ble lagt til");
        }

        public int AddCourse(Course course)
        {
            HandleDBContext(dataContext => {
                dataContext.Courses.Add(course);
                
                dataContext.SaveChanges();
            });

            Console.WriteLine($"{course.Name} ble lagt til");
            return course.Id;
        }

        public List<Student> GetAllStudents()
        {
            return HandleDBContext(dataContext => dataContext.Students.ToList());
        }

        public List<Course> GetAllCourses()
        {
            return HandleDBContext(dataContext => dataContext.Courses.ToList());
        }

        public bool AddStudentToCourse(int studentId, int courseId)
        {

            using (var dataContext = new DataContext())
            {

                var student = dataContext.Students.SingleOrDefault(x => x.Id == studentId);
                if (student == null)
                    return false;

                var course = dataContext.Courses.SingleOrDefault(x => x.Id == courseId);
                if (course == null)
                    return false;

                student.Courses = new List<Course>();
                student.Courses.Add(course);

                dataContext.SaveChanges();
                Console.WriteLine($"{student.Name} ble lagt til {course.Name}.");
                return true;
            }
        }

    }
}
