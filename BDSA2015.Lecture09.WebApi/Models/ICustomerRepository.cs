using System;
using System.Linq;
using System.Threading.Tasks;

namespace BDSA2015.Lecture09.WebApi.Models
{
    public interface ICustomerRepository : IDisposable
    {
        Task<int> Create(CustomerDto customer);

        IQueryable<CustomerDto> Read();

        Task<CustomerDto> Read(int id);

        Task<bool> Update(CustomerDto customer);

        Task<bool> Delete(int id);
    }
}
