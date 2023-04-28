using CueLMS.Api.EC;
using Library.LMS.Models;
using Library.LMS.Models.Grading;
using Microsoft.AspNetCore.Mvc;
/* Tatiana Graciela Cue COP4870-0001*/
namespace CueLMS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssignmentGroupController
    {
        private readonly ILogger<AssignmentGroupController> _logger;
        public AssignmentGroupController(ILogger<AssignmentGroupController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetList/{id}")]
        public List<AssignmentGroup> Get(int id)
        {
            return new AssignmentGroupEC().GetGroups(id);
        }

        [HttpPost("")]
        public void AddOrUpdateGroup(Course course)
        {
            new AssignmentGroupEC().AddOrUpdate(course);
        }

        [HttpGet("GetAssignments/{id}")]
        public List<Assignment> GetAssignmentList(int id)
        {
            return new AssignmentGroupEC().GetAssignments(id);
        }
    }
}
