using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tinkoff.Trading.OpenApi.Models;

namespace FishingSizes
{
    public class RowGridPortfolio
    {
        public string Ticker { get; set; } //обязательно нужно использовать get конструкцию
        public decimal Count { get; set; } //обязательно нужно использовать get конструкцию
        public decimal Middle { get; set; } //обязательно нужно использовать get конструкцию
        public decimal Summ { get; set; } //обязательно нужно использовать get конструкцию
        public decimal Block { get; set; }  
        public decimal Accessibly { get; set; }
        public decimal Price { get; set; }
        public decimal Profit { get; set; }

        public RowGridPortfolio(string ticker, decimal count, decimal middle, decimal summ, decimal block, decimal accessibly, decimal price, decimal profit)
        {
            Ticker = ticker;
            Count = count;
            Middle = middle;
            Summ = summ;
            Block = block;
            Accessibly = accessibly;
            Price = price;
            Profit = profit;
        }
    }

    public class PositionRub
    {
        public string Name { get; }

        public string Figi { get; }

        public string Ticker { get; }

        public string Isin { get; }

        public InstrumentType InstrumentType { get; }

        public decimal Balance { get; }

        public decimal Blocked { get; }

        public MoneyAmount ExpectedYield { get; }

        public int Lots { get; }

        public MoneyAmount AveragePositionPrice { get; }

        public MoneyAmount AveragePositionPriceNoNkd { get; }

        
        public PositionRub(string name, decimal balance, decimal blocked)
        {
            Name = name;
            Balance = balance;
            Blocked = blocked;
        }
    }
}
