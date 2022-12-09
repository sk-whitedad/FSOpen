using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpaca.Markets;

namespace FishingSizes
{
    public class Print
    {
        public int Id { get; set; }
        public string Ticker { get; set; }
        public DateTime TimePrint { get; set; }
        public string Exchange { get; set; }
        public Decimal Price { get; set; }
        public int Vol { get; set; }
        public string? Flag { get; set; }
    }

    public class PrintHandlerDB
    {
        public async void ReceivingPrints(ITrade trade)//запись принта в DB
        {
            using (AppContext db = new AppContext())
            {
                        Print print = new() { Ticker = trade.Symbol, Price = trade.Price, Vol = Decimal.ToInt32(trade.Size), Exchange = trade.Exchange, Flag = String.Join("", trade.Conditions), TimePrint = trade.TimestampUtc.ToLocalTime() };
                        await db.Prints.AddAsync(print);
                        db.SaveChanges();
            }
        }




    }





}


