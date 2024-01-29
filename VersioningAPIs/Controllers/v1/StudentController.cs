using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VersioningAPIs.Models.DTOs;
using VersioningAPIs.Repositories;

namespace VersioningAPIs.Controllers.v1
{
    //[Route("api/[controller]/[action]")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
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
            data.Select(s => new StudentDTO()
            {
                Id = s.Id,
                Name = s.Name
            }).ToList();
            return Ok(data);
        }
    }
}
