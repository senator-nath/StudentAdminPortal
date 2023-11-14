using FluentValidation;
using StudentAdminPortal.Model.ModelDtos;
using StudentAdminPortal.Repository.IRepository;

namespace StudentAdminPortal.Validators
{
    public class AddNewStudentValidators : AbstractValidator<AddStudentDto>
    {
        public AddNewStudentValidators(IGenderRepository genderRepository)
        {

            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.DateOfBirth).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Mobile).GreaterThan(99999).LessThan(100000000000);
            RuleFor(x => x.GenderId).NotEmpty().Must(id =>
            {
                var gender = genderRepository.GetAllGender().Result.ToList().FirstOrDefault(x => x.Id == id);
                if (gender != null)
                {
                    return true;
                }
                return false;
            }).WithMessage("please select a valid gender");
            RuleFor(x => x.PostalAddress).NotEmpty();
            RuleFor(x => x.PhysicalAddress).NotEmpty();
        }
    }
}
