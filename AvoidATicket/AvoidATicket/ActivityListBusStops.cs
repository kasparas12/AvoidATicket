using Android.App;
using Android.OS;
using Android.Widget;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Android.Content.Res;
using Android.Gms.Maps.Model;
using RESTClient;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;

namespace AvoidATicket
{
    [Activity(Label = "ActivityListBusStops")]
    public class ActivityListBusStops : Activity
    {
        public List<BusStops> stops;
        private GoogleMap map;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            populateData();
            SetContentView(Resource.Layout.activity_listBusStops); // loads the HomeScreen.axml as this activity's view
            var listView = FindViewById<ListView>(Resource.Id.listStops); // get reference to the ListView in the layout

            // populate the listview with data

            listView.Adapter = new MyAdapter(this, stops);
            listView.ItemClick += OnListItemClick;  // to be defined
        }

        public void populateData()
        {
            AssetManager assets = this.Assets;

            using (var reader = new StreamReader(assets.Open("busStops.json")))
            {
                string json = reader.ReadToEnd();
                stops = JsonConvert.DeserializeObject<List<BusStops>>(json);
            }
        }

        void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var listView = sender as ListView;
            var t = stops[e.Position];

            LatLng point = new LatLng(t.Coordinate.Lat, t.Coordinate.Lng);

            DBAccess access = new DBAccess();
            access.SaveMarker(new RESTClient.Marker()
            {
                Latitude = point.Latitude,
                Longtitude = point.Longitude,
                MarkingTime = DateTime.Today.Date
            });
            Android.Widget.Toast.MakeText(this, "Adding Marker...", Android.Widget.ToastLength.Short).Show();
            Finish();
        }
    }
}