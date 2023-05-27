namespace PhoneBook.PersonService.DTO
{
    public class Person
    {
        public Guid UUID { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Firm { get; set; } = "";
        //public bool Deleted { get; set; } = false;
    }
}
