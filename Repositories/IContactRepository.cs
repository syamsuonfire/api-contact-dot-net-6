using ContactsApi.Models;

namespace ContactsApi.Repositories
{
    public interface IContactRepository
    {
        Task<Contact> Get(Guid id);

        Task<IEnumerable<Contact>> GetAll();

        Task Add(Contact contact);
        Task Update(Contact contact);
        Task Delete(Guid id);
    }
}