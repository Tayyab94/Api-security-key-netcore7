using VersioningAPIs.Models;
using VersioningAPIs.Models.DTOs;

namespace VersioningAPIs.Repositories
{
    public interface IStudentRepo
    {
        List<Student> GetAll();
    }
}
