using System;

namespace RESTClient
{
    public partial class Marker
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longtitude { get; set; }
        public Nullable<System.DateTime> MarkingTime { get; set; }
    }
}
