
namespace pinevents.SeatsIo.Service
{
    using Newtonsoft.Json.Linq;
    using PinEvents.SeatsIo.Data;
    using PinEvents.SeatsIo.Exceptions;
    using System.Collections.Generic;
    using System.Web.Script.Serialization;

    public class EventService
    {
        private string endPoint;
        private Connect.Methods Method;

        /// <summary>
        /// POST https://app.seats.io/api/linkChartToEvent
        /// </summary>
        public bool LinkChartToEvent(string secretKey, string chartKey, string eventKey)
        {
            Connect connect = new Connect();
            Method = Connect.Methods.POST;
            endPoint = "api/linkChartToEvent";
            var data = new { secretKey = secretKey, eventKey = eventKey, chartKey = chartKey };
            var jdata = JObject.FromObject(data);
            connect.Request(Method, endPoint, jdata);

            var json = connect.Data;
            //var userData = new JavaScriptSerializer().Deserialize<UserData>(json);
            return true;
        }

        /// <summary>
        /// POST https://app.seats.io/api/linkChartToEvents
        /// </summary>
        public bool LinkChartToEvents(string secretKey, string chartKey, List<string> eventKeys)
        {
            Connect connect = new Connect();
            Method = Connect.Methods.POST;
            endPoint = "api/linkChartToEvents";
            var data = new { secretKey = secretKey, eventKeys = eventKeys, chartKey = chartKey };
            var jdata = JObject.FromObject(data);
            connect.Request(Method, endPoint, jdata);

            var json = connect.Data;
            //var userData = new JavaScriptSerializer().Deserialize<UserData>(json);
            return true;
        }

        /// <summary>
        /// POST https://app.seats.io/event/delete/eventKey
        /// </summary>
        /// <param name="secretKey"></param>
        /// <param name="chartKey"></param>
        /// <param name="eventKeys"></param>
        /// <returns></returns>
        public bool RemoveEventFromChart(string secretKey, string chartKey, string eventKey)
        {
            Connect connect = new Connect();
            Method = Connect.Methods.DELETE;
            endPoint = string.Format("event/delete/{0}", eventKey);
            var data = new { secretKey = secretKey, chartKey = chartKey };
            var jdata = JObject.FromObject(data);
            connect.Request(Method, endPoint, jdata);
          
            return true;
        }

        /// <summary>
        /// GET https://app.seats.io/api/event/secretKey/eventKey/details
        /// </summary>
        public EventDetails Details(string secretKey, string eventKey)
        {
            Connect connect = new Connect();
            Method = Connect.Methods.GET;
            endPoint = "api/event/{0}/{1}/details";
            connect.Request(Method, string.Format(endPoint, secretKey, eventKey), null);

            var json = connect.Data;
            var eventData = new JavaScriptSerializer().Deserialize<EventDetails>(json);
            return eventData;
        }

        /// <summary>
        /// https://app.seats.io/api/chart/<secretKey>/event/<eventKey>
        /// </summary>
        public EventData.ChartDetails ChartDetails(string secretKey, string eventKey)
        {
            Connect connect = new Connect();
            endPoint = string.Format("api/chart/{0}/event/{1}", secretKey, eventKey);
            connect.Request(Connect.Methods.GET, endPoint, null, false);

            var json = connect.Data;
            if (json.ToLower().Contains("event not found"))
                throw new ValidationException("error_event_chart_not_found");

            var eventData = new JavaScriptSerializer().Deserialize<EventData.ChartDetails>(json);
            return eventData;
        }
    }
}
