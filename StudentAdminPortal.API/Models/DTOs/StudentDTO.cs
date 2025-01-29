namespace StudentAdminPortal.API.Models.DTOs
{
    public class StudentDTO
    {
        public Guid Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string ProfileImageUrl { get; set; }
        public Guid GengerId { get; set; }
        public Gender Gender { get; set; }
        public Address Address { get; set; }
    }
}
