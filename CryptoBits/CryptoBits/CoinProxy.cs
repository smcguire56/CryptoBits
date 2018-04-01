using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using CryptoBitsCompare;

namespace CryptoBits
{
    public class CoinProxy
    {
        public async static Task<RootObject> getCoin()
        {
            var http = new HttpClient();
            var response = await http.GetAsync("https://api.icowatchlist.com/public/v1/");
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(RootObject));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (RootObject)serializer.ReadObject(ms);

            return data;
        }
    }


    public class Live
    {
        public string name { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public string website_link { get; set; }
        public string icowatchlist_url { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }
        public string timezone { get; set; }
    }

    public class Upcoming
    {
        public string name { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public string website_link { get; set; }
        public string icowatchlist_url { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }
        public string timezone { get; set; }
    }

    public class Finished
    {
        public string name { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public string website_link { get; set; }
        public string icowatchlist_url { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }
        public string timezone { get; set; }
        public string coin_symbol { get; set; }
        public string price_usd { get; set; }
        public string all_time_roi { get; set; }
    }

    public class Ico
    {
        public List<Live> live { get; set; }
        public List<Upcoming> upcoming { get; set; }
        public List<Finished> finished { get; set; }
    }

    public class RootObject
    {
        public Ico ico { get; set; }

        public static implicit operator RootObject(CryptoBitsCompare.RootObject v)
        {
            throw new NotImplementedException();
        }
    }
}
