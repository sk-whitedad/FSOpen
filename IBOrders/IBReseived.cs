using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using IBApi;

namespace FishingSizes
{
   public class IBReseived
    {
        public void ApiClient_OnPrintReceived(object sender, (int, HistoricalTickBidAsk[], bool) e)
        {
            Debug.WriteLine($" == ApiClient_OnPrintReceived == : {sender} : {e}");
        }

        public void ApiClient_OnReady(object sender, EventArgs e)
        {
            Debug.WriteLine($" == Сообщение == : {sender} : {e}");
            if (sender is TWSApiWrapper api)
            {
                Debug.WriteLine($" == ApiClient_OnReady == : {sender} : {e}");
                Terminal.IB_ApiClient_OnReady = true;

            }
        }

        private void ApiClient_NoReady_Terminal(object sender, EventArgs e)
        {
            Debug.WriteLine($" == Сообщение == : {sender} : {e}");
            if (sender is TWSApiWrapper api)
            {
                Debug.WriteLine($" == ApiClient_NoReady == : {sender} : {e}");
                SetStatusIcon("NoConnect.png");
                Terminal.IB_ApiClient_OnReady = true;
            }
        }
        public void SetStatusIcon(string s)
        {
                //tsIB.Image = Image.FromFile(s);
        }

    }
}
