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
using Android.Locations;

namespace AvoidATicket
{
    [Activity(Label = "MapActivity")]
    public class MapActivity : Activity, IOnMapReadyCallback, IOnMapClickListener, ILocationListener
    {
        private GoogleMap map;
        private bool allowMarkerPlacing;

        LocationManager locationManager;
        String provider;

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
            googleMap.UiSettings.ZoomControlsEnabled = true;
            googleMap.UiSettings.CompassEnabled = true;
            googleMap.UiSettings.MyLocationButtonEnabled = true;

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

            locationManager = (LocationManager)GetSystemService(Context.LocationService);
            provider = locationManager.GetBestProvider(new Criteria(), false);

            Location location = locationManager.GetLastKnownLocation(provider);
            if(location == null)
            {
                System.Diagnostics.Debug.WriteLine("Cant find your location");
            }

            MapFragment mapFragment = (MapFragment)FragmentManager.FindFragmentById(Resource.Id.map);
            mapFragment.GetMapAsync(this); 

        }
        // zemiau 6 GPS tracking metodai
        protected override void OnResume()
        {
            base.OnResume();
            locationManager.RequestLocationUpdates(provider, 2000, 50, this);
        }

        protected override void OnPause()
        {
            base.OnPause();
            locationManager.RemoveUpdates(this);
        }

        void ILocationListener.OnLocationChanged(Location location)
        {
            double lat, lng;
            lat = location.Latitude;
            lng = location.Longitude;

            LatLng coordinates = new LatLng(lat, lng);
            MarkerOptions markerOptions = new MarkerOptions();
            markerOptions.SetPosition(new LatLng(lat, lng));
            markerOptions.SetTitle("My Location");
            markerOptions.SetSnippet("You are here");
            map.AddMarker(markerOptions);

            CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
            builder.Target(new LatLng(lat , lng));
            CameraPosition position = builder.Build();
            CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom(coordinates, 16);
            map.MoveCamera(camera);
        }

        void ILocationListener.OnProviderDisabled(string provider)
        {
            //throw new NotImplementedException();
        }

        void ILocationListener.OnProviderEnabled(string provider)
        {
            //throw new NotImplementedException();
        }

        void ILocationListener.OnStatusChanged(string provider, Availability status, Bundle extras)
        {
            //throw new NotImplementedException();
        }
    }
}