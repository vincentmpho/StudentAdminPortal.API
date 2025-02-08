namespace StudentAdminPortal.API.Models.DTOs
{
    public class UpdateStudentDTO
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public Guid GenderId { get; set; } 
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }
    }
}
