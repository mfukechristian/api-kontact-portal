using KontackPortal.Domain.Models;
using KontackPortal.Repository.Helpers;
using KontackPortal.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic; // Add this namespace for List<T>

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
    }
}
