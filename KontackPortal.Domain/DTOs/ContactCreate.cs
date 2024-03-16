namespace KontackPortal.Domain.DTOs
{
    public class ContactCreate
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Relationship {get; set; }
        public string? PhoneNumber {get; set; }
        
    }
}