using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.Model;
using StudentAdminPortal.Model.ModelDtos;
using StudentAdminPortal.Repository.IRepository;

namespace StudentAdminPortal.Controllers
{

    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _student;
        private readonly IMapper _mapper;
        private readonly IImageRepository _image;


        public StudentController(IStudentRepository student, IMapper mapper, IImageRepository image)
        {
            _student = student;
            _mapper = mapper;
            _image = image;
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
        [Route("[controller]/{StudentId:guid}"), ActionName("GetStudent")]
        public async Task<IActionResult> GetStudent([FromRoute] Guid StudentId)
        {
            var student = await _student.GetStudentById(StudentId);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Student>(student));
        }
        [HttpPut]
        [Route("[controller]/{StudentId:guid}")]
        public async Task<IActionResult> UpdateStudent([FromRoute] Guid StudentId, [FromBody] UpdateStudentDto request)
        {
            if (await _student.StudentExist(StudentId))
            {
                var updateStudent = await _student.UpdateStudent(StudentId, _mapper.Map<Model.Student>(request));
                if (updateStudent != null)
                {
                    return Ok(_mapper.Map<Student>(updateStudent));
                }
            }
            return NotFound();

        }
        [HttpDelete]
        [Route("[controller]/{StudentId:guid}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] Guid StudentId)
        {
            if (await _student.StudentExist(StudentId))
            {
                var student = await _student.DeleteStudent(StudentId);
                return Ok(_mapper.Map<Student>(student));
            }
            return NotFound();
        }
        [HttpPost]
        [Route("[controller]/Add")]
        public async Task<IActionResult> AddStudent([FromBody] AddStudentDto student)
        {
            var Student = await _student.AddStudent(_mapper.Map<Model.Student>(student));
            return CreatedAtAction(nameof(GetStudent), new { studentId = Student.Id },
                _mapper.Map<Student>(student)
                );
        }
        [HttpPost]
        [Route("[controller]/{StudentId:guid}/upload-image")]
        public async Task<IActionResult> UploadImage([FromRoute] Guid StudentId, IFormFile profileImage)
        {
            var validExtension = new List<string>
            {
                ".jpeg",".jpg",".png",".gif"
            };



            if (profileImage != null && profileImage.Length > 0)
            {
                var extension = Path.GetExtension(profileImage.FileName);
                if (validExtension.Contains(extension))
                {
                    if (await _student.StudentExist(StudentId))
                    {
                        var fileName = Guid.NewGuid() + Path.GetExtension(profileImage.FileName);
                        var fileImagePath = await _image.Upload(profileImage, fileName);
                        await _student.UpdateProfileImage(StudentId, fileImagePath);
                    }
                }

                return BadRequest("this is not a correct image format");
            }
            return NotFound();
        }
    }
}
