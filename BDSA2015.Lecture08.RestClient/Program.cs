using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDSA2015.Lecture08.RestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // Standard static repository
            using (var repository = new CustomerRepository())
            {
                var customer = new Customer { Id = "GOOFY", CompanyName = "Duckburg" };
                var ok = repository.Post(customer).Result;

                Console.WriteLine(ok);

                customer.ContactName = "Mickey Mouse";
                ok = repository.Put(customer).Result;

                Console.WriteLine(ok);
            }

            // Dynamic repository - get array
            using (var repository = new DynamicRepo())
            {
                var customers = repository.Get().Result;

                foreach (var customer in customers)
                {
                    Console.WriteLine(customer.company_name);
                }
            }

            // Dynamic repository - get object
            using (var repository = new DynamicRepo())
            {
                var customer = repository.Get("ALFKI").Result;

                Console.WriteLine(customer.company_name);
            }
        }
    }
}
