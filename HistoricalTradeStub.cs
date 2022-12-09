using Alpaca.Markets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingSizes
{
    public class HistoricalTradeStub : ITrade
    {
        public string Symbol { get; set; }

        public DateTime TimestampUtc { get; set; }

        public decimal Price { get; set; }

        public decimal Size { get; set; }

        public ulong TradeId { get; set; }

        public string Exchange { get; set; }

        public string Tape { get; set; }

        public IReadOnlyList<string> Conditions { get; set; }

        public TakerSide TakerSide { get; set; }
    }


    public class HistoricalQuoteStub : IQuote
    {
        string IQuote.Symbol { get; }

        DateTime IQuote.TimestampUtc { get; }

        string IQuote.BidExchange { get; }

        string IQuote.AskExchange { get; }

        decimal IQuote.BidPrice { get; }

        decimal IQuote.AskPrice { get; }

        decimal IQuote.BidSize { get; }

        decimal IQuote.AskSize { get; }

        string IQuote.Tape { get; }

        IReadOnlyList<string> IQuote.Conditions { get; }
    }


}
