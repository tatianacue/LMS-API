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
                if (FakeDatabaseContext.SummerCourses.Count > 0) {
                    lastId = FakeDatabaseContext.SummerCourses.Select(x => x.Id).Max();
                }
                else
                {
                    lastId = 0;
                }
                c.Id = ++lastId;
                FakeDatabaseContext.SummerCourses.Add(c);
            }
        }
    }
}
