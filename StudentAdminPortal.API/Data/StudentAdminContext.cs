using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.API.Models;

namespace StudentAdminPortal.API.Data
{
    public class StudentAdminContext : DbContext
    {
        public StudentAdminContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Address> Address  { get; set; }
        public DbSet<Gender>  Gender  { get; set; }
    }
}
