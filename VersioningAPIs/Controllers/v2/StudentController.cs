using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using VersioningAPIs.Repositories;

namespace VersioningAPIs.Controllers.v2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]

    public class StudentController : ControllerBase
    {
        private IStudentRepo _studentRepo;

        public StudentController(IStudentRepo studentRepo)
        {
            this._studentRepo = studentRepo;
        }


        [HttpGet(Name = "GetStudents")]
        public IActionResult GetStudents()
        {
            var data = _studentRepo.GetAll();

            return Ok(data);
        }
    }
}
