using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.API.Data;
using StudentAdminPortal.API.Models;
using StudentAdminPortal.API.Repositories.Interfaces;

namespace StudentAdminPortal.API.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentAdminContext _context;

        public StudentRepository(StudentAdminContext context)
        {
            _context = context;
        }


        public async Task<List<Student>> GetStudentsAsync()
        {
            var studnet = await _context.Student.Include(nameof(Gender)).Include(nameof(Address)).ToListAsync();
            return studnet;
        }
    }
}
