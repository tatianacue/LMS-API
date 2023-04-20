using CueLMS.Api.EC;
using Library.LMS.Models;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public List<Course> GetCourses()
        {
            return new SpringCoursesEC().GetCourses();
        }

        [HttpPost]
        public Course AddOrUpdate([FromBody] Course course)
        {
            return new SpringCoursesEC().AddOrUpdateCourse(course);
        }
    }
}
