using AutoMapper;
using StudentAdminPortal.Model;
using StudentAdminPortal.Model.ModelDtos;

namespace StudentAdminPortal.StudentMapper.AfterMap
{
    public class AddStudentRequestAfterMap : IMappingAction<AddStudentDto, Model.Student>
    {
        public void Process(AddStudentDto source, Student destination, ResolutionContext context)
        {
            destination.Id = Guid.NewGuid();
            destination.Address = new Model.Address()
            {
                Id = new Guid(),
                PhysicalAddress = source.PhysicalAddress,
                PostalAddress = source.PostalAddress,

            };
        }


    }
}