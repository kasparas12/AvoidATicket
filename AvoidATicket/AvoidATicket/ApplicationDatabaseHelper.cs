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
using Android.Database.Sqlite;
using Android.Gms.Maps.Model;
using Android.Database;

namespace AvoidATicket
{
    class ApplicationDatabaseHelper : SQLiteOpenHelper
    {
        public const int DATABASE_VERSION = 2;
        public const string DATABASE_NAME = "ApplicationDatabase.db";

        public ApplicationDatabaseHelper(Context context) : base(context, DATABASE_NAME, null, DATABASE_VERSION)
        {

        }

        public override void OnCreate(SQLiteDatabase db)
        {
            db.ExecSQL(MapMarkerContract.SQL_CREATE_MARKERTABLE);
        }

        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            db.ExecSQL(MapMarkerContract.SQL_CREATE_MARKERTABLE);
        }

        public void Savemarker(double lat, double lng)
        {
            ContentValues values = new ContentValues();

            values.Put(MapMarkerContract.MarkerTable.COLUMN_NAME_LAT, lat);
            values.Put(MapMarkerContract.MarkerTable.COLUMN_NAME_LONG, lng);

            WritableDatabase.Insert(MapMarkerContract.MarkerTable.TABLE_NAME, null, values);
        }

        public List<LatLng> RetrieveMarkerList()
        {
            string[] columns =
            {
                MapMarkerContract.MarkerTable._ID,
                MapMarkerContract.MarkerTable.COLUMN_NAME_LAT,
                MapMarkerContract.MarkerTable.COLUMN_NAME_LONG
            };

            ICursor cursor =  ReadableDatabase.Query(MapMarkerContract.MarkerTable.TABLE_NAME, columns, null, null, null, null, null);
            List<LatLng> markerList = new List<LatLng>();

            while (cursor.MoveToNext())
            {
                markerList.Add(new LatLng(cursor.GetDouble(cursor.GetColumnIndex(MapMarkerContract.MarkerTable.COLUMN_NAME_LAT)),
                                          cursor.GetDouble(cursor.GetColumnIndex(MapMarkerContract.MarkerTable.COLUMN_NAME_LONG))));
            }

            return markerList;
        }

        public void ClearAllMarkers()
        {
            string SQL_DELETE_TABLE =
                "DELETE FROM " + MapMarkerContract.MarkerTable.TABLE_NAME;
            string SQL_DELETE_SEQUENCE =
                "DELETE FROM SQLITE_SEQUENCE WHERE NAME='" + MapMarkerContract.MarkerTable.TABLE_NAME + "'";
            SQLiteDatabase db = WritableDatabase;
            db.ExecSQL(SQL_DELETE_TABLE);
            db.ExecSQL(SQL_DELETE_SEQUENCE);
        }
    }
}