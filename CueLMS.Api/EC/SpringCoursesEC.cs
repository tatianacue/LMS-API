using Library.LMS.Models;
using UWP.Library.CueLMS.Database;

namespace CueLMS.Api.EC
{
    public class SpringCoursesEC
    {
        public List<Course> GetCourses()
        {
            return FakeDatabaseContext.SpringCourses;
        }

        public Course AddOrUpdateCourse(Course c)
        {
            if (c.Id > 0)
            {
                var itemToUpdate = FakeDatabaseContext.SpringCourses.FirstOrDefault(x => x.Id == c.Id);
                if (itemToUpdate != null)
                {
                    FakeDatabaseContext.SpringCourses.Remove(itemToUpdate);
                    FakeDatabaseContext.SpringCourses.Add(c);
                }
            }
            else
            {
                var lastId = FakeDatabaseContext.SpringCourses.Select(x => x.Id).Max();
                c.Id = ++lastId;
                FakeDatabaseContext.SpringCourses.Add(c);
            }
            return c;
        }
    }
}
