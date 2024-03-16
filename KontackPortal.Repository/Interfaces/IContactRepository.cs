using KontackPortal.Domain.Models;

namespace KontackPortal.Repository.Interfaces
{
    public interface IContactRepository
    {
        Task<List<ContactModel>> GetAllAsync();
        Task<ContactModel> GetAsync(int id);
    }
}