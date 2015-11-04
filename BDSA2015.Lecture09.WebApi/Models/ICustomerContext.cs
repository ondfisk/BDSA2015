using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace BDSA2015.Lecture09.WebApi.Models
{
    public interface ICustomerContext : IDisposable
    {
        DbSet<Customer> Customers { get; set; }

        Task<int> SaveChangesAsync();
    }
}