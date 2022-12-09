using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FishingSizes.DataBase;

namespace FishingSizes
{
    internal class SettingsBrockers
    {
        public SingletonSettingsBrockers SettBrock { get; set; }
        public void Launch(MethodsDB methodDB)
        {
            SettBrock = SingletonSettingsBrockers.getInstance(methodDB);
        }
    }
}
