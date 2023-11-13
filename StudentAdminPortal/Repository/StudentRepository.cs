using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.Data;
using StudentAdminPortal.Model;
using StudentAdminPortal.Repository.IRepository;

namespace StudentAdminPortal.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentAdminDbContext _context;
        public StudentRepository(StudentAdminDbContext context)
        {
            _context = context;
        }

        public async Task<Student> AddStudent(Student student)
        {
            var Student = await _context.Student.AddAsync(student);
            await _context.SaveChangesAsync();
            return Student.Entity;
        }

        public async Task<Student> DeleteStudent(Guid studentId)
        {
            var student = await GetStudentById(studentId);
            if (student != null)
            {
                _context.Student.Remove(student);
                await _context.SaveChangesAsync();

            }
            return null;
        }

        public async Task<Student> GetStudentById(Guid studentId)
        {
            return await _context.Student.Include(nameof(Gender)).Include(nameof(Address)).FirstOrDefaultAsync(x => x.Id == studentId);
        }

        public async Task<List<Student>> GetStudents()
        {
            return await _context.Student.Include(nameof(Gender)).Include(nameof(Address)).ToListAsync();
        }

        public async Task<bool> StudentExist(Guid studentId)
        {
            return await _context.Student.AnyAsync(Student => Student.Id == studentId);
        }

        public async Task<bool> UpdateProfileImage(Guid studentId, string profileImageUrl)
        {
            var student = await GetStudentById(studentId);
            if (student != null)
            {
                student.ProfileImageUrl = profileImageUrl;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Student> UpdateStudent(Guid studentId, Student request)
        {
            var existingStudent = await GetStudentById(studentId);
            if (existingStudent != null)
            {
                existingStudent.FirstName = request.FirstName;
                existingStudent.LastName = request.LastName;
                existingStudent.Email = request.Email;
                existingStudent.DateOfBirth = request.DateOfBirth;
                existingStudent.Mobile = request.Mobile;
                existingStudent.GenderId = request.GenderId;
                existingStudent.Address.PhysicalAddress = request.Address.PhysicalAddress;
                existingStudent.Address.PostalAddress = request.Address.PostalAddress;

                await _context.SaveChangesAsync();
                return existingStudent;
            }
            return null;
        }
    }
}
