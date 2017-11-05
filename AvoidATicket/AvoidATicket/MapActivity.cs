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
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using RESTClient;
using System.Threading.Tasks;

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

                DBAccess access = new DBAccess();
                access.SaveMarker(new RESTClient.Marker()
                {
                    Latitude = point.Latitude,
                    Longtitude = point.Longitude,
                    MarkingTime = DateTime.UtcNow
                });
            }
        }

        public async void OnMapReady(GoogleMap googleMap)
        {
            map = googleMap;
            googleMap.SetOnMapClickListener(this);
            googleMap.UiSettings.ZoomControlsEnabled = true;
            googleMap.UiSettings.CompassEnabled = true;
            googleMap.UiSettings.MyLocationButtonEnabled = true;

            DBAccess access = new DBAccess();
            List<RESTClient.Marker> markers = await access.RetrieveMarkerList();

            foreach (RESTClient.Marker marker in markers)
            {
                MarkerOptions options = new MarkerOptions();
                options.SetPosition(new LatLng(marker.Latitude, marker.Longtitude));
                googleMap.AddMarker(options);
            }
        }


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_map);

            allowMarkerPlacing = Intent.GetBooleanExtra("allowMarkerPlacing", false);

            locationManager = (LocationManager)GetSystemService(Context.LocationService);
            provider = locationManager.GetBestProvider(new Criteria(), false);

            /*if (locationManager.isProviderEnabled(LocationManager.GPS_PROVIDER))
            {
               // Toast.makeText(this, "GPS is Enabled in your devide", Toast.LENGTH_SHORT).show();
            }
            else
            {
                //showGPSDisabledAlertToUser();
            }*/


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
            System.Diagnostics.Debug.WriteLine("Lops ijunk GPS");
            Toast aToast = Toast.MakeText(this, "Please turn on GPS services so the app can find your location", ToastLength.Long);
            aToast.Show();
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