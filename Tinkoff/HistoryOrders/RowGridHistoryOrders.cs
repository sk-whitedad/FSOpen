using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingSizes
{
    public class RowGridHistoryOrders
    {
        public string Ticker { get; set; } //тикер
        public DateTime Date { get; set; } //дата сделки
        public int Vol { get; set; } //количество
        public decimal Price { get; set; } //цена сделки
        public decimal Summ { get; set; } //Общая сумма
        public string TypeOrder { get; set; }//тип сделки


        public RowGridHistoryOrders(string ticker, DateTime date, int vol, decimal price, decimal summ, string typeorder)
        {
            Ticker = ticker;
            Date = date;    
            Vol = vol;
            Price = price;
            Summ = summ;
            TypeOrder = typeorder;
        }
    }
}
