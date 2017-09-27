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
using Xamarin.Facebook;
using Xamarin.Facebook.Login.Widget;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Xamarin.Facebook.Login;

namespace AvoidATicket
{
    /// <summary>
    ///     <FacebookLogin>
    ///         <argument name="login_type" type="string" value="Facebook"/>
    ///         <argument name="user_profile" type="Xamarin.Facebook.Profile" nullable="false"/>
    ///     </FacebookLogin>
    /// </summary>
    [Activity(Label = "MainScreenActivity")]
    public class MainScreenActivity : Activity
    {
        private Bundle arguments;

        private String login_type;

        // Arguments (Facebook login)
        private Profile facebookProfile;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_mainscreen);
            // Create your application here

            ProfilePictureView profile_picture = FindViewById<ProfilePictureView>(Resource.Id.profile_image);
            TextView profile_name = FindViewById<TextView>(Resource.Id.profile_name);

            arguments = this.Intent.Extras;
            login_type = arguments.GetString("login_type");
            if (login_type.Equals("Facebook"))
            {
                facebookProfile = arguments.GetParcelable("user_profile") as Profile;
                profile_picture.ProfileId = facebookProfile.Id;
                profile_name.Text = facebookProfile.Name;
            }

                       
            Button open_map = FindViewById<Button>(Resource.Id.map_view);
            open_map.Click += delegate
            {
                Intent intent = new Intent(this, typeof(MapActivity));
                StartActivity(intent);
            };

            Button place_marker = FindViewById<Button>(Resource.Id.map_edit);
            place_marker.Click += delegate
            {
                Intent intent = new Intent(this, typeof(MapActivity));
                intent.PutExtra("allowMarkerPlacing", true);
                StartActivityForResult(intent, 1);
            };

            Button log_off = FindViewById<Button>(Resource.Id.log_off_button);
            log_off.Click += delegate
            {
                if (login_type.Equals("Facebook"))
                {
                    LoginManager.Instance.LogOut();
                    Finish();
                }               
            };
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            
        }
    }
}