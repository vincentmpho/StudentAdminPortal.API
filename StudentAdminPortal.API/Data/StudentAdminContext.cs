using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.API.Models;

namespace StudentAdminPortal.API.Data
{
    public class StudentAdminContext : DbContext
    {
        public StudentAdminContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student>  Students { get; set; }
        public DbSet<Address>   Addresses { get; set; }
        public DbSet<Gender>   genders { get; set; }
    }
}
