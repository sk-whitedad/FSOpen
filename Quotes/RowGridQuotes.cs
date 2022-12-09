using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingSizes
{
    public class RowGridQuotes
    {
        public decimal PriceBid { get; set; } //обязательно нужно использовать get конструкцию
        public decimal QuantityBid { get; set; }
        public DateTime TimeBid { get; set; }
        public string ExchangeBid { get; set; }
        public decimal PriceAsk { get; set; } //обязательно нужно использовать get конструкцию
        public decimal QuantityAsk { get; set; }
        public DateTime TimeAsk { get; set; }
        public string ExchangeAsk { get; set; }

        public RowGridQuotes(string exchangeBid, decimal priceBid, decimal quantityBid, decimal quantityAsk, decimal priceAsk, string exchangeAsk)
        {
            this.PriceBid = priceBid;
            this.QuantityBid = quantityBid;
            this.ExchangeBid = exchangeBid;
            this.PriceAsk = priceAsk;
            this.QuantityAsk = quantityAsk;
            this.ExchangeAsk = exchangeAsk;
        }
    }
}
