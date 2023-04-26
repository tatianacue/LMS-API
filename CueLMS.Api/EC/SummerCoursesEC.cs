using Library.LMS.Models;
using UWP.Library.CueLMS.Database;

namespace CueLMS.Api.EC
{
    public class SummerCoursesEC
    {
        public List<Course> GetCourses()
        {
            return FakeDatabaseContext.SummerCourses;
        }

        public void AddOrUpdateCourse(Course c)
        {
            if (c.Id > 0)
            {
                var itemToUpdate = FakeDatabaseContext.SummerCourses.FirstOrDefault(x => x.Id == c.Id);
                if (itemToUpdate != null)
                {
                    FakeDatabaseContext.SummerCourses.Remove(itemToUpdate);
                    FakeDatabaseContext.SummerCourses.Add(c);
                }
            }
            else
            {
                int lastId;
                if (FakeDatabaseContext.CourseIds.Count > 0) {
                    lastId = FakeDatabaseContext.CourseIds.Max();
                }
                else
                {
                    lastId = 0;
                }
                c.Id = ++lastId;
                FakeDatabaseContext.SummerCourses.Add(c);
                FakeDatabaseContext.CourseIds.Add(c.Id); // adds to course id database
            }
        }
        public void DeleteCourse(Course c)
        {
            var item = FakeDatabaseContext.SummerCourses.FirstOrDefault(x => x.Id == c.Id);
            if (item != null)
            {
                FakeDatabaseContext.SummerCourses.Remove(item);
            }
        }
        public List<Student> GetRoster(int id)
        {
            var course = FakeDatabaseContext.SummerCourses.FirstOrDefault(x => x.Id == id); //course that matches
            if (course != null)
            {
                return course.Roster;
            }
            else { return new List<Student>(); }
        }
        public void AddToRoster(Course c)
        {
            var course = FakeDatabaseContext.SummerCourses.FirstOrDefault(x => x.Id == c.Id);
            if (course != null)
            {
                course.Roster.Add(c.SelectedStudent);
            }
        }
    }
}
