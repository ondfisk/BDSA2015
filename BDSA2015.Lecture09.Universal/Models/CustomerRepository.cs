using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BDSA2015.Lecture09.Universal.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly HttpClient _client;

        public CustomerRepository()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:18716/api/customers/")
            };

            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<Customer> Create(Customer customer)
        {
            var response = await _client.PostAsJsonAsync(string.Empty, customer);

            return await response.Content.ReadAsAsync<Customer>();
        }

        public async Task<Customer> Read(int id)
        {
            var response = await _client.GetAsync($"{id}");

            return await response.Content.ReadAsAsync<Customer>();
        }

        public async Task<IEnumerable<Customer>> Read()
        {
            var response = await _client.GetAsync(string.Empty);

            return await response.Content.ReadAsAsync<Customer[]>();
        }

        public async Task<bool> Update(Customer customer)
        {
            var response = await _client.PutAsJsonAsync($"{customer.Id}", customer);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(int id)
        {
            var response = await _client.DeleteAsync($"{id}");

            return response.IsSuccessStatusCode;
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
