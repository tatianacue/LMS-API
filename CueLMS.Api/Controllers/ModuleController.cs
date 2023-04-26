﻿using CueLMS.Api.EC;
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
    }
}
