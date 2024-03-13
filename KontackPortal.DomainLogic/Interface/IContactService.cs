using KontackPortal.Domain.DTOs;

namespace KontackPortal.DomainLogic.Interface
{
    public interface IContactService
    {
        Task<List<Contact>> GetAllAsync();
    }
}