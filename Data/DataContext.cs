using Microsoft.EntityFrameworkCore;
using ContactsApi.Models;

namespace ContactsApi.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }
    }
}