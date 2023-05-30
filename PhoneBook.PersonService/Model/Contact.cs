using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneBook.PersonService.Model
{
    [Table("contact")]
    public class Contact
    {

        [Key]
        //contact_id uuid NOT NULL,
        public Guid contact_id { get; set; }
        //person_id uuid NOT NULL,
        public Guid person_id { get; set; }
        // contact_type_id int2 NOT NULL,
        public byte contact_type_id { get; set; }
        // contact_info varchar NOT NULL,
        public string contact_info { get; set; }
        // by_default bool NOT NULL DEFAULT false,
        public bool by_default { get; set; } = false;
        // deleted bool NULL DEFAULT false,
        public bool deleted { get; set; } = false;
        // created_date timestamp NULL,
        public DateTime created_date { get; set; }
        // deleted_date timestamp NULL
        public DateTime deleted_date { get; set; }
    }
}
