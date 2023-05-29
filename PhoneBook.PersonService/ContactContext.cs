using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace PhoneBook.PersonService
{
    public class ContactContext : DbContext
    {

        public ContactContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Model.Contact> Contacts { get; set; }

    }
}
