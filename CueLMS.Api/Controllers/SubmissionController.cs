using CueLMS.Api.EC;
using Library.LMS.Models;
using Library.LMS.Models.Grading;
using Microsoft.AspNetCore.Mvc;

namespace CueLMS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubmissionController
    {
        private readonly ILogger<SubmissionController> _logger;

        public SubmissionController(ILogger<SubmissionController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetList/{id}")]
        public List<Submission> GetSubmissions(int id)
        {
            return new SubmissionEC().GetSubmissions(id);
        }

        [HttpPost("")]
        public void AddOrUpdate([FromBody] Course course)
        {
            new SubmissionEC().AddOrUpdateSubmission(course);
        }
    }
}
