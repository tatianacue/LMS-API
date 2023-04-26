using CueLMS.Api.EC;
using Library.LMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace CueLMS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssignmentController
    {
        private readonly ILogger<AssignmentController> _logger;

        public AssignmentController(ILogger<AssignmentController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetList/{id}")]
        public List<Assignment> Get(int id)
        {
            return new AssignmentEC().GetAssignments(id);
        }

        [HttpPost("")]
        public void AddOrUpdate([FromBody] Course course)
        {
            new AssignmentEC().AddOrUpdateAssignment(course);
        }

        [HttpDelete("")]
        public void Delete([FromBody] Course course)
        {
            new AssignmentEC().DeleteAssignment(course);
        }
    }
}
