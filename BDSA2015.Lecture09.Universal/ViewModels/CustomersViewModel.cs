using BDSA2015.Lecture09.Universal.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BDSA2015.Lecture09.Universal.ViewModels
{
    public class CustomersViewModel : BaseViewModel, IDisposable
    {
        private readonly ICustomerRepository _repository;

        public CustomersViewModel()
        {
            _repository = new CustomerRepository();

            Customers = new ObservableCollection<Customer>();

            Refresh = new RelayCommand(c => Initialize());
        }

        public ObservableCollection<Customer> Customers { get; private set; }

        private Customer _selectedCustomer;

        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged();
            }
        }

        public async void Initialize()
        {
            Customers.Clear();

            var customers = await _repository.Read();

            foreach (var customer in customers)
            {
                Customers.Add(customer);
            }
        }

        public ICommand Refresh { get; private set; }

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
