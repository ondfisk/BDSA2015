using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BDSA2015.Lecture08.RestClient
{
    public class CustomerRepository : IDisposable
    {
        private readonly HttpClient _client;

        public CustomerRepository()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client.BaseAddress = new Uri("http://localhost:18716/api/");
        }

        public async Task<IEnumerable<Customer>> Get()
        {
            var response = await _client.GetAsync("customers");
            var customers = await response.Content.ReadAsAsync<IEnumerable<Customer>>();

            return customers;
        }

        public async Task<bool> Delete(string id)
        {
            var response = await _client.DeleteAsync($"customers/{id}");

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Post(Customer customer)
        {
            var response = await _client.PostAsJsonAsync("customers", customer);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Put(Customer customer)
        {
            var id = customer.Id;

            var response = await _client.PutAsJsonAsync($"customers/{id}", customer);

            return response.IsSuccessStatusCode;
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
