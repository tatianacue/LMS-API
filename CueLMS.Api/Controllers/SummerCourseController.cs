using CueLMS.Api.EC;
using Library.LMS.Models;
using Microsoft.AspNetCore.Mvc;
/* Tatiana Graciela Cue COP4870-0001*/
namespace CueLMS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SummerCourseController
    {
        private readonly ILogger<SummerCourseController> _logger;

        public SummerCourseController(ILogger<SummerCourseController> logger)
        {
            _logger = logger;
        }

        [HttpGet("")]
        public List<Course> GetCourses()
        {
            return new SummerCoursesEC().GetCourses();
        }

        [HttpPost("")]
        public void AddOrUpdate([FromBody] Course course)
        {
            new SummerCoursesEC().AddOrUpdateCourse(course);
        }

        [HttpDelete("")]
        public void Delete([FromBody] Course course)
        {
            new SummerCoursesEC().DeleteCourse(course);
        }

        [HttpGet("GetRoster/{id}")]
        public List<Student> GetStudents(int id)
        {
            return new SummerCoursesEC().GetRoster(id);
        }

        [HttpPost("AddToRoster")]
        public void RosterAdd([FromBody] Course course)
        {
            new SummerCoursesEC().AddToRoster(course);
        }

        [HttpDelete("RemoveFromRoster")]
        public void RosterRemove([FromBody] Course course)
        {
            new SummerCoursesEC().RemoveFromRoster(course);
        }
    }
}
