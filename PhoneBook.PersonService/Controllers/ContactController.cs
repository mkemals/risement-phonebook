using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace PhoneBook.PersonService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {

        private ContactContext dbContext;
        private IMapper mapper;

        public ContactController(ContactContext dbx, IMapper mapr)
        {
            dbContext = dbx;
            mapper = mapr;
        }

        /// <summary>
        /// Person uuid değeri için ilgili Person Contact kayıtlarını getir
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<DTO.Contact> Get(Guid person_uuid)
        {
            var contacts = dbContext.Contacts.Where(w => w.deleted == false && w.person_id == person_uuid);
            return mapper.Map<IEnumerable<DTO.Contact>>(contacts);
        }

        /// <summary>
        /// Verilen contact kaydını DB'ye kaydet
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public void Post([FromBody] DTO.Contact contact)
        {
            Model.Contact item = mapper.Map<Model.Contact>(contact);
            dbContext.Contacts.Add(item);
            dbContext.SaveChanges();
        }

        /// <summary>
        /// uuid'si verilen Contact kaydını sil.
        /// </summary>
        /// <param name="uuid"></param>
        [HttpDelete("{uuid}")]
        public void Delete(Guid uuid)
        {
            var contact = dbContext.Contacts.FirstOrDefault(f => f.contact_id == uuid);
            if (contact != null)
            {
                contact.deleted = true;
                contact.deleted_date = DateTime.Now;
                dbContext.Contacts.Update(contact);
                dbContext.SaveChanges();
            }
        }
    }
}
