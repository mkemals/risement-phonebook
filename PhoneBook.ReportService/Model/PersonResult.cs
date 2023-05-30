namespace PhoneBook.ReportService.Model
{
    public class PersonResult
    {
        public Guid UUID { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Firm { get; set; } = "";
        public List<Contact> Contacts { get; set; }

        public PersonResult()
        {
            Contacts = new List<Contact>();
        }
    }

    public class Contact
    {
        public Guid ContactID { get; set; }
        public Guid Person_UUID { get; set; }
        public byte ContactTypeID { get; set; }
        public string ContactInfo { get; set; } = "";
        public bool byDefault { get; set; } = true;
    }

}
