using KontackPortal.Domain.DTOs;
using KontackPortal.DomainLogic.Interface;
using KontackPortal.Repository.Interfaces;

namespace KontackPortal.DomainLogic.Services
{
    public class ContactServices : IContactService
    {
        private readonly IContactRepository _contactRepository;
        public ContactServices(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<List<Contact>> GetAllAsync()
        {
            var result = await _contactRepository.GetAllAsync();
            return result.Select(contactModel => new Contact(contactModel)).ToList();
        }
    }
}