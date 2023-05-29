using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneBook.PersonService.DTO
{
    public class Contact
    {
        public Guid UUID { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Firm { get; set; } = "";
        public bool Deleted { get; set; } = false;
        public DateTime Created_date { get; set; }
        public DateTime Deleted_date { get; set; }
    }
}
