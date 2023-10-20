using AutoMapper;
using StudentAdminPortal.Model;
using StudentAdminPortal.Model.ModelDtos;

namespace StudentAdminPortal.StudentMapper.AfterMap
{
    public class UpdateStudentRequestAfterMap : IMappingAction<UpdateStudentDto, Model.Student>
    {
        public void Process(UpdateStudentDto source, Student destination, ResolutionContext context)
        {
            destination.Address = new Model.Address()
            {
                PhysicalAddress = source.PhysicalAddress,
                PostalAddress = source.PostalAddress,
            };
        }
    }
}
