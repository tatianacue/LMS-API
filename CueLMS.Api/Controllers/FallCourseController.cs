using CueLMS.Api.EC;
using Library.LMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace CueLMS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FallCourseController
    {
        private readonly ILogger<FallCourseController> _logger;

        public FallCourseController(ILogger<FallCourseController> logger)
        {
            _logger = logger;
        }

        [HttpGet("")]
        public List<Course> GetCourses()
        {
            return new FallCoursesEC().GetCourses();
        }

        [HttpPost("")]
        public void AddOrUpdate([FromBody] Course course)
        {
            new FallCoursesEC().AddOrUpdateCourse(course);
        }

        [HttpDelete("")]
        public void Delete([FromBody] Course course)
        {
            new FallCoursesEC().DeleteCourse(course);
        }

    }
}
