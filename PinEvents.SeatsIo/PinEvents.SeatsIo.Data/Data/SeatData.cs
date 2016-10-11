using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinEvents.SeatsIo.Data
{
    public class SeatData
    {
        public List<Seat> Seats { get; set; }
        public int SeatCount { get; set; }
        public int CategoryCount { get; set; }

        public class Seat
        {
            public double x { get; set; }
            public double y { get; set; }
            public string label { get; set; }
            public string categoryLabel { get; set; }
            public int categoryKey { get; set; }
            public string uuid { get; set; }
        }
    }
}
