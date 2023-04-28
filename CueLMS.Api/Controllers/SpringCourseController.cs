using CueLMS.Api.EC;
using Library.LMS.Models;
using Microsoft.AspNetCore.Mvc;
/* Tatiana Graciela Cue COP4870-0001*/
namespace CueLMS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpringCourseController
    {
        private readonly ILogger<SpringCourseController> _logger;

        public SpringCourseController(ILogger<SpringCourseController> logger)
        {
            _logger = logger;
        }

        [HttpGet("")]
        public List<Course> GetCourses()
        {
            return new SpringCoursesEC().GetCourses();
        }

        [HttpPost("")]
        public void AddOrUpdate([FromBody] Course course)
        {
            new SpringCoursesEC().AddOrUpdateCourse(course);
        }

        [HttpDelete("")]
        public void Delete([FromBody] Course course)
        {
            new SpringCoursesEC().DeleteCourse(course);
        }

        [HttpGet("GetRoster/{id}")]
        public List<Student> GetStudents(int id)
        {
            return new SpringCoursesEC().GetRoster(id);
        }

        [HttpPost("AddToRoster")]
        public void RosterAdd([FromBody] Course course)
        {
            new SpringCoursesEC().AddToRoster(course);
        }

        [HttpDelete("RemoveFromRoster")]
        public void RosterRemove([FromBody] Course course)
        {
            new SpringCoursesEC().RemoveFromRoster(course);
        }
    }
}
