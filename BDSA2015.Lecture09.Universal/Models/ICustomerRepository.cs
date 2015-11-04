using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BDSA2015.Lecture09.Universal.Models
{
    public interface ICustomerRepository : IDisposable
    {
        Task<Customer> Create(Customer customer);

        Task<IEnumerable<Customer>> Read();

        Task<Customer> Read(int id);

        Task<bool> Update(Customer customer);

        Task<bool> Delete(int id);
    }
}
