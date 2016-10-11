namespace PinEvents.SeatsIo.Service
{
    using Newtonsoft.Json.Linq;
    using PinEvents.SeatsIo;
    using PinEvents.SeatsIo.Data;
    using System;
    using System.Collections.Generic;
    using System.Web.Script.Serialization;
    using static PinEvents.SeatsIo.Data.ChartData;

    public class ChartService
    {
        private string endPoint;
  
        /// <summary>
        /// Get the seatplans list
        /// GET https://app.seats.io/api/charts
        /// </summary>
        public List<SeatplanData> List(string secretKey)
        {
            Connect connect = new Connect();
            endPoint = String.Format("api/charts/{0}", secretKey);
            connect.Request(Connect.Methods.GET, endPoint, null);

            var json = connect.Data;
            var response = new JavaScriptSerializer().Deserialize<List<SeatplanData>>(json);
            
            return response;
        }

        /// <summary>
        /// Get the seatplan Details.
        /// GET https://app.seats.io/api/chart/{chartKey}.json
        /// </summary>
        public ChartDetailData Details(string chartKey)
        {
            Connect connect = new Connect();
            endPoint = String.Format("api/chart/{0}.json", chartKey);
            connect.Request(Connect.Methods.GET, endPoint, null, true);

            var json = connect.Data;
            var response = new JavaScriptSerializer().Deserialize<ChartDetailData>(json);

            return response;
        }

        /// <summary>
        /// Get the seatplan for an event.
        /// GET https://app.seats.io/api/chart/<secretKey>/event/<eventKey>
        /// </summary>
        public DetailData GetEventChart(string secretKey, string eventKey)
        {
            Connect connect = new Connect();
            endPoint = String.Format("api/chart/{0}/event/{1}", secretKey, eventKey);
            connect.Request(Connect.Methods.GET, endPoint, null);

            var json = connect.Data;
            var response = new JavaScriptSerializer().Deserialize<DetailData>(json);

            return response;
        }

        /// <summary>
        /// Create a new chart from an external existing chart.
        /// Only use this if you want to migrate existing charts!
        /// POST https://app.seats.io/api/chart/create
        /// </summary>
        /// <param name="designData"></param>
        public String CreateChart(ChartDesignData designData)
        {
            Connect connect = new Connect();
            endPoint = "api/chart/create";

            var jdata = JObject.FromObject(designData);
            connect.Request(Connect.Methods.POST, endPoint, jdata);

            var chartKey = connect.Data;
            return chartKey;
        }

        /// <summary>
        /// https://app.seats.io/api/chart/<chartKey>/thumbnail
        /// </summary>
        /// <param name="chartKey"></param>
        /// <returns></returns>
        public string ThumbNail(string chartKey)
        {
            Connect connect = new Connect();
            ConnectData.GetConnectData();
            var baseUri = new Uri(ConnectData.BaseUri);
            var url = String.Format("{0}api/chart/{1}/thumbnail", baseUri, chartKey);

            return url;
        }

        /// <summary>
        /// Puts the chart in the archive (no longer visible or active)
        /// https://app.seats.io/api/chart/<secretKey>/<chartKey>/archive
        /// </summary>
        /// <param name="chartKey"></param>
        /// <returns></returns>
        public void Archive(string secretKey, string chartKey)
        {
            Connect connect = new Connect();
            endPoint = "api/chart/{0}/{1}/archive";
            connect.Request(Connect.Methods.POST, String.Format(endPoint, secretKey, chartKey), null);
        }

        /// <summary>
        /// Get the chart from the archive (makes it active)
        /// POST https://app.seats.io/api/chart/<secretKey>/<chartKey>/unarchive
        /// </summary>
        /// <param name="chartKey"></param>
        /// <returns></returns>
        public void UnArchive(string secretKey, string chartKey)
        {
            Connect connect = new Connect();
            endPoint = "api/chart/{0}/{1}/unarchive";
            connect.Request(Connect.Methods.POST, String.Format(endPoint, secretKey, chartKey), null);
        }

        /// <summary>
        /// Copies the chart and creates a new one with a new chartKey.
        /// POST https://app.seats.io/api/chart/copy
        /// </summary>
        /// <returns></returns>
        public string Copy(string secretKey, string chartKey, string chartName)
        {
            Connect connect = new Connect();

            var jdata = JObject.FromObject(new { secretKey = secretKey, chartKey = chartKey, chartName = String.Format("Copy of {0}", chartName) });
            connect.Request(Connect.Methods.POST, endPoint, jdata, true);

            var result = connect.Data;
            return result;
        }
    }
}
