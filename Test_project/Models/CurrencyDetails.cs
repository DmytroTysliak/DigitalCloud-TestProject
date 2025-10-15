using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Test_project.Models
{
    class CurrencyDetails
    {

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }


        [JsonPropertyName("market_data")]
        public MarketData MarketData { get; set; }

        [JsonPropertyName("tickers")]
        public List<Ticker> Tickers { get; set; }

    }

    public class MarketData
    {
        [JsonPropertyName("current_price")]
        public Dictionary<string, decimal> CurrentPrice { get; set; }

        [JsonPropertyName("price_change")]
        public decimal PriceChange { get; set; }
        [JsonPropertyName("total_volume")]
        public Dictionary<string, decimal> TotalVolume { get; set; }
    }

    public class Ticker
    {
        [JsonPropertyName("market")]
        public Market Market { get; set; }

        [JsonPropertyName("last")]
        public decimal LastPrice { get; set; }
    }

    public class Market
    {
        [JsonPropertyName("name")]
        public string Name {get; set;}
    }
}
