using PinEvents.SeatsIo.Settings.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinEvents.SeatsIo.Settings
{
    public class SysSettingBm : ISysSettingBm
    {
        public IDictionary<string,string> GetValues()
        {
            IDictionary<string, string> values = new Dictionary<string, string>();

            return values;
        }
    }
}
