namespace PinEvents.SeatsIo.Service
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Web.Script.Serialization;

    using Newtonsoft.Json.Linq;
    using PinEvents.SeatsIo;
    using PinEvents.SeatsIo.Data;

    /// <summary>
    /// Json Booking service API.
    /// </summary>
    public class BookingService
    {
        private string endPoint;
        private BookingData Booking = new BookingData();

        /// <summary>
        /// POST https://app.seats.io/api/book
        /// http://www.seats.io/docs/api#api-reference-booking-and-releasing-objects-booking-seats-tables-or-booths
        /// </summary>
        /// <returns>Success</returns>
        public bool Book(BookingData booking)
        {
            try
            {
                Connect connect = new Connect();
                endPoint = "api/book";
                var jdata = JObject.FromObject(booking);
                connect.Request(Connect.Methods.POST, endPoint, jdata);

                return true;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// POST https://app.seats.io/api/release
        /// http://www.seats.io/docs/api#api-reference-booking-and-releasing-objects-releasing-seats-tables-or-booths
        /// </summary>
        /// <returns>Success</returns>
        public bool Release(BookingData booking)
        {
            try
            {
                Connect connect = new Connect();
                endPoint = "api/release";
                var jdata = JObject.FromObject(booking);
                connect.Request(Connect.Methods.POST, endPoint, jdata);

                return true;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// POST https://app.seats.io/api/changeStatus
        /// http://www.seats.io/docs/api#api-reference-booking-and-releasing-objects-changing-status-of-seats-tables-or-booths
        /// </summary>
        /// <returns>Success</returns>
        public bool ChangeStatus(BookingData booking)
        {
            try
            {
                Connect connect = new Connect();
                endPoint = "api/changeStatus";
                var jdata = JObject.FromObject(booking);
                connect.Request(Connect.Methods.POST, endPoint, jdata);

                return true;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// POST https://app.seats.io/api/reserve
        /// DOC <a href="http://www.seats.io/docs/api#api-reference-booking-and-releasing-objects-temporarily-reserving-objects">Reserve objects</a>
        /// </summary>
        /// <returns>Success</returns>
        public bool Reserve(BookingData booking)
        {
            try
            {
                Connect connect = new Connect();
                endPoint = "api/reserve";
                var jdata = JObject.FromObject(booking);
                connect.Request(Connect.Methods.POST, endPoint, jdata);

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// POST https://app.seats.io/api/reservationToken/<publicKey>/create
        /// http://www.seats.io/docs/api#api-reference-booking-and-releasing-objects-generating-a-reservation-token
        /// </summary>
        /// <returns>ReservationToken</returns>
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
        /// http://www.seats.io/docs/api#api-reference-booking-and-releasing-objects-orders
        /// </summary>
        /// <returns>The Response response will be an array of seat id’s, like this: ["A-3","A-5"]</returns>
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
