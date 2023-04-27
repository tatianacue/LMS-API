using CueLMS.Api.EC;
using Library.LMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace CueLMS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModuleController
    {
        private readonly ILogger<ModuleController> _logger;

        public ModuleController(ILogger<ModuleController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetList/{id}")]
        public List<Module> GetModules(int id)
        {
            return new ModuleEC().GetModules(id);
        }

        [HttpPost("")]
        public void AddOrUpdate([FromBody] Course course)
        {
            new ModuleEC().AddOrUpdateModule(course);
        }

        [HttpDelete("")]
        public void Delete([FromBody] Course course)
        {
            new ModuleEC().DeleteModule(course);
        }

        [HttpGet("GetFileItems/{id}")]
        public List<FileItem> GetFI(int id)
        {
            return new ModuleEC().GetFileItems(id);
        }

        [HttpGet("GetPageItems/{id}")]
        public List<PageItem> GetPI(int id)
        {
            return new ModuleEC().GetPageItems(id);
        }

        [HttpGet("GetAssignmentItems/{id}")]
        public List<AssignmentItem> GetAI(int id)
        {
            return new ModuleEC().GetAssignmentItems(id);
        }

        [HttpPost("AddUpdateFileItem")]
        public void PostFile(Course course)
        {
            new ModuleEC().AddUpdateFileItem(course);
        }

        [HttpPost("AddUpdatePageItem")]
        public void PostPage(Course course)
        {
            new ModuleEC().AddUpdatePageItem(course);
        }

        [HttpPost("AddUpdateAssignmentItem")]
        public void PostAssignment(Course course)
        {
            new ModuleEC().AddUpdateAssignmentItem(course);
        }

        [HttpDelete("DeleteFileItem")]
        public void DeleteFileItem(Course course)
        {
            new ModuleEC().RemoveFileItem(course);
        }

        [HttpDelete("DeletePageItem")]
        public void DeletePageItem(Course course)
        {
            new ModuleEC().RemovePageItem(course);
        }

        [HttpDelete("DeleteAssignmentItem")]
        public void DeleteAssignmentItem(Course course)
        {
            new ModuleEC().RemoveAssignmentItem(course);
        }
    }
}
