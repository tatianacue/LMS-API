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

        [HttpGet("GetList/{id}")]
        public List<Announcement> GetAnnouncements(int id)
        {
            return new AnnouncementEC().GetAnnouncements(id);
        }

        [HttpPost]
        public void AddOrUpdate([FromBody] Course course)
        {
           new AnnouncementEC().AddOrUpdateAnnouncement(course);
        }
    }
}
