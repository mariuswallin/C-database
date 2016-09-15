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
        }

        public int AddCourse(Course course)
        {
            HandleDBContext(dataContext => {
                dataContext.Courses.Add(course);
                dataContext.SaveChanges();

            });

            return course.Id;
        }

        public List<Student> GetAllStudents()
        {
            return HandleDBContext(dataContext => dataContext.Students.ToList());
        }

        public List<Course> GetAllCourses()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Courses.ToList();
            }
        }

        public void AddStudentToCourse(int studentId, int courseId)
        {
            using (var dataContext = new DataContext())
            {

                var student = dataContext.Students.SingleOrDefault(x => x.ID == studentId);
                if (student == null)
                    throw new Exception($"Student {studentId} not found");

                var course = dataContext.Courses.SingleOrDefault(x => x.Id == courseId);
                if(course == null)
                    throw new Exception($"Course {courseId} not found");

                student.Courses = new List<Course>();
                student.Courses.Add(course);

                dataContext.SaveChanges();

            }
        }
    }
}
