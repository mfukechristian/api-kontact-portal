using KontackPortal.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace KontackPortal.Repository.Helpers
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ContactModel> Contacts {get; set; }


    }
}