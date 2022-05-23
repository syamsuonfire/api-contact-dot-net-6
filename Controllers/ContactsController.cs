using Microsoft.AspNetCore.Mvc;
using ContactsApi.Dtos;
using ContactsApi.Models;
using ContactsApi.Repositories;

namespace ContactsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;

        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<Contact>> GetContact([FromRoute] Guid id)
        {
            var contact = await _contactRepository.Get(id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacs()
        {
            var contacts = await _contactRepository.GetAll();

            return Ok(contacts);
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> CreateContact(CreateContactDto createContactDto)
        {
            Contact contact = new()
            {
                Id = Guid.NewGuid(),
                Address = createContactDto.Address,
                Email = createContactDto.Email,
                FullName = createContactDto.FullName,
                Phone = createContactDto.Phone,
                CreatedAt = DateTime.Now.ToUniversalTime()
            };
            await _contactRepository.Add(contact);
            return Ok(contact);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<ActionResult<Contact>> UpdateContact([FromRoute] Guid id, UpdateContactDto updateContactDto)
        {
            var contact = await _contactRepository.Get(id);
            if (contact == null)
            {
                return NotFound();
            }
            contact.FullName = updateContactDto.FullName;
            contact.Address = updateContactDto.Address;
            contact.Phone = updateContactDto.Phone;
            contact.Email = updateContactDto.Email;
            contact.UpdatedAt = DateTime.Now.ToUniversalTime();
            await _contactRepository.Update(contact);
            return Ok(contact);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<ActionResult> DeleteContact([FromRoute] Guid id)
        {
            await _contactRepository.Delete(id);
            return Ok();
        }



}
}