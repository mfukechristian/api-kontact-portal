using KontackPortal.Domain.DTOs;
using KontackPortal.Domain.Models;
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

        public async Task<Contact> GetAsync(int id)
        {
            var result = await _contactRepository.GetAsync(id);
            return result != null ? new Contact(result) : null;
        }

        public async Task<Contact> PostAsync(ContactCreate contact)
        {
            var contactModel = new ContactModel()
            {
                Name = contact.Name,
                Email = contact.Email,
                Relationship = contact.Relationship,
                PhoneNumber = contact.PhoneNumber,
            };

            var createdContact = await _contactRepository.PostAsync(contactModel);
            return new Contact(createdContact);
        }

        public async Task<Contact> PutAsync(int id, ContactUpdate contact)
        {
            var existingContact = await _contactRepository.GetAsync(id);
            if (existingContact == null)
            {
                return null; 
            }

            existingContact.Name = contact.Name;
            existingContact.Email = contact.Email;
            existingContact.Relationship = contact.Relationship;
            existingContact.PhoneNumber = contact.PhoneNumber;

            await _contactRepository.PutAsync(existingContact);

            return new Contact(existingContact);
        }

        public async Task<Contact> PatchAsync(int id, ContactPatch contact)
        {
            var existingContact = await _contactRepository.GetAsync(id);
            if (existingContact == null)
            {
                return null; 
            }

            if (contact.Name != null)
            {
                existingContact.Name = contact.Name;
            }
            if (contact.Email != null)
            {
                existingContact.Email = contact.Email;
            }
            if (contact.Relationship != null)
            {
                existingContact.Relationship = contact.Relationship;
            }
            if (contact.PhoneNumber != null)
            {
                existingContact.PhoneNumber = contact.PhoneNumber;
            }

            await _contactRepository.PutAsync(existingContact);

            return new Contact(existingContact);
        }

        public async Task<Contact?> DeleteAsync(int id)
        {
            var existingContact = await _contactRepository.GetAsync(id);
            if (existingContact == null)
            {
                return null; 
            }

            await _contactRepository.DeleteAsync(existingContact);

            return new Contact(existingContact);
        }
    }
}
