using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneBook.PersonService.Model
{
    [Table("person")]
    public class Person
    {

        // person_id uuid NOT NULL,
        public Guid person_id { get; set; }
        // firstname varchar NULL,
        public string firstname { get; set; }
        // lastname varchar NULL,
        public string lastname { get; set; }
        // firm varchar NULL,
        public string firm { get; set; }
        // deleted bool NULL DEFAULT false,
        public bool deleted { get; set; }
        // created_date timestamp NULL,
        public DateTime created_date { get; set; }
        // deleted_date timestamp NULL
        public DateTime deleted_date { get; set; }

    }
}
