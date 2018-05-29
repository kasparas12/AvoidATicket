using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AvoidATicket
{
    public struct StopTooltip
    {
        public string Name { get; set; }
        public string DirectionText { get; set; }
        public string DistanceText { get; set; }
        public List<SchedulesAtStop> SchedulesList { get; set; }
    }
    public struct SchedulesAtStop
    {
        public string Name { get; set; }
        public string Color { get; set; }
    }
    public class Coordinate
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
    }

    public class BusStops
    {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Direction { get; set; }
            public Coordinate Coordinate { get; set; }
            public string IconUrl { get; set; }
            public StopTooltip StopTooltip { get; set; }

    }
}