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
        Location location;

        private double distance;
        private const double maximumDistance = 1.5; // in meters

        public void OnMapClick(LatLng point)
        {
            double lat1 = location.Latitude;
            double lat2 = point.Latitude;
            double lng1 = location.Longitude;
            double lng2 = point.Longitude;

            distance = caculateDistance(lat1, lng1, lat2, lng2, 'K'); // kilometrais.
            //distance = distance * 1000;     // metrais

            if (allowMarkerPlacing && distance <= maximumDistance)
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
            else if (allowMarkerPlacing && distance > maximumDistance)
            {
                Toast aToast = Toast.MakeText(this, "Žymeklius galima dėti ne toliau kaip " + maximumDistance + 
                    "km. atstumu nuo jūsų buvimo vietos. Bandėte padėti žymeklį " + Math.Round(distance, 2) + 
                    "km. atstumu.", ToastLength.Long);
                aToast.Show();
                System.Diagnostics.Debug.WriteLine("COORD1: " + lat1 + " " + lng1 + "   |   COORD2 " + lat2 + " " + lng2);
            }
            else
            {
                // map preview option, nereikia nieko rodyti
            }
        }

        private double caculateDistance(double lat1, double lon1, double lat2, double lon2, char unit)
        {
            double theta = lon1 - lon2;
            double dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
            dist = Math.Acos(dist);
            dist = rad2deg(dist);
            dist = dist * 60 * 1.1515;
            if (unit == 'K')
            {
                dist = dist * 1.609344;
            }
            else if (unit == 'N')
            {
                dist = dist * 0.8684;
            }
            return (dist); // - 4081.6154411;
        }

        private double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        private double rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
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


            location = locationManager.GetLastKnownLocation(provider);
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