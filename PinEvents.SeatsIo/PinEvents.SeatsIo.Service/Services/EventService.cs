namespace PinEvents.SeatsIo.Service
{
    using System;
    using System.Collections.Generic;
    using System.Web.Script.Serialization;

    using Newtonsoft.Json.Linq;
    using PinEvents.SeatsIo;
    using PinEvents.SeatsIo.Data;
    using PinEvents.SeatsIo.Exceptions;
    
    /// <summary>
    /// The Seats.io Event service.
    /// </summary>
    public class EventService
    {
        /// <summary>
        /// End point for action.
        /// </summary>
        private string endPoint;
        private Connect.Methods method;

        /// <summary>
        /// POST https://app.seats.io/api/linkChartToEvent
        /// DOC http://www.seats.io/docs/api#api-reference-events-createupdate-a-single-event
        /// </summary>
        /// <param name="secretKey">Users secret key</param>
        /// <param name="chartKey">Chart key</param>
        /// <param name="eventKey">Event key</param>
        /// <returns>Returns success</returns>
        public bool LinkChartToEvent(string secretKey, string chartKey, string eventKey)
        {
            Connect connect = new Connect();
            this.method = Connect.Methods.POST;
            this.endPoint = "api/linkChartToEvent";
            var data = new { secretKey = secretKey, eventKey = eventKey, chartKey = chartKey };
            var jdata = JObject.FromObject(data);
            connect.Request(this.method, this.endPoint, jdata);

            return true;
        }

        /// <summary>
        /// POST https://app.seats.io/api/linkChartToEvents
        /// DOC http://www.seats.io/docs/api#api-reference-events-createupdate-multiple-events
        /// </summary>
        /// <param name="secretKey">Users secret key</param>
        /// <param name="chartKey">Chart key</param>
        /// <param name="eventKey">Event key</param>
        /// <returns>Returns success</returns>
        public bool LinkChartToEvents(string secretKey, string chartKey, List<string> eventKeys)
        {
            Connect connect = new Connect();
            this.method = Connect.Methods.POST;
            this.endPoint = "api/linkChartToEvents";
            var data = new { secretKey = secretKey, eventKeys = eventKeys, chartKey = chartKey };
            var jdata = JObject.FromObject(data);
            connect.Request(this.method, this.endPoint, jdata);

            return true;
        }
        
        /// <summary>
        /// GET https://app.seats.io/api/event/secretKey/eventKey/details
        /// DOC http://www.seats.io/docs/api#api-reference-events-event-details
        /// </summary>
        public EventDetails Details(string secretKey, string eventKey)
        {
            Connect connect = new Connect();
            this.endPoint = "api/event/{0}/{1}/details";
            connect.Request(Connect.Methods.GET, string.Format(this.endPoint, secretKey, eventKey), null);

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
            this.endPoint = string.Format("api/chart/{0}/event/{1}", secretKey, eventKey);
            connect.Request(Connect.Methods.GET, this.endPoint, null, false);

            var json = connect.Data;
            if (json.ToLower().Contains("event not found"))
            {
                throw new ValidationException("error_event_chart_not_found");
            }

            var eventData = new JavaScriptSerializer().Deserialize<EventData.ChartDetails>(json);
            return eventData;
        }
    }
}
