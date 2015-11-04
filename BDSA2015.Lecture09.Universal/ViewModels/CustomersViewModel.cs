using BDSA2015.Lecture09.Universal.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace BDSA2015.Lecture09.Universal.ViewModels
{
    public class CustomersViewModel : BaseViewModel, IDisposable
    {
        private readonly ICustomerRepository _repository;

        public CustomersViewModel()
        {
            _repository = new CustomerRepository();

            Customers = new ObservableCollection<Customer>();
        }

        public ObservableCollection<Customer> Customers { get; private set; }

        public async void Initialize()
        {
            var customers = await _repository.Read();

            foreach (var customer in customers)
            {
                Customers.Add(customer);
            }
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public async Task Delete(Customer customer)
        {
            if (await _repository.Delete(customer.Id))
            {
                Customers.Remove(customer);
            }
        }
    }
}
