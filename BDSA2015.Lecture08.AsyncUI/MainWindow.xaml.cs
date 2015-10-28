using System.Windows;
using System.Windows.Controls;
using BDSA2015.Lecture08.AsyncUI.Models;
using System;
using System.Threading;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;

namespace BDSA2015.Lecture08.AsyncUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Calculate_OnClick(object sender, RoutedEventArgs e)
        {
            (sender as Button).IsEnabled = false;

            var amount = double.Parse(DKK.Text);

            var usd = await GetRateAsync("DKK", "USD");
            USD.Content = (amount * usd).ToString("N2");

            var gbp = await GetRateAsync("DKK", "GBP");
            GBP.Content = (amount * gbp).ToString("N2");

            var eur = await GetRateAsync("DKK", "EUR");
            EUR.Content = (amount * eur).ToString("N2");

            (sender as Button).IsEnabled = true;
        }

        private async Task<double> GetRateAsync(string from, string to)
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));

            using (var client = new HttpClient())
            {
                var url = $"http://currency-api.appspot.com/api/{from}/{to}.json";

                try
                {
                    var data = await client.GetAsync(url);
                    var json = await data.Content.ReadAsAsync<ExchangeRate>();

                    return json.Rate;
                }
                catch
                {
                    return double.NaN;
                }
            }
        }
    }
}
