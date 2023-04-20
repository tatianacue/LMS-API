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

        public Course AddOrUpdateCourse(Course c)
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
                var lastId = FakeDatabaseContext.FallCourses.Select(x => x.Id).Max();
                c.Id = ++lastId;
                FakeDatabaseContext.FallCourses.Add(c);
            }
            return c;
        }
    }
}
