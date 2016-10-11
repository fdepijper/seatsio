using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinEvents.SeatsIo.Settings.Interface
{
    public interface ISysSettingBm
    {
        IDictionary<string, string> GetValues();
    }
}
