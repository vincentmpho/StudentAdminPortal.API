namespace StudentAdminPortal.API.Models.DTOs
{
    public class AddressDTO
    {
        public Guid Id { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }
        public Guid StudentId { get; set; }
    }
}
