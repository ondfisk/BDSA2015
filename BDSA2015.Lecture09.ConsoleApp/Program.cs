using System;
using System.Net.Http;

namespace BDSA2015.Lecture09.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:18716/api/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");

                var response = client.GetAsync("customers").Result;

                var customers = response.Content.ReadAsAsync<Customer[]>().Result;

                var first = customers[0];
                first.CompanyName += " pango";

                response = client.PutAsJsonAsync($"customers/{first.Id}", first).Result;
                var s = response.Content.ReadAsStringAsync().Result;

                Console.WriteLine(s);
            }
        }
    }
}
