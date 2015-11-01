using BDSA2015.Lecture08.AsyncUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BDSA2015.Lecture07.AsyncUI.ViewModels
{
    public class CurrencyViewModel : BaseViewModel
    {
        private double _usd;

        public double USD
        {
            get { return _usd; }

            set
            {
                _usd = value;
                OnPropertyChanged();
            }
        }

        private double _gbp;

        public double GBP
        {
            get { return _gbp; }

            set
            {
                _gbp = value;
                OnPropertyChanged();
            }
        }

        private double _eur;

        public double EUR
        {
            get { return _eur; }

            set
            {
                _eur = value;
                OnPropertyChanged();
            }
        }

        private double _dkk;

        public double DKK
        {
            get { return _dkk; }

            set
            {
                _dkk = value;
                OnPropertyChanged();
            }
        }

        public async Task Calculate()
        {
            USD = await GetRateAsync("DKK", "USD") * 100.0;
            GBP = await GetRateAsync("DKK", "GBP") * 100.0;
            EUR = await GetRateAsync("DKK", "EUR") * 100.0;
        }

        private async Task<double> GetRateAsync(string from, string to)
        {
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
