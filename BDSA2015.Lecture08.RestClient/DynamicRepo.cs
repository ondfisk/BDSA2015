using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BDSA2015.Lecture08.RestClient
{
    public class DynamicRepo : IDisposable
    {
        private readonly HttpClient _client;

        public DynamicRepo()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client.BaseAddress = new Uri("http://localhost:18716/api/");
        }

        public void Dispose()
        {
            _client.Dispose();
        }

        public async Task<dynamic> Get()
        {
            var response = await _client.GetAsync("customers");
            var json = await response.Content.ReadAsStringAsync();

            dynamic customer = JArray.Parse(json);

            return customer;
        }

        public async Task<dynamic> Get(string customerId)
        {
            var response = await _client.GetAsync($"customers/{customerId}");
            var json = await response.Content.ReadAsStringAsync();

            dynamic customer = JObject.Parse(json);

            return customer;
        }
    }
}
