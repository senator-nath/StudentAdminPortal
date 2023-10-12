using StudentAdminPortal.Model;

namespace StudentAdminPortal.Repository
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudents();
    }
}
