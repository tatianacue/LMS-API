using CueLMS.Api.EC;
using Library.LMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace CueLMS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnnouncementController
    {
        private readonly ILogger<AnnouncementController> _logger;

        public AnnouncementController(ILogger<AnnouncementController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<Announcement> GetAnnouncements()
        {
            return new AnnouncementEC().GetAnnouncements();
        }

        [HttpPost]
        public Announcement AddOrUpdate([FromBody] Announcement announcement)
        {
            return new AnnouncementEC().AddOrUpdateAnnouncement(announcement);
        }
    }
}
