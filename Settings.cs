using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Concurrent;

namespace FishingSizes
{
    public static class TextEdit
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }

    public class SettingsBlackList
    {
        public List<string> BlackList { get; set; }
        public string FileName { get; set; }    
        public SettingsBlackList(string filename)
        {
            BlackList = new List<string>();
            FileName = filename;
        }
        public async void SaveSett(List<string> s)
        {
            using (FileStream fs = new FileStream(FileName, FileMode.Create))
            {
                await JsonSerializer.SerializeAsync<List<string>>(fs, s);
            }
        }

        public async Task LoadSett()
        {
            using (FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                try
                {
                    List<string> _settings = await JsonSerializer.DeserializeAsync<List<string>>(fs);
                    if (_settings != null)
                    {
                        BlackList = _settings;
                    }
                    else BlackList.Add(string.Empty);
                }
                catch 
                {
                    Console.WriteLine("Спаботал catch");
                    BlackList.Add(string.Empty);
                }


            }
        }
    }

    public class SettingsClosePrints
    {
        public ConcurrentDictionary<string, Decimal> ClosePrints { get; set; }  
        public DateTime DateClosePrints { get; set; }
        public async void SaveSett(SettingsClosePrints s)
        {
            using (FileStream fs = new FileStream("close_prints.json", FileMode.Create))
            {
                await JsonSerializer.SerializeAsync<SettingsClosePrints>(fs, s);
            }
        }

        public async Task LoadSett()
        {
            using (FileStream fs = new FileStream("close_prints.json", FileMode.OpenOrCreate))
            {
                SettingsClosePrints _settings = await JsonSerializer.DeserializeAsync<SettingsClosePrints>(fs);
                    DateClosePrints = _settings.DateClosePrints;
                    ClosePrints = _settings.ClosePrints;
            }
        }
    }

    public class TickerListEdit
    {
        public List<string> MyTickerList { get; set; }
        public TickerListEdit()
        {
            MyTickerList = new List<string>();
        }
        public async void SaveSett(TickerListEdit s)
        {
            using (FileStream fs = new FileStream("tickerList.json", FileMode.Create))
            {
                await JsonSerializer.SerializeAsync<TickerListEdit>(fs, s);
            }
        }

        public async Task LoadSett()
        {
            using (FileStream fs = new FileStream("tickerList.json", FileMode.OpenOrCreate))
            {
                try
                {
                    TickerListEdit _settings = await JsonSerializer.DeserializeAsync<TickerListEdit>(fs);
                    MyTickerList = _settings.MyTickerList;
                }
                catch
                {
                }
            }
        }
    }

    public class Settings
    {
        public string TokenAPITinkoff { get; set; }
        public string Key { get; set; }
        public string Secret { get; set; }
        public string TokenAlor { get; set; }
        public string TickersList { get; set; }
        public string Exch { get; set; }
        public int PrintSizeMin { get; set; }
        public int PrintSizeMax { get; set; }
        public bool Mute { get; set; }
        public decimal PriceMin { get; set; }
        public decimal PriceMax { get; set; }
        public bool Pair { get; set; }
        public bool SpradCheck { get; set; }
        public bool FPrints { get; set; }
        public decimal SpradRab { get; set; }
        public DateTime OpenSess { get; set; }
        public DateTime CloseSess { get; set; }
        public List<string> TickerCbList = new List<string>();
        public bool AlpacaUses { get; set; }
        public bool TinkoffUses { get; set; }
        public bool AlorUses { get; set; }
        public bool IBUses { get; set; }

        public async void SaveSett(Settings s)
        {
            using (FileStream fs = new FileStream("settings.json", FileMode.Create))
            {
                await JsonSerializer.SerializeAsync<Settings>(fs, s);
            }
        }

        public async Task LoadSett()
        {
            using (FileStream fs = new FileStream("settings.json", FileMode.OpenOrCreate))
            {
                try
                {
                    Settings _settings = await JsonSerializer.DeserializeAsync<Settings>(fs);
                    TokenAPITinkoff = _settings.TokenAPITinkoff;
                    Key = _settings.Key;
                    Secret = _settings.Secret;
                    TokenAlor = _settings.TokenAlor;
                    TickersList = _settings.TickersList;
                    Exch = _settings.Exch;
                    PrintSizeMin = _settings.PrintSizeMin;
                    PrintSizeMax = _settings.PrintSizeMax;
                    PriceMin = _settings.PriceMin;
                    PriceMax = _settings.PriceMax;
                    Pair = _settings.Pair;
                    Mute = _settings.Mute;
                    OpenSess = _settings.OpenSess;
                    CloseSess = _settings.CloseSess;
                    SpradCheck = _settings.SpradCheck;
                    FPrints = _settings.FPrints;
                    SpradRab = _settings.SpradRab;
                    AlpacaUses = _settings.AlpacaUses;
                    TinkoffUses = _settings.TinkoffUses;
                    AlorUses = _settings.AlorUses;
                }
                catch
                {
                }
                
            }
        }
        public string Exchange(string exch)
        {
            switch (exch)
            {
                case "A":
                    return "AMEX";
                case "B":
                    return "BX";
                case "C":
                    return "NSE";
                case "D":
                    return "FINRA";
                case "E":
                    return "MI";
                case "H":
                    return "MIAX";
                case "I":
                    return "ISE";
                case "J":
                    return "DA";
                case "K":
                    return "DX";
                case "L":
                    return "LTSE";
                case "M":
                    return "CSE";
                case "N":
                    return "NYSE";
                case "P":
                    return "ARCA";
                case "Q":
                    return "NQ";
                case "S":
                    return "NQSC";
                case "T":
                    return "NQ";
                case "U":
                    return "ME";
                case "V":
                    return "IEX";
                case "W":
                    return "CBOE";
                case "X":
                    return "X";
                case "Y":
                    return "BYX";
                case "Z":
                    return "BT";
                default:
                    return "--";
            }
        }









    }

}
