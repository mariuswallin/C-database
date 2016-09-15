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
        public void AddStudent(Student student)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Students.Add(student);
                dataContext.SaveChanges();
            }                    
        }

        public int AddCourse(Course course)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Courses.Add(course);
                dataContext.SaveChanges();

                return course.Id;
            }
        }

        public List<Student> GetAllStudents()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Students.ToList();
            }
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
