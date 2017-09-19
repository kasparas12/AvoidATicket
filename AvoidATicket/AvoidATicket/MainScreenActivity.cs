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

        // Arguments (Facebook login)
        private Profile facebookProfile;
        private String login_type;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_mainscreen);
            // Create your application here

            arguments = this.Intent.Extras;
            login_type = arguments.GetString("login_type");
            if (login_type.Equals("Facebook"))
            {
                facebookProfile = arguments.GetParcelable("user_profile") as Profile;
                FindViewById<ProfilePictureView>(Resource.Id.profile_picture).ProfileId = facebookProfile.Id;
                FindViewById<TextView>(Resource.Id.user_name).Text = facebookProfile.Name;
            }
        }
    }
}