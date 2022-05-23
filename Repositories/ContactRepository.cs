using Microsoft.EntityFrameworkCore;
using ContactsApi.Data;
using ContactsApi.Models;

namespace ContactsApi.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly IDataContext _context;
        public ContactRepository(IDataContext context)
        {
            _context = context;

        }
        public async Task Add(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var itemToDelete = await _context.Contacts.FindAsync(id);
            if (itemToDelete == null)
            {
                throw new NullReferenceException();
            }
            _context.Contacts.Remove(itemToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Contact> Get(Guid id)
        {
            return await _context.Contacts.FindAsync(id);
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task Update(Contact contact)
        {
            var itemToUpdate = await _context.Contacts.FindAsync(contact.Id);
            if (itemToUpdate == null)
            {
                throw new NullReferenceException();
            }
            itemToUpdate.Address = contact.Address;
            itemToUpdate.Email = contact.Email;
            itemToUpdate.FullName = contact.FullName;
            itemToUpdate.Phone = contact.Phone;
            await _context.SaveChangesAsync();
        }
    }
}