using Library.LMS.Models;
using Microsoft.AspNetCore.Mvc;
using UWP.Library.CueLMS.Database;

namespace CueLMS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController
    {
        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<Person> Get()
        {
            return DatabaseContext.People;
        }

    }
}
