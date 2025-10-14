using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Test_project.Models;

namespace Test_project.Services
{
    class CoinMarketCapService
    {
        private readonly HttpClient _client;
        private const string BaseUrl = "https://pro-api.coinmarketcap.com/v1/";

        public CoinMarketCapService(string apiKey)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(BaseUrl);
            _client.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", apiKey);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Currency> GetPriceAsync(string symbol)
        {
            var url = $"cryptocurrency/quotes/latest?symbol={symbol}";
            var respons = await _client.GetAsync(url);
            respons.EnsureSuccessStatusCode();

            string result = await respons.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(result);

            string name_of_coin = json["data"]?[symbol]?["name"]?.ToString();
            decimal price_of_coin = json["data"]?[symbol]?["quote"]?["USD"]?["price"]?.ToObject<decimal>() ?? 0;

            return new Currency (name_of_coin, symbol, price_of_coin);
        }
    }
}
