using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BDSA2015.Lecture09.WebApi.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ICustomerContext _context;

        public CustomerRepository(ICustomerContext context)
        {
            _context = context;
        }

        public async Task<int> Create(CustomerDto customer)
        {
            var entity = new Customer
            {
                CompanyName = customer.CompanyName,
                ContactName = customer.ContactName,
                City = customer.City,
                Telephone = customer.Telephone
            };

            _context.Customers.Add(entity);

            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public IQueryable<CustomerDto> Read()
        {
            var customers = from c in _context.Customers
                            orderby c.CompanyName
                            select new CustomerDto
                            {
                                Id = c.Id,
                                CompanyName = c.CompanyName,
                                ContactName = c.ContactName,
                                City = c.City,
                                Telephone = c.Telephone
                            };

            return customers;
        }

        public async Task<CustomerDto> Read(int id)
        {
            var customers = from c in _context.Customers
                            where c.Id == id
                            select new CustomerDto
                            {
                                Id = c.Id,
                                CompanyName = c.CompanyName,
                                ContactName = c.ContactName,
                                City = c.City,
                                Telephone = c.Telephone
                            };

            return await customers.FirstOrDefaultAsync();
        }

        public async Task<bool> Update(CustomerDto customer)
        {
            var entity = await _context.Customers.FindAsync(customer.Id);

            if (entity == null)
            {
                return false;
            }

            entity.CompanyName = customer.CompanyName;
            entity.ContactName = customer.ContactName;
            entity.City = customer.City;
            entity.Telephone = customer.Telephone;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Customers.FindAsync(id);

            if (entity == null)
            {
                return false;
            }

            _context.Customers.Remove(entity);

            await _context.SaveChangesAsync();

            return true;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
