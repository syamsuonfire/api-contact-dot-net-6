using Microsoft.EntityFrameworkCore;
using ContactsApi.Models;

namespace ContactsApi.Data
{
    public interface IDataContext
    {
        DbSet<Contact> Contacts { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}