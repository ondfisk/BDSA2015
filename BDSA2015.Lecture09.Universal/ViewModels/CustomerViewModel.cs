using BDSA2015.Lecture09.Universal.Models;
using System;

namespace BDSA2015.Lecture09.Universal.ViewModels
{
    public class CustomerViewModel : BaseViewModel, IDisposable
    {
        private readonly ICustomerRepository _repository;

        private Customer _customer;

        public Customer Customer
        {
            get { return _customer ?? (_customer = new Customer()); }
            set
            {
                _customer = value;
                OnPropertyChanged();
            }
        }

        public int Id
        {
            get { return Customer.Id; }
            set
            {
                Customer.Id = value;
                OnPropertyChanged();
            }
        }

        public string CompanyName
        {
            get { return Customer.CompanyName; }
            set
            {
                Customer.CompanyName = value;
                OnPropertyChanged();
                Save.OnCanExecuteChanged(this);
            }
        }

        public string ContactName
        {
            get { return Customer.ContactName; }
            set
            {
                Customer.ContactName = value;
                OnPropertyChanged();
            }
        }

        public string City
        {
            get { return Customer.City; }
            set
            {
                Customer.City = value;
                OnPropertyChanged();
            }
        }

        public string Telephone
        {
            get { return Customer?.Telephone; }
            set
            {
                Customer.Telephone = value;
                OnPropertyChanged();
            }
        }

        public CustomerViewModel()
        {
            _repository = new CustomerRepository();

            Save = new RelayCommand(async _ =>
            {
                if (Id != 0)
                {
                    await _repository.Update(Customer);
                }
                else
                {
                    Customer = await _repository.Create(Customer);
                }
            }, _ => !string.IsNullOrWhiteSpace(CompanyName));
        }

        public async void Initialize(Customer customer)
        {
            Customer = customer;
        }

        public RelayCommand Save { get; private set; }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
