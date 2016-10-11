namespace PinEvents.SeatsIo.Data
{
    using System.Collections.Generic;

    public class ChartData
    {
        public List<SeatplanData> Seatplans { get; set; }
        public DetailData ChartDetails { get; set; }

        public class Category
        {
            public string label { get; set; }
            public string color { get; set; }
            public string key { get; set; }
        }

        public class ChartDesignData
        {
            public string secretKey { get; set; }
            public Drawing drawing { get; set; }

            public class Drawing
            {
                public string name { get; set; }
                public List<Category> categories { get; set; } = new List<Category>();
            }
        }

        public class CategoryData
        {
            public string label { get; set; }
            public string color { get; set; }
            public string key { get; set; }
        }

        public class SeatplanData
        {
            public string key { get; set; }
            public string name { get; set; }
            public List<CategoryData> categories { get; set; }
        }
        
        public class Categories
        {
            public List<CategoryData> list { get; set; }
        }
        
        public class DetailData
        {
            public string name { get; set; }
            public Categories categories { get; set; }
            public SubChartData subChart { get; set; }

            public class TextData
            {
                public string text { get; set; }
                public double centerX { get; set; }
                public double centerY { get; set; }
            }

            public class SeatData
            {
                public double x { get; set; }
                public double y { get; set; }
                public string label { get; set; }
                public string categoryLabel { get; set; }
            }

            public class RowData
            {
                public string label { get; set; }
                public List<SeatData> seats { get; set; }
            }

            public class SubChartData
            {
                public int height { get; set; }
                public int width { get; set; }
                public List<object> tables { get; set; }
                public List<TextData> texts { get; set; }
                public List<RowData> rows { get; set; }
            }
        }
    }
}
