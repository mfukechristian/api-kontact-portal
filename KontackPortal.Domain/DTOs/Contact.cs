using KontackPortal.Domain.Models;

namespace KontackPortal.Domain.DTOs
{
    public class Contact
    {
        public int Id  { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Relationship {get; set; }
        public string? PhoneNumber {get; set; }

         public Contact(ContactModel contact)
        {
            Id = contact.Id;
            Name = contact.Name;
            Email = contact.Email;
            Relationship = contact.Relationship;
            PhoneNumber = contact.PhoneNumber;
        }

        public Contact()
        {
        }
    }
}