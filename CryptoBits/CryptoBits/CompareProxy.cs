using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace CryptoBitsCompare
{
    public class CompareProxy
    {
        public async static Task<RootObject> getCoin()
        {
            var http = new HttpClient();
            var response = await http.GetAsync("https://min-api.cryptocompare.com/data/pricemulti?fsyms=BTC,ETH,XRP,XRP,BCH,LTC,EOS,XLM,ADA,NEO,MIOTA,XMR,DAS,H,TRX,USD,T,XEM,ETC,VEN,QTUM,BNB,ICX&tsyms=USD,EUR");
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(RootObject));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (RootObject)serializer.ReadObject(ms);

            return data;
        }
    }

    public class BTC
    {
        public double USD { get; set; }
        public double EUR { get; set; }
    }

    public class ETH
    {
        public double USD { get; set; }
        public double EUR { get; set; }
    }

    public class XRP
    {
        public double USD { get; set; }
        public double EUR { get; set; }
    }

    public class BCH
    {
        public double USD { get; set; }
        public double EUR { get; set; }
    }

    public class LTC
    {
        public double USD { get; set; }
        public double EUR { get; set; }
    }

    public class EOS
    {
        public double USD { get; set; }
        public double EUR { get; set; }
    }

    public class XLM
    {
        public double USD { get; set; }
        public double EUR { get; set; }
    }

    public class ADA
    {
        public double USD { get; set; }
        public double EUR { get; set; }
    }

    public class NEO
    {
        public double USD { get; set; }
        public double EUR { get; set; }
    }

    public class XMR
    {
        public double USD { get; set; }
        public double EUR { get; set; }
    }

    public class DAS
    {
        public double USD { get; set; }
        public double EUR { get; set; }
    }

    public class TRX
    {
        public double USD { get; set; }
        public double EUR { get; set; }
    }

    public class XEM
    {
        public double USD { get; set; }
        public double EUR { get; set; }
    }

    public class ETC
    {
        public double USD { get; set; }
        public double EUR { get; set; }
    }

    public class VEN
    {
        public double USD { get; set; }
        public double EUR { get; set; }
    }

    public class QTUM
    {
        public double USD { get; set; }
        public double EUR { get; set; }
    }

    public class BNB
    {
        public double USD { get; set; }
        public double EUR { get; set; }
    }

    public class ICX
    {
        public double USD { get; set; }
        public double EUR { get; set; }
    }

    public class RootObject
    {
        public BTC BTC { get; set; }
        public ETH ETH { get; set; }
        public XRP XRP { get; set; }
        public BCH BCH { get; set; }
        public LTC LTC { get; set; }
        public EOS EOS { get; set; }
        public XLM XLM { get; set; }
        public ADA ADA { get; set; }
        public NEO NEO { get; set; }
        public XMR XMR { get; set; }
        public DAS DAS { get; set; }
        public TRX TRX { get; set; }
        public XEM XEM { get; set; }
        public ETC ETC { get; set; }
        public VEN VEN { get; set; }
        public QTUM QTUM { get; set; }
        public BNB BNB { get; set; }
        public ICX ICX { get; set; }
    }
}
