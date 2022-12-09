using System;
using IBApi;
using System.IO;

namespace FishingSizes
{
    public class ApiProgram
    {
        public static TWSApiWrapper ApiWrapper { get; private set; }

        public static void Main(string[] args)
        {
            var apiClient = new TWSApiWrapper();
            ApiWrapper = apiClient;
            
            apiClient.OnReady += ApiClient_OnReady;//добавляем обработчик события ApiClient_OnReady к событию OnReady
            apiClient.OnPrintReceived += ApiClient_OnPrintReceived;
            apiClient.Run("localhost:7497"); // 4002 | 7497
            
            Console.ReadLine();
        }

        private static void ApiClient_OnPrintReceived(object sender, (int, HistoricalTickBidAsk[], bool) e)
        {
            (int reqId, HistoricalTickBidAsk[] ticks, _) = e;
            foreach (var tick in ticks)
            {
                Console.WriteLine("==ApiClient_OnPrintReceived==");
            }
        }

        private static void ApiClient_OnReady(object sender, EventArgs e)
        {
            if (sender is TWSApiWrapper api)
            {
                Console.WriteLine("==ApiClient_OnReady==");
                //api.OrderPlace();
            }
        }
    }
}





