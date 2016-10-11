namespace PinEvents.SeatsIo.Data
{
    using System.Collections.Generic;

    public class BookingData
    {
        public string eventKey { get; set; }
        public string secretKey { get; set; }
        public string orderId { get; set; }
        public string reservationToken { get; set; }
        public List<string> objects { get; set; }
    }

    public class EventDetails
    {
        public string chartKey { get; set; }
        public bool bookWholeTables { get; set; }
    }
}
