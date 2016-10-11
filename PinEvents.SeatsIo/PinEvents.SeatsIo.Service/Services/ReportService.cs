using PinEvents.SeatsIo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace PinEvents.SeatsIo.Service
{
    public class ReportService
    {
        private string endPoint;

        /// <summary>
        /// POST https://app.seats.io/api/event/<secretKey>/<eventKey>/report/<reportType>
        /// </summary>
        public BookingData ByStatus(string secretKey, string eventKey)
        {
            Connect connect = new Connect();
            endPoint = String.Format("api/event/{0}/{1}/report/byStatus", secretKey, eventKey);
            connect.Request(Connect.Methods.GET, endPoint, null, true);

            var json = connect.Data;
            var reportData = new JavaScriptSerializer().Deserialize<BookingData>(json);
            return reportData;
        }
    }
}
