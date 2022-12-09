using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingSizes
{
    public class RowGridArb
    {
        public decimal Bid_US { get; set; }
        public decimal Ask_US { get; set; }
        public decimal Bid_SPB { get; set; }
        public decimal Ask_SPB { get; set; }
        public int VolBid_US { get; set; }
        public int VolAsk_US { get; set; }
        public int VolBid_SPB { get; set; }
        public int VolAsk_SPB { get; set; }
        public string Exc_Bid { get; set; }
        public string Exc_Ask { get; set; }
        public decimal Delta { get; set; }
        public string Ticker { get; set; }

        public RowGridArb(string ticker, int volask_spb, decimal ask_spb, decimal bid_us, int volbid_us, string exc_bid, decimal delta, string exc_ask, int volask_us, decimal ask_us, decimal bid_spb, int volbid_spb)
        {
            this.Bid_US = bid_us;
            this.Ask_US = ask_us;
            this.Bid_SPB = bid_spb;
            this.Ask_SPB = ask_spb;
            this.VolBid_US = volbid_us;
            this.VolAsk_US = volask_us;
            this.VolBid_SPB = volbid_spb;
            this.VolAsk_SPB = volask_spb;
            this.Exc_Bid = exc_bid;
            this.Exc_Ask = exc_ask;
            this.Delta = delta;
            this.Ticker = ticker;

        }
    }
}
