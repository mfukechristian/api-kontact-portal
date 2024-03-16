using KontackPortal.Domain.Models;
using KontackPortal.Repository.Helpers;
using KontackPortal.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KontackPortal.Repository.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactContext _dbcontext;
        public ContactRepository(ContactContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<List<ContactModel>> GetAllAsync() 
        {
            var query = _dbcontext.Contacts.AsQueryable();
            var contacts = await query.ToListAsync();
            return contacts;
        }

        public async Task<ContactModel> GetAsync(int id)
        {
             var contact = await _dbcontext.Contacts.FindAsync(id);
             return contact;
        }

        public async Task<ContactModel> PostAsync(ContactModel contact)
        {
            contact.Created = DateTime.UtcNow;
            contact.Updated = contact.Created;
            _dbcontext.Add(contact);
            await _dbcontext.SaveChangesAsync();
            return contact;
        }

        public async Task<ContactModel> PutAsync(ContactModel contact)
        {
            contact.Updated = contact.Created;
            _dbcontext.Update(contact);
            await _dbcontext.SaveChangesAsync();
            return contact;
        }

        public async Task<ContactModel> DeleteAsync(ContactModel contact)
        {
            _dbcontext.Remove(contact);
            await _dbcontext.SaveChangesAsync();
            return contact;
        }

  

    }
}
