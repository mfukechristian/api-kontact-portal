using KontackPortal.API.Models;
using Microsoft.EntityFrameworkCore;

namespace KontackPortal.API.Helpers
{
    public class ContactContext : DbContext
    {
        public DbSet<ContactModel> Contacts {get; set; }
        public ContactContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ContactModel>(entity =>
            {
                entity.ToTable("Contacts");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50); 
                entity.Property(e => e.Email).IsRequired().HasMaxLength(50);
                entity.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(50);  
                entity.Property(e => e.Relationship).IsRequired().HasMaxLength(100); 
            });
        }
    }
}