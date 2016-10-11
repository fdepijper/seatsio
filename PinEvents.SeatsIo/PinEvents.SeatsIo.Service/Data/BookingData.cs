using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinEvents.SeatsIo.Data
{
    public class BookingData
    {
        public long? EventId { get; set; }
        public string EventKey { get; set; }
        public string secretKey { get; set; }
        public string reservationToken { get; set; }
        public string orderId { get; set; }

        public List<BookObject> free { get; set; }
        public List<BookObject> booked { get; set; }
        public List<BookObject> reservedByToken { get; set; }

        public class BookObject
        {
            public long? TicketTypeId { get; set; }
            public string uuid { get; set; }
            public string label { get; set; }
            public string status { get; set; }
            public string objectType { get; set; }
            public string category { get; set; }
            public int? categoryKey { get; set; }
            public string categoryLabel { get; set; }
            public int? capacity { get; set; }
            public int? numBooked { get; set; }
        }
    }

    public class EventDetails
    {
        public string chartKey { get; set; }
        public bool bookWholeTables { get; set; }
    }
}
