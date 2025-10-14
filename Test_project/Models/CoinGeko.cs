using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Test_project.Models
{
    class CoinGeko
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }


        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("current_price")]
        public decimal Current_Price { get; set; }

        [JsonPropertyName("market_cap_rank")]
        public int Market_Cap_Rank { get; set; }
    }
}
