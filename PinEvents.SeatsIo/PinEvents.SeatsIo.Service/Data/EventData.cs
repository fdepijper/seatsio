using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinEvents.SeatsIo.Data
{
    public class EventData
    {
        public class Category
        {
            public string label { get; set; }
            public string color { get; set; }
            public int key { get; set; }
        }

        public class ChartDetails
        {
            public string key { get; set; }
            public string name { get; set; }
            public List<Category> categories { get; set; }
        }
    }
}
