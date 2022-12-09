using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FishingSizes
{
    public class AlorTrade
    {
        public AlorTradeData data { get; set; }
        public Guid guid { get; set; }
    }

    public class AlorOrderbook
    {
        public AlorOrderbookData data { get; set; }
        public string guid { get; set; }
    }

    public class AlorTradeData
    {
        public int id { get; set; }
        public int orderno { get; set; }
        public string symbol { get; set; }
        public int qty { get; set; }
        public double price { get; set; }
        public DateTime time { get; set; }
        public long timestamp { get; set; }
        public string side { get; set; }
        public int oi { get; set; }
        public bool existing { get; set; }
    }

    public class PriceInfo
    {
        public double price { get; set; }
        public int volume { get; set; }
    }

    public class AlorOrderbookData
    {
        public string symbol { get; set; }
        public bool snapshot { get; set; }
        public List<PriceInfo> bids { get; set; }
        public List<PriceInfo> asks { get; set; }
        public int timestamp { get; set; }
        public long ms_timestamp { get; set; }

        public DateTime time { get; set; }
        public bool existing { get; set; }
    }
}
