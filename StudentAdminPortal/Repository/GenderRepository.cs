using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.Data;
using StudentAdminPortal.Model;
using StudentAdminPortal.Repository.IRepository;

namespace StudentAdminPortal.Repository
{
    public class GenderRepository : IGenderRepository
    {
        private readonly StudentAdminDbContext _context;
        public GenderRepository(StudentAdminDbContext context)
        {
            _context = context;
        }
        public async Task<List<Gender>> GetAllGender()
        {
            return await _context.Gender.ToListAsync();
        }
    }
}

