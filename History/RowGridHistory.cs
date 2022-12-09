using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingSizes
{
    public class RowGridHistoryTrade
    {
        public decimal Price { get; set; } //обязательно нужно использовать get конструкцию
        public decimal Quantity { get; set; }
        public string Time { get; set; }
        public string Exchange { get; set; }
        public string Flag { get; set; }

        public RowGridHistoryTrade(decimal price, decimal quantity, string time, string exchange, string flag)
        {
            this.Price = price;
            this.Quantity = quantity;
            this.Time = time;
            this.Exchange = exchange;
            this.Flag = flag;
        }
    }
}
