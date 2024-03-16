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

    }
}
