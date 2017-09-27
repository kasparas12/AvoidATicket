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

namespace AvoidATicket
{
    [Activity(Label = "MapActivity")]
    public class MapActivity : Activity, IOnMapReadyCallback, IOnMapClickListener
    {
        private GoogleMap map;
        private bool allowMarkerPlacing;

        public void OnMapClick(LatLng point)
        {
            if (allowMarkerPlacing)
            {
                MarkerOptions options = new MarkerOptions();
                options.SetPosition(point);
                map.AddMarker(options);
            }
            
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            map = googleMap;
            googleMap.SetOnMapClickListener(this);

            MarkerOptions markerOptions = new MarkerOptions();
            markerOptions.SetPosition(new LatLng(54.674836, 25.273971));
            markerOptions.SetTitle("My Position");
            googleMap.AddMarker(markerOptions);

            googleMap.UiSettings.ZoomControlsEnabled = true;
            googleMap.UiSettings.CompassEnabled = true;
            googleMap.UiSettings.MyLocationButtonEnabled = true;
            //googleMap.MoveCamera(CameraUpdateFactory.ZoomIn());

            CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
            builder.Target(new LatLng(54.674836, 25.273971));
            CameraPosition position = builder.Build();
            CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(position);

            googleMap.MoveCamera(cameraUpdate);
            googleMap.MoveCamera(CameraUpdateFactory.ZoomTo(14));

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