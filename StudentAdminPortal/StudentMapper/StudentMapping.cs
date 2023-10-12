using AutoMapper;
using StudentAdminPortal.Model;
using StudentAdminPortal.Model.ModelDtos;

namespace StudentAdminPortal.StudentMapper
{
    public class StudentMapping : Profile
    {
        public StudentMapping()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Gender, GenderDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
        }
    }
}
