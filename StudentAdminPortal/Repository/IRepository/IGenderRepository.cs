using StudentAdminPortal.Model;

namespace StudentAdminPortal.Repository.IRepository
{
    public interface IGenderRepository
    {
        Task<List<Gender>> GetAllGender();
    }
}
