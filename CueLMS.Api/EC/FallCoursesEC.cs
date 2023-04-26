using Library.LMS.Models;
using UWP.Library.CueLMS.Database;

namespace CueLMS.Api.EC
{
    public class FallCoursesEC
    {
        public List<Course> GetCourses()
        {
            return FakeDatabaseContext.FallCourses;
        }

        public void AddOrUpdateCourse(Course c)
        {
            if (c.Id > 0)
            {
                var itemToUpdate = FakeDatabaseContext.FallCourses.FirstOrDefault(x => x.Id == c.Id);
                if (itemToUpdate != null)
                {
                    FakeDatabaseContext.FallCourses.Remove(itemToUpdate);
                    FakeDatabaseContext.FallCourses.Add(c);
                }
            }
            else
            {
                int lastId;
                if (FakeDatabaseContext.CourseIds.Count > 0)
                {
                    lastId = FakeDatabaseContext.CourseIds.Max();
                }
                else
                {
                    lastId = 0;
                }
                c.Id = ++lastId;
                FakeDatabaseContext.FallCourses.Add(c);
                FakeDatabaseContext.CourseIds.Add(c.Id);
            }
        }
        public void DeleteCourse(Course c)
        {
            var item = FakeDatabaseContext.FallCourses.FirstOrDefault(x => x.Id == c.Id);
            if (item != null)
            {
                FakeDatabaseContext.FallCourses.Remove(item);
            }
        }
        public List<Student> GetRoster(int id)
        {
            var course = FakeDatabaseContext.FallCourses.FirstOrDefault(x => x.Id == id); //course that matches
            if (course != null)
            {
                return course.Roster;
            }
            else { return new List<Student>(); }
        }
        public void AddToRoster(Course c)
        {
            var course = FakeDatabaseContext.FallCourses.FirstOrDefault(x => x.Id == c.Id);
            if (course != null)
            {
                course.Roster.Add(c.SelectedStudent);
            }
        }
        public void RemoveFromRoster(Course c)
        {
            var course = FakeDatabaseContext.FallCourses.FirstOrDefault(x => x.Id == c.Id);
            if (course != null)
            {
                var selected = c.SelectedStudent;
                var student = course.Roster.FirstOrDefault(x => x.IdNumber == selected.IdNumber);
                if (student != null)
                {
                    course.Roster.Remove(student);
                }
            }
        }
    }
}
