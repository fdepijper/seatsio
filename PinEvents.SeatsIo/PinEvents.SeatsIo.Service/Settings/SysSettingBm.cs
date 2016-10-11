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
            values.Add("seats.io.baseuri", "https://app.seats.io");
            values.Add("secretKey", "your-secret-key");
            values.Add("publicKey", "your-public-key");
            values.Add("designerKey", "your-designer-key");
            values.Add("chartKey", "your-chart-key");
            values.Add("eventKey", "your-event-key");
            return values;
        }
    }
}
