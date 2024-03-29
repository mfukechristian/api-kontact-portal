
namespace KontackPortal.Domain.Models
{
    public class ContactModel
    {
        public int Id  { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Relationship {get; set; }
        public string? PhoneNumber {get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set;}
    }
}