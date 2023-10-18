using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.Model;
using StudentAdminPortal.Repository;

namespace StudentAdminPortal.Controllers
{

    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _student;
        private readonly IMapper _mapper;


        public StudentController(IStudentRepository student, IMapper mapper)
        {
            _student = student;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAllStudent")]
        public async Task<IActionResult> GetAllStudent()
        {
            var students = await _student.GetStudents();
            return Ok(_mapper.Map<List<Student>>(students));
            //var ModelStudent = new List<Student>();

            //foreach (var studentItem in students)
            //{
            //    ModelStudent.Add(new Student()
            //    {
            //        Id = studentItem.Id,
            //        FirstName = studentItem.FirstName,
            //        LastName = studentItem.LastName,
            //        Email = studentItem.Email,
            //        DateOfBirth = studentItem.DateOfBirth,
            //        ProfileImageUrl = studentItem.ProfileImageUrl,
            //        GenderId = studentItem.GenderId,
            //        Mobile = studentItem.Mobile,
            //        Address = new Address()
            //        {
            //            Id = studentItem.Address.Id,
            //            PhysicalAddress = studentItem.Address.PhysicalAddress,
            //            PostalAddress = studentItem.Address.PostalAddress
            //        },
            //        Gender = new Gender()
            //        {
            //            Id = studentItem.Gender.Id,
            //            Description = studentItem.Gender.Description,
            //        },
            //    });
        }
        [HttpGet]
        [Route("[controller]/{StudentId:guid}")]
        public async Task<IActionResult> GetStudent(Guid StudentId)
        {
            var student = await _student.GetStudentById(StudentId);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Student>(student));
        }
    }
}

