namespace PinEvents.SeatsIo.Data
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class ChartDetailData
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public int tablesLabelCounter { get; set; }
        [DataMember]
        public int uuidCounter { get; set; }
        [DataMember]
        public Categories categories { get; set; }
        [DataMember]
        public int version { get; set; }
        [DataMember]
        public string venueType { get; set; }
        [DataMember]
        public bool showAllButtons { get; set; }
        [DataMember]
        public int sectionScaleFactor { get; set; }
        [DataMember]
        public SubChart subChart { get; set; }

        public class Category
        {
            public string label { get; set; }
            public string color { get; set; }
            public int key { get; set; }
        }

        public class Categories
        {
            public List<Category> list { get; set; }
            public int maxCategoryKey { get; set; }
        }

        public class Text
        {
            public string text { get; set; }
            public double? centerX { get; set; }
            public double? centerY { get; set; }
            public int? rotationAngle { get; set; }
            public string fontSize { get; set; }
            public string textColor { get; set; }
            public string objectType { get; set; }
        }

        public class Center
        {
            public double? x { get; set; }
            public double? y { get; set; }
        }

        public class Shape
        {
            public int? strokeWidth { get; set; }
            public string strokeColor { get; set; }
            public string fillColor { get; set; }
            public int rotationAngle { get; set; }
            public Center center { get; set; }
            public string objectType { get; set; }
            public string uuid { get; set; }
            public string type { get; set; }
            public double? width { get; set; }
            public double? height { get; set; }
            public int? cornerRadius { get; set; }
        }

        public class Point
        {
            public double? x { get; set; }
            public double? y { get; set; }
        }

        public class TopLeft
        {
            public double? x { get; set; }
            public double? y { get; set; }
        }

        public class SeatLabeling
        {
            public object algoName { get; set; }
            public object startAtIndex { get; set; }
            public object isInverted { get; set; }
        }

        public class ObjectLabeling
        {
            public object algoName { get; set; }
            public object prefix { get; set; }
            public object startAtIndex { get; set; }
        }

        public class Seat
        {
            public double? x { get; set; }
            public double? y { get; set; }
            public string label { get; set; }
            public string categoryLabel { get; set; }
            public int? categoryKey { get; set; }
            public string uuid { get; set; }
        }

        public class Row
        {
            public string label { get; set; }
            [DataMember]
            public SeatLabeling seatLabeling { get; set; }
            [DataMember]
            public ObjectLabeling objectLabeling { get; set; }
            [DataMember]
            public List<Seat> seats { get; set; }
            [DataMember]
            public int? curve { get; set; }
            [DataMember]
            public int? chairSpacing { get; set; }
            public string objectType { get; set; }
            public string uuid { get; set; }
        }

        public class SubChart2
        {
            [DataMember]
            public int? height { get; set; }
            [DataMember]
            public int? width { get; set; }
            [DataMember]
            public List<Table> tables { get; set; }
            [DataMember]
            public List<Text> texts { get; set; }
            [DataMember(IsRequired = false, EmitDefaultValue = true)]
            public List<Row> rows { get; set; }
            [DataMember]
            public List<Shape> shapes { get; set; }
            ////[DataMember]
            ////public List<object> booths { get; set; }
            [DataMember]
            public List<GeneralAdmissionArea> generalAdmissionAreas { get; set; }
        }

        public class Section
        {
            public List<Point> points { get; set; }
            public string label { get; set; }
            public int labelSize { get; set; }
            public int labelHorizontalOffset { get; set; }
            public int labelVerticalOffset { get; set; }
            public int labelRotationAngle { get; set; }
            public string uuid { get; set; }
            public string categoryLabel { get; set; }
            public int categoryKey { get; set; }
            public TopLeft topLeft { get; set; }
            public string entrance { get; set; }
            [DataMember]
            public SubChart2 subChart { get; set; }
        }

        public class FocalPoint
        {
            public double x { get; set; }
            public double y { get; set; }
        }

        public class Origin
        {
            public double x { get; set; }
            public double y { get; set; }
        }

        public class BackgroundImage
        {
            public string backgroundImageUrl { get; set; }
            public int backgroundImageZoom { get; set; }
            public double opacity { get; set; }
            public bool showOnRenderedCharts { get; set; }
            public Origin origin { get; set; }
        }

        public class SnapOffset
        {
            public double x { get; set; }
            public double y { get; set; }
        }

        public class SubChart
        {
            [DataMember]
            public int height { get; set; }
            [DataMember]
            public int width { get; set; }
            [DataMember]
            public List<Table> tables { get; set; }
            [DataMember]
            public List<Text> texts { get; set; }
            [DataMember]
            public List<Row> rows { get; set; }
            [DataMember]
            public List<Shape> shapes { get; set; }
            //[DataMember]
            //public List<object> booths { get; set; }
            [DataMember]
            public List<GeneralAdmissionArea> generalAdmissionAreas { get; set; }
            [DataMember]
            public List<Section> sections { get; set; }
            public FocalPoint focalPoint { get; set; }
            public BackgroundImage backgroundImage { get; set; }
            public SnapOffset snapOffset { get; set; }
        }

        public class GeneralAdmissionArea
        {
            public int? rotationAngle { get; set; }
            public Center center { get; set; }
            public string categoryLabel { get; set; }
            public int? categoryKey { get; set; }
            public int? capacity { get; set; }
            public string label { get; set; }
            public string objectType { get; set; }
            public string uuid { get; set; }
            public string entrance { get; set; }
            public string type { get; set; }
            public double width { get; set; }
            public double height { get; set; }
            public int? cornerRadius { get; set; }
        }

        public class Table
        {
            public Center center { get; set; }
            public double? radius { get; set; }
            public List<Seat> seats { get; set; }
            public int? rotationAngle { get; set; }
            public int? openSpaces { get; set; }
            public string label { get; set; }
            [DataMember]
            public SeatLabeling seatLabeling { get; set; }
            [DataMember]
            public ObjectLabeling objectLabeling { get; set; }
            public string type { get; set; }
            public string objectType { get; set; }
            public string uuid { get; set; }
        }
    }
}
