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

        /// <summary>
        /// Tüm aktif Person kayıtlarını getir
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<DTO.Person> Get()
        {
            var persons = dbContext.Persons.Where(w => w.deleted == false);
            return mapper.Map<IEnumerable<DTO.Person>>(persons);
        }

        /// <summary>
        /// uuid değeri için ilgili Person kaydını getir
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Verilen person kaydını DB'ye kaydet
        /// </summary>
        /// <param name="person"></param>
        [HttpPost]
        public void Post([FromBody] DTO.Person person)
        {
            Model.Person item = mapper.Map<Model.Person>(person);
            dbContext.Persons.Add(item);
            dbContext.SaveChanges();
        }

        /// <summary>
        /// uuid'si verilen Person kaydını sil.
        /// </summary>
        /// <param name="uuid"></param>
        [HttpDelete("{uuid}")]
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
