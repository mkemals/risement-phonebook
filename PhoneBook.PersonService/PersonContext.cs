using Microsoft.EntityFrameworkCore;

namespace PhoneBook.PersonService
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Model.Person> Persons { get; set; }

    }
}
