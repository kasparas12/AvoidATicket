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
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using static Android.Gms.Maps.GoogleMap;
using Android.Database.Sqlite;
using Plugin.Geolocator;
using Android.Locations;

namespace AvoidATicket
{
    [Activity(Label = "MapActivity")]
    public class MapActivity : Activity, IOnMapReadyCallback, IOnMapClickListener
    {
        private GoogleMap map;
        private bool allowMarkerPlacing;

        private double latitude = 54.674836;   // stock location:
        private double longitude = 25.273971;  //  MIF Saltiniai

        public void OnMapClick(LatLng point)
        {
            if (allowMarkerPlacing)
            {
                MarkerOptions options = new MarkerOptions();
                options.SetPosition(point);
                map.AddMarker(options);

                ApplicationDatabaseHelper dbHelper = new ApplicationDatabaseHelper(this);
                dbHelper.Savemarker(point.Latitude, point.Longitude);
            }
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            map = googleMap;
            googleMap.SetOnMapClickListener(this);

            LatLng coordinates = new LatLng(latitude, longitude);
            MarkerOptions markerOptions = new MarkerOptions();

            //your location marker
            markerOptions.SetPosition(coordinates);
            markerOptions.SetTitle("My Location");
            markerOptions.SetSnippet("You are here");
            googleMap.AddMarker(markerOptions);

            googleMap.UiSettings.ZoomControlsEnabled = true;
            googleMap.UiSettings.CompassEnabled = true;
            googleMap.UiSettings.MyLocationButtonEnabled = true;

            //move & zoom camera to your location
            CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
            builder.Target(coordinates);
            CameraPosition position = builder.Build();
            CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom(coordinates, 16);
            googleMap.MoveCamera(camera);


            ApplicationDatabaseHelper dbHelper = new ApplicationDatabaseHelper(this);
            List<LatLng> markerList = dbHelper.RetrieveMarkerList();

            foreach (LatLng value in markerList)
            {
                MarkerOptions marker = new MarkerOptions();
                marker.SetPosition(value);
                map.AddMarker(marker);
            }

        }


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_map);

            allowMarkerPlacing = Intent.GetBooleanExtra("allowMarkerPlacing", false);

            MapFragment mapFragment = (MapFragment)FragmentManager.FindFragmentById(Resource.Id.map);
            mapFragment.GetMapAsync(this); 

            // Create your application here
        }

    }
}