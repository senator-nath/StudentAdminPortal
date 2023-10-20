using AutoMapper;
using StudentAdminPortal.Model;
using StudentAdminPortal.Model.ModelDtos;
using StudentAdminPortal.StudentMapper.AfterMap;

namespace StudentAdminPortal.StudentMapper
{
    public class StudentMapping : Profile
    {
        public StudentMapping()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Gender, GenderDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<UpdateStudentDto, Model.Student>()
              .AfterMap<UpdateStudentRequestAfterMap>();
        }
    }
}
