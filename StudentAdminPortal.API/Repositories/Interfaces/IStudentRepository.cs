using StudentAdminPortal.API.Models;

namespace StudentAdminPortal.API.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudentsAsync();
    }
}
