namespace pinevents.SeatsIo.Service
{
    using Newtonsoft.Json.Linq;
    using PinEvents.SeatsIo.Data;
    using System;
    using System.Collections.Generic;
    using System.Web.Script.Serialization;
    public class BookingService
    {
        private string endPoint;
        private BookingData Booking = new BookingData();

        /// <summary>
        /// POST https://app.seats.io/api/book
        /// </summary>
        /// <returns></returns>
        public bool Book(BookingData booking)
        {
            Connect connect = new Connect();
            endPoint = "api/book";
            var jdata = JObject.FromObject(booking);
            connect.Request(Connect.Methods.POST, endPoint, jdata);

            return true;
        }

        /// <summary>
        /// POST https://app.seats.io/api/release
        /// </summary>
        /// <returns></returns>
        public bool Release(BookingData booking)
        {
            Connect connect = new Connect();
            endPoint = "api/release";
            var jdata = JObject.FromObject(booking);
            connect.Request(Connect.Methods.POST, endPoint, jdata);

            return true;
        }

        /// <summary>
        /// POST https://app.seats.io/api/changeStatus
        /// </summary>
        /// <returns></returns>
        public bool ChangeStatus(BookingData booking)
        {
            Connect connect = new Connect();
            endPoint = "api/changeStatus";
            var jdata = JObject.FromObject(booking);
            connect.Request(Connect.Methods.POST, endPoint, jdata); 

            return true;
        }

        /// <summary>
        /// POST https://app.seats.io/api/reserve
        /// </summary>
        /// <returns></returns>
        public bool Reserve(BookingData booking)
        {
            Connect connect = new Connect();
            endPoint = "api/reserve";
            var jdata = JObject.FromObject(booking);
            connect.Request(Connect.Methods.POST, endPoint, jdata);

            return true;
        }

        /// <summary>
        /// POST https://app.seats.io/api/reservationToken/<publicKey>/create
        /// </summary>
        /// <returns></returns>
        public string ReservationToken(string publicKey)
        {
            Connect connect = new Connect();
            endPoint = String.Format("api/reservationToken/{0}/create", publicKey);
            connect.Request(Connect.Methods.POST, endPoint, null);
            var reservationToken = connect.Data;

            return reservationToken;
        }

        /// <summary>
        /// GET https://app.seats.io/api/event/{eventKey}/orders/{orderId}/{secretKey}
        /// </summary>
        /// <returns></returns>
        public List<string> Order(BookingData booking)
        {
            Connect connect = new Connect();
            endPoint = String.Format("api/event/{0}/orders/{1}/{2}",booking.eventKey, booking.orderId, booking.secretKey);
            connect.Request(Connect.Methods.GET, endPoint, null);
            var reservationToken = connect.Data;
            var json = connect.Data;

            var response = new JavaScriptSerializer().Deserialize<List<String>>(json);

            return response;
        }
    }
}
