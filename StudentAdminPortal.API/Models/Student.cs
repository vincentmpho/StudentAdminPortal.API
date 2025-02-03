namespace StudentAdminPortal.API.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string ProfileImageUrl { get; set; }
        public Guid GenderId { get; set; } 

        //Navigation properitey

        public Gender Gender { get; set; }
        public Address Address { get; set; }
    }
}
