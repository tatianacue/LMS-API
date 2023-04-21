using Library.LMS.Models;
using UWP.Library.CueLMS.Database;

namespace CueLMS.Api.EC
{
    public class AnnouncementEC
    {
        public List<Announcement> GetAnnouncements()
        {
            return FakeDatabaseContext.Announcements;
        }

        public Announcement AddOrUpdateAnnouncement(Announcement a)
        {
            var itemToUpdate = FakeDatabaseContext.Announcements.FirstOrDefault(x => x.Id == a.Id);
            if (itemToUpdate != null)
            {
               FakeDatabaseContext.Announcements.Remove(itemToUpdate);
               FakeDatabaseContext.Announcements.Add(a);
            }
            else
            {
               FakeDatabaseContext.Announcements.Add(a);
            }
            return a;
        }
    }
}
