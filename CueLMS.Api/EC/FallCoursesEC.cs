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
                if (FakeDatabaseContext.FallCourses.Count > 0)
                {
                    lastId = FakeDatabaseContext.FallCourses.Select(x => x.Id).Max();
                }
                else
                {
                    lastId = 0;
                }
                c.Id = ++lastId;
                FakeDatabaseContext.FallCourses.Add(c);
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
    }
}
