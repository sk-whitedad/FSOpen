using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingSizes
{
    public interface IHasSettings
    {
        Settings Sett { get; }
        Dictionary<string, Brocker> BrockerSett { get; }
    }

    public interface IHasTickerList   
    {
        TickerListEdit Sett_tle { get; }
    }

    public interface IHasBlackList
    {
        SettingsBlackList BlackList { get; }
    }
}
