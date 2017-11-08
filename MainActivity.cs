using Android.App;
using Android.Widget;
using Android.OS;
using Android.Locations;
using Android.Runtime;
using Android.Content;
using Android.Util;

namespace App9
{
    [Activity(Label = "App9", MainLauncher = true)]
    public class MainActivity : Activity, ILocationListener
    {
        public void OnLocationChanged(Location location)
        {
            latitude.Text = "Latitude: " + location.Latitude.ToString();
            longitude.Text = "Logitude: " + location.Longitude.ToString();
            provider.Text = "Provider: " + location.Provider.ToString();
            //throw new System.NotImplementedException();
        }

        public void OnProviderDisabled(string provider)
        {
            throw new System.NotImplementedException();
        }

        public void OnProviderEnabled(string provider)
        {
            throw new System.NotImplementedException();
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
            throw new System.NotImplementedException();
        }
        LocationManager locMgr;
        string tag = "MainActivity";
        Button button;
        TextView latitude;
        TextView longitude;
        TextView provider;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            button = FindViewById<Button>(Resource.Id.button1);
            latitude = FindViewById<TextView>(Resource.Id.textView1);
            longitude = FindViewById<TextView>(Resource.Id.textView2);
            provider = FindViewById<TextView>(Resource.Id.textView3);
        }
        protected override void OnStart()
        {
            base.OnStart();
        }
        protected override void OnResume()
        {
            base.OnResume();
            locMgr = GetSystemService(Context.LocationService) as LocationManager;
            button.Click += delegate
            {
                button.Text = "Location Service Running";
                string Provider = LocationManager.GpsProvider;
                if (locMgr.IsProviderEnabled(Provider))
                {
                    locMgr.RequestLocationUpdates(Provider, 2000, 1, this);
                }
                else
                {
                    Log.Info(tag, Provider + " is not available. Does the device have GPS?");
                }
            };
        }
        protected override void OnPause()
        {
            base.OnPause();
            locMgr.RemoveUpdates(this);
        }
        protected override void OnStop()
        {
            base.OnStop();
        }
    }
}

