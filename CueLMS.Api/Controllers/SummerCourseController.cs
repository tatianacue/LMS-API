using CueLMS.Api.EC;
using Library.LMS.Models;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public List<Course> GetCourses()
        {
            return new SummerCoursesEC().GetCourses();
        }

        [HttpPost]
        public Course AddOrUpdate([FromBody] Course course)
        {
            return new SummerCoursesEC().AddOrUpdateCourse(course);
        }
    }
}
