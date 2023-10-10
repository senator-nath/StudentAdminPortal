using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.Model;
using StudentAdminPortal.Repository;

namespace StudentAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _student;

        public StudentController(IStudentRepository student)
        {
            _student = student;
        }

        [HttpGet("Get-All-students")]
        public IActionResult GetAllStudent()
        {
            var students = _student.GetStudents();
            var ModelStudent = new List<Student>();

            foreach (var studentItem in students)
            {
                ModelStudent.Add(new Student()
                {
                    Id = studentItem.Id,
                    FirstName = studentItem.FirstName,
                    LastName = studentItem.LastName,
                    Email = studentItem.Email,
                    DateOfBirth = studentItem.DateOfBirth,
                    ProfileImageUrl = studentItem.ProfileImageUrl,
                    GenderId = studentItem.GenderId,
                    Mobile = studentItem.Mobile,
                    Address = new Address()
                    {
                        Id = studentItem.Address.Id,
                        PhysicalAddress = studentItem.Address.PhysicalAddress,
                        PostalAddress = studentItem.Address.PostalAddress
                    },
                    Gender = new Gender()
                    {
                        Id = studentItem.Gender.Id,
                        Description = studentItem.Gender.Description,
                    },
                });
            }
            return Ok(ModelStudent);
        }
    }
}
