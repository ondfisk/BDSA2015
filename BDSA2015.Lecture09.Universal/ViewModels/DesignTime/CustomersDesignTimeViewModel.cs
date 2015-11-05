using BDSA2015.Lecture09.Universal.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace BDSA2015.Lecture09.Universal.ViewModels.DesignTime
{
    public class CustomersDesignTimeViewModel
    {
        public ObservableCollection<Customer> Customers { get; private set; }

        public CustomersDesignTimeViewModel()
        {
            Customers = new ObservableCollection<Customer>();

            foreach (var id in Enumerable.Range(1, 50))
            {
                Customers.Add(new Customer {
                    Id = id,
                    CompanyName = $"Company {id}",
                    ContactName = $"Contact {id}"
                });
            }
        }
    }
}
