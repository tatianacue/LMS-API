using Library.LMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace CueLMS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController
    {
        private readonly ILogger<PersonController> _logger;
        private List<Person> _people;

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
            _people = new List<Person>() {
                new Student{ ID = "tbc20n", Name = "Tat", Classification = "Junior"},
                new Instructor{ ID = "tlt50n", Name = "Top"},
                new TeachingAssistant{ ID = "prt60N", Name = "Patrick"}
            };
        }

        [HttpGet]
        public List<Person> Get()
        {
            return _people;
        }

    }
}
