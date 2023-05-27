using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace PhoneBook.PersonService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private PersonContext dbContext;
        private IMapper mapper;

        public PersonController(PersonContext dbx, IMapper mapr)
        {
            dbContext = dbx;
            mapper = mapr;
        }

        [HttpGet]
        public IEnumerable<DTO.Person> Get()
        {
            return mapper.Map<IEnumerable<DTO.Person>>(
                    dbContext.Persons.Where(w => w.deleted == false)
            );
        }

        [HttpGet("{uuid}")]
        public DTO.Person Get(Guid uuid)
        {
            Model.Person? person = dbContext.Persons.FirstOrDefault(f => f.person_id == uuid && f.deleted == false);
            if (person == null)
            {
                // TODO: Service Error Message
            }
            return mapper.Map<DTO.Person>(person);
        }

        [HttpPost]
        public void Post([FromBody] DTO.Person person)
        {
            Model.Person item = mapper.Map<Model.Person>(person);
            dbContext.Persons.Add(item);
            dbContext.SaveChanges();
        }

        [HttpDelete("{uuid}")]
        public void Delete(Guid uuid)
        {
            var person = dbContext.Persons.FirstOrDefault(f => f.person_id == uuid);
            if (person != null)
            {
                person.deleted = true;
                dbContext.Persons.Update(person);
                dbContext.SaveChanges();
            }
        }
    }
}
