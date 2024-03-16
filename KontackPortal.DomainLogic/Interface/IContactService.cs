using KontackPortal.Domain.DTOs;

namespace KontackPortal.DomainLogic.Interface
{
    public interface IContactService
    {
        Task<List<Contact>> GetAllAsync();
        Task <Contact> GetAsync(int id);
        Task<Contact> PostAsync(ContactCreate contact);
        Task <Contact> PutAsync(int id, ContactUpdate contact);
        Task <Contact> PatchAsync(int id, ContactPatch contact);
        Task <Contact?> DeleteAsync(int id);
    }
}