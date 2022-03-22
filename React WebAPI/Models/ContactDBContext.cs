using Microsoft.EntityFrameworkCore;

namespace React_WebAPI.Models
{
    public class ContactDBContext:DbContext
    {
        public ContactDBContext(DbContextOptions<ContactDBContext> options) : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
