using AutoMapper.Configuration.Annotations;

namespace PhoneBook.PersonService.DTO
{
    public class Contact
    {
        [SourceMember("contact_id")]
        public Guid ContactID { get; set; }

        [SourceMember("person_id")]
        public Guid Person_UUID { get; set; }

        [SourceMember("contact_type_id")]
        public byte ContactTypeID { get; set; }

        [SourceMember("contact_info")]
        public string ContactInfo { get; set; } = "";

        [SourceMember("by_default")]
        public bool byDefault { get; set; } = true;
    }
}