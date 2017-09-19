using Android.App;
using Android.Widget;
using Android.OS;
using Xamarin.Facebook;
using Xamarin.Facebook.Login.Widget;
using Java.Lang;
using Android.Content;
using Android.Runtime;
using Xamarin.Facebook.Login;
using System;

namespace AvoidATicket
{
    [Activity(Label = "AvoidATicket", MainLauncher = true)]
    public class LoginActivity : Activity, IFacebookCallback
    {
        private ICallbackManager manager;

        private EditText username;
        private EditText password;
        private Button loginButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_login);
           
            LoginButton login = FindViewById<LoginButton>(Resource.Id.login_facebook_button);
            manager = CallbackManagerFactory.Create();
            login.RegisterCallback(manager, this);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            manager.OnActivityResult(requestCode, (int)resultCode, data);
        }

        /*
         * IFacebookCallback interface implementation --->>
         */

        public void OnCancel()
        {
            //throw new System.NotImplementedException();
        }

        public void OnError(FacebookException error)
        {
            //inform the user that something went wrong
            //not necessary just yet, can be ignored, to be properly handled later
        }

        public void OnSuccess(Java.Lang.Object result)
        {
            //launch a new activity and pass the profile in as an argument
            Intent launchIntent = new Intent(this, typeof(MainScreenActivity));
            launchIntent.PutExtra("login_type", "Facebook");
            launchIntent.PutExtra("user_profile", Profile.CurrentProfile);
            StartActivity(launchIntent);
        }

        /*
         * <<---  IFacebookCalback interface implementation
         */
        
    }

}

