using PinEvents.SeatsIo.Settings;
using PinEvents.SeatsIo.Settings.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinEvents.SeatsIo.Data
{
    public class ConnectData
    {
        public static String SecretKey { get; set; }
        public static String BaseUri { get; set; }

        /// <summary>
        /// Get the dat from the PinEvents Database sysSETTING
        /// </summary>
        public static void GetConnectData()
        {
            ISysSettingBm bm = new SysSettingBm();
            var settings = bm.GetValues();
            BaseUri = settings["seats.io.baseuri"];
        }
    }
}
