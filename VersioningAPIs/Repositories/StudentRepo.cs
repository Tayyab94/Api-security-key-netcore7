using VersioningAPIs.Models;
using VersioningAPIs.Models.DTOs;

namespace VersioningAPIs.Repositories
{
    public class StudentRepo : IStudentRepo
    {
        private List<Student> _students;
        public StudentRepo() {
            _students = new List<Student>
            {
                new Student()
                {
                    Id=1,
                    Name="First Name",
                    Age= 1
                }, new Student(){
                    Id=2,
                    Name="Second Name",
                    Age= 2
                },
                new Student()
                {
                    Id=3,
                    Name="Third Name",
                    Age= 3
                }
            };
        }
        public List<Student> GetAll()
        {
            var data = _students.ToList();

            return data;
        }
    }
}
