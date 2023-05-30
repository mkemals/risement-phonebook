using AutoMapper;

namespace PhoneBook.PersonService.Repository
{
    public class PersonRepository
    {

        private PersonContext dbContext;
        private IMapper mapper;

        public PersonRepository(PersonContext dbx, IMapper mapr)
        {
            dbContext = dbx;
            mapper = mapr;
        }

        public void SavePerson(DTO.Person person)
        {
            if (person == null)
                throw new ArgumentNullException("Kişi bilgisi boş geçilmiş");

            Model.Person item = mapper.Map<Model.Person>(person);

            dbContext.Persons.Add(item);
            dbContext.SaveChanges();
        }

        public IEnumerable<DTO.Person> GetPersons()
        {
            var persons = dbContext.Persons.Where(w => w.deleted == false);
            return mapper.Map<IEnumerable<DTO.Person>>(persons);
        }

        public DTO.Person GetPerson(Guid uuid)
        {
            Model.Person? person = dbContext.Persons.FirstOrDefault(f => f.person_id == uuid && f.deleted == false);
            // TODO: Contact bilgisi join edilecek
            if (person == null)
                throw new ArgumentNullException("Kişi bilgisi bulunamadı");
            return mapper.Map<DTO.Person>(person);
        }

        public void Delete(Guid uuid)
        {
            var person = dbContext.Persons.FirstOrDefault(f => f.person_id == uuid);
            if (person != null)
            {
                person.deleted = true;
                person.deleted_date = DateTime.Now;
                dbContext.Persons.Update(person);
                dbContext.SaveChanges();
            }
        }


    }
}
