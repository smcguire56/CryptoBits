using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace CryptoBits
{
    public class CoinProxy
    {
        public async static RootObject getCoin(long limit, String convert)
        {
            var http = new HttpClient();
            var response = await http.GetAsync("https://api.coinmarketcap.com/v1/ticker/");
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(RootObject));

            return 0;
        }
    }
    public class RootObject
    {
        public string id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public string rank { get; set; }
        public string price_usd { get; set; }
        public string price_btc { get; set; }
        public string __invalid_name__24h_volume_usd { get; set; }
        public string market_cap_usd { get; set; }
        public string available_supply { get; set; }
        public string total_supply { get; set; }
        public string max_supply { get; set; }
        public string percent_change_1h { get; set; }
        public string percent_change_24h { get; set; }
        public string percent_change_7d { get; set; }
        public string last_updated { get; set; }
        public string price_eur { get; set; }
        public string __invalid_name__24h_volume_eur { get; set; }
        public string market_cap_eur { get; set; }
    }
}
