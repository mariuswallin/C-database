using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentService
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
            return HandleDBContext(dataContext => dataContext.Courses.ToList());
        }

        public bool AddStudentToCourse(int studentId, int courseId)
        {

            if (ValidateInput(studentId, courseId))
            { 
                var status = HandleDBContext(dataContext => {
                    var student = dataContext.Students.SingleOrDefault(x => x.Id == studentId);
                    var course = dataContext.Courses.SingleOrDefault(x => x.Id == courseId);
                    if (course == null || student == null)
                        return false;
                    student.Courses.Add(course);
                    dataContext.SaveChanges();
                    return true;

                });

                return status;

            } else

            {
                return false;
            }
        }

    public bool ValidateInput(int x, int y)
        {
            if (x.ToString().Length > 0 && y.ToString().Length > 0)
            {
                return true;
            }

            return false;
        }

    }
}
