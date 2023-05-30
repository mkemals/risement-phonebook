using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace PhoneBook.PersonService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        Repository.PersonRepository personRepository { get; set; }

        public PersonController(PersonContext dbx, IMapper mapr)
        {
            personRepository = new Repository.PersonRepository(dbx, mapr);
        }

        /// <summary>
        /// Tüm aktif Person kayıtlarını getir
        /// </summary>
        /// <returns></returns>
        [Route("persons")]
        [HttpGet]
        public IEnumerable<DTO.Person> Get()
        {
            return personRepository.GetPersons();
        }

        /// <summary>
        /// uuid değeri için ilgili Person kaydını getir
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        [Route("person/{}")]
        [HttpGet("{uuid}")]
        public DTO.Person Get(Guid uuid)
        {
            return personRepository.GetPerson(uuid);
        }

        /// <summary>
        /// Verilen person kaydını DB'ye kaydet
        /// </summary>
        /// <param name="person"></param>
        [HttpPost]
        public void Post([FromBody] DTO.Person person)
        {
            try
            {
                personRepository.SavePerson(person);
            }
            catch (Exception)
            {
                //TODO: error message
            }
        }

        /// <summary>
        /// uuid'si verilen Person kaydını sil.
        /// </summary>
        /// <param name="uuid"></param>
        [HttpDelete("{uuid}")]
        public void Delete(Guid uuid)
        {
            personRepository.Delete(uuid);
        }

    }
}
