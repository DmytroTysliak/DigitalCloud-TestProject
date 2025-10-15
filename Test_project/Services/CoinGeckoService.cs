using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Test_project.Models;

namespace Test_project.Services
{
    class CoinGeckoService
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<CoinGeko?> GetCoinAsync(string coinId)
        {
            string url = $"https://api.coingecko.com/api/v3/coins/{coinId}";
            var response = await _httpClient.GetStringAsync(url);

            var options = new JsonSerializerOptions{ PropertyNameCaseInsensitive = true};
            var data = JsonConvert.DeserializeObject<CoinGeko>(response);
            return data;
        }
    }
}
