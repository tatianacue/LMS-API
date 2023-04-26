﻿using CueLMS.Api.EC;
using Library.LMS.Models;
using Library.LMS.Models.Grading;
using Microsoft.AspNetCore.Mvc;

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
    }
}