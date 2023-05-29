using AutoMapper.Configuration.Annotations;

namespace PhoneBook.PersonService.DTO
{
    public class Person
    {
        [SourceMember("person_id")]
        public Guid UUID { get; set; }

        [SourceMember("firstname")]
        public string FirstName { get; set; } = "";

        [SourceMember("lastname")]
        public string LastName { get; set; } = "";

        [SourceMember("firm")]
        public string Firm { get; set; } = "";

        public List<Contact> Contacts { get; set; }

        //[SourceMember("deleted")]
        //public bool Deleted { get; set; } = false;

        public Person()
        {
            Contacts = new List<Contact>();
        }

    }
}
