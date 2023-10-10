using StudentAdminPortal.Model;

namespace StudentAdminPortal.Repository
{
    public interface IStudentRepository
    {
        List<Student> GetStudents();
    }
}
