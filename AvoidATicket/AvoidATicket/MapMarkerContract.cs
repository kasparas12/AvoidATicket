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
using Android.Provider;

namespace AvoidATicket
{
    class MapMarkerContract
    {
        private MapMarkerContract() { }

        public static class MarkerTable
        {
            public const string _ID = "_id";
            public const string TABLE_NAME = "Markers";
            public const string COLUMN_NAME_LAT = "Latitude";
            public const string COLUMN_NAME_LONG = "Longtitute";
        }

        public const string SQL_CREATE_MARKERTABLE =
            "create table " + MarkerTable.TABLE_NAME + "( " +
                MarkerTable._ID + " integer primary key autoincrement, " +
                MarkerTable.COLUMN_NAME_LAT + " real, " +
                MarkerTable.COLUMN_NAME_LONG + " real )";
    }
}