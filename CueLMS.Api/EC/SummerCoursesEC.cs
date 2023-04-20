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

        public Course AddOrUpdateCourse(Course c)
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
                var lastId = FakeDatabaseContext.SummerCourses.Select(x => x.Id).Max();
                c.Id = ++lastId;
                FakeDatabaseContext.SummerCourses.Add(c);
            }
            return c;
        }
    }
}
