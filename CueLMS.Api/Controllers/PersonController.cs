using CueLMS.Api.EC;
using Library.LMS.Models;
using Microsoft.AspNetCore.Http.HttpResults;
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

        [HttpGet("GetStudents")]
        public List<Student> GetStudentList()
        {
            return new PersonEC().GetStudents();
        }

        [HttpGet("GetInstructors")]
        public List<Instructor> GetInstructorList()
        {
            return new PersonEC().GetInstructors();
        }

        [HttpGet("GetTeachingAssistants")]
        public List<TeachingAssistant> GetTAList()
        {
            return new PersonEC().GetTeachingAssistants();
        }

        [HttpPost("AddUpdateStudent")]
        public void AddOrUpdateS([FromBody] Student person)
        {
            new PersonEC().AddOrUpdateStudent(person);
        }

        [HttpPost("AddUpdateTA")]
        public void AddOrUpdateT([FromBody] TeachingAssistant person)
        {
            new PersonEC().AddOrUpdateTA(person);
        }

        [HttpPost("AddUpdateInstructor")]
        public void AddOrUpdateI([FromBody] Instructor person)
        {
            new PersonEC().AddOrUpdateInstructor(person);
        }

        [HttpGet("GetStudentGrades/{id}")]
        public Dictionary<Course, double> GetGrades(int id)
        {
            return new PersonEC().GetStudentGrades(id);
        }

        [HttpPost("AddStudentGrade")]
        public void AddGrade(Student student)
        {
            new PersonEC().AddOrUpdateGrade(student);
        }

    }
}
