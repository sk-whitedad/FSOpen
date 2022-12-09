using System.Collections.Generic;
using FishingSizes.DataBase;

namespace FishingSizes
{
    internal class SingletonSettingsBrockers
    {
        private static SingletonSettingsBrockers instance;
        public Dictionary<string, Brocker> BrockerSett { get; set; }
        private MethodsDB MethodsDB { get; set; }
        private SingletonSettingsBrockers(MethodsDB methodDB)
        {
            this.BrockerSett = new Dictionary<string, Brocker>();
            this.MethodsDB = methodDB;
            SettingsFromDB();
        }
        public static SingletonSettingsBrockers getInstance(MethodsDB methodDB)
        {
            if (instance == null)
                instance = new SingletonSettingsBrockers(methodDB);
            return instance;
        }

        private void SettingsFromDB()//загрузка настроек через DB
        {
            var brockers = MethodsDB.LoadDBSettings();
            BrockerSett.Add("Tinkoff", brockers.Find(item => item.Name == "Tinkoff"));
            BrockerSett.Add("Alor", brockers.Find(item => item.Name == "Alor"));
            BrockerSett.Add("Alpaca", brockers.Find(item => item.Name == "Alpaca"));
            BrockerSett.Add("IB", brockers.Find(item => item.Name == "IB"));
        }
    }
}
