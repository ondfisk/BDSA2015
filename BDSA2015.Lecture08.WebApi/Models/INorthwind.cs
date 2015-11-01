using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace BDSA2015.Lecture08.WebApi.Models
{
    public interface INorthwind : IDisposable
    {
        DbSet<Customer> Customers { get; set; }

        Task<int> SaveChangesAsync();

        DbEntityEntry<T> Entry<T>(T customer) where T : class;
    }
}