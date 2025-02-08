using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.API.Data;
using StudentAdminPortal.API.Models;
using StudentAdminPortal.API.Repositories.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace StudentAdminPortal.API.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentAdminContext _context;

        public StudentRepository(StudentAdminContext context)
        {
            _context = context;
        }

        public async Task<bool> Exists(Guid studentId)
        {
            return await _context.Student.AnyAsync(x=> x.Id == studentId);
        }

        public async Task<List<Gender>> GetGendersAsync()
        {
           return await _context.Gender.ToListAsync();
        }

        public async Task<Student> GetStudentAsync(Guid studentId)
        {
            var student = await _context.Student
                .Include(nameof(Gender)).Include(nameof(Address))
                .FirstOrDefaultAsync( x=> x.Id == studentId);

            return student;
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            var studnet = await _context.Student.Include(nameof(Gender)).Include(nameof(Address)).ToListAsync();
            return studnet;
        }

        public async Task<Student> UpdateStudent(Guid studentId, Student request)
        {
            var existingStudent = await _context.Student
                .Include(s => s.Address) // Ensure Address is included
                .FirstOrDefaultAsync(x => x.Id == studentId);

            if (existingStudent == null)
            {
                return null;
            }

            // Update properties
            existingStudent.FirstName = request.FirstName;
            existingStudent.LastName = request.LastName;
            existingStudent.Email = request.Email;
            existingStudent.Phone = request.Phone;
            existingStudent.DateOfBirth = request.DateOfBirth;
            existingStudent.GenderId = request.GenderId; 

            if (existingStudent.Address != null)
            {
                existingStudent.Address.PhysicalAddress = request.Address?.PhysicalAddress;
                existingStudent.Address.PostalAddress = request.Address?.PostalAddress;
            }

            await _context.SaveChangesAsync();
            return existingStudent;
        }



    }
}
