using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingSizes
{
    public class RowGridSpb
    {
        public decimal Price { get; set; } //обязательно нужно использовать get конструкцию
        public decimal Quantity { get; set; }
        public decimal Summ { get; set; }
        public string Time { get; set; }

        public RowGridSpb(decimal price, decimal quantity, decimal summ, string time)
        {
            this.Price = price;
            this.Quantity = quantity;
            this.Time = time;
            this.Summ = summ;
        }
    }
}
