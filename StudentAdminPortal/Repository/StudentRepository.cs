using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.Data;
using StudentAdminPortal.Model;

namespace StudentAdminPortal.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentAdminDbContext _context;
        public StudentRepository(StudentAdminDbContext context)
        {
            _context = context;
        }
        public List<Student> GetStudents()
        {
            return _context.Student.Include(nameof(Gender)).Include(nameof(Address)).ToList();
        }
    }
}
