using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Xml.Linq;
using Test_project.Models;
using Test_project.Services;

namespace Test_project.ViewModels
{
    class CurrencyDetailsViewModel
    {
        public CurrencyDetails? Currency { get; private set; }

        public decimal Price => Currency?.MarketData?.CurrentPrice.ContainsKey("usd") == true
                            ? Currency.MarketData.CurrentPrice["usd"]
                            : 0;

        public decimal Volume => Currency?.MarketData?.TotalVolume.ContainsKey("usd") == true
                                 ? Currency.MarketData.TotalVolume["usd"]
                                 : 0;

        public string Name => Currency?.Name ?? "";
        public string Symbol => Currency?.Symbol ?? "";

        public async Task LoadCurrencyDetailAsync(string coinId)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "WPFApp");

            string url = $"https://api.coingecko.com/api/v3/coins/{coinId}?tickers=true&market_data=true";
            var json = await client.GetStringAsync(url);

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            Currency = JsonSerializer.Deserialize<CurrencyDetails>(json, options);

            OnPropertyChanged(nameof(Price));
            OnPropertyChanged(nameof(Volume));
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Symbol));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
