using Library.LMS.Models;
using UWP.Library.CueLMS.Database;

namespace CueLMS.Api.EC
{
    public class AnnouncementEC
    {
        public List<Announcement> GetAnnouncements(int id)
        {
            var Course = FakeDatabaseContext.SpringCourses.FirstOrDefault(x => x.Id == id);
            if (Course == null)
            {
                Course = FakeDatabaseContext.FallCourses.FirstOrDefault(x => x.Id == id);
            }
            if (Course == null)
            {
                Course = FakeDatabaseContext.SummerCourses.FirstOrDefault(x => x.Id == id);
            }
            if (Course != null)
            {
                return Course.Announcements;
            }
            else
            {
                return new List<Announcement>();
            }
        }

        public void AddOrUpdateAnnouncement(Course c)
        {
            var Course = FakeDatabaseContext.SpringCourses.FirstOrDefault(x => x.Id == c.Id);
            if (Course == null)
            {
                Course = FakeDatabaseContext.FallCourses.FirstOrDefault(x => x.Id == c.Id);
            }
            if (Course == null)
            {
                Course = FakeDatabaseContext.SummerCourses.FirstOrDefault(x => x.Id == c.Id);
            }
            if (Course != null)
            {
                var announcement = c.SelectedAnnouncement;
                if (announcement.Id > 0)
                {
                    var itemToUpdate = Course.Announcements.FirstOrDefault(x => x.Id == announcement.Id);
                    if (itemToUpdate != null)
                    {
                        Course.Announcements.Remove(itemToUpdate);
                        Course.Announcements.Add(announcement);
                    }
                }
                else
                {
                    int lastId;
                    if (Course.Announcements.Count > 0)
                    {
                        lastId = Course.Announcements.Select(x => x.Id).Max();
                    }
                    else
                    {
                        lastId = 0;
                    }
                    announcement.Id = ++lastId;
                    Course.Announcements.Add(announcement);
                }
            }
        }
    }
}
