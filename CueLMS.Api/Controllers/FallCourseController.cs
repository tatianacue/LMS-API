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

        [HttpGet]
        public List<Course> GetCourses()
        {
            return new FallCoursesEC().GetCourses();
        }

        [HttpPost]
        public Course AddOrUpdate([FromBody] Course course)
        {
            return new FallCoursesEC().AddOrUpdateCourse(course);
        }
    }
}
