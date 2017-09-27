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
using Android.Content.PM;
using Java.Security;

namespace AvoidATicket
{
    [Activity(Label = "AvoidATicket", MainLauncher = true, Icon = "@drawable/BUS300x300")]
    public class LoginActivity : Activity, IFacebookCallback
    {
        private ICallbackManager manager;

        private EditText username;
        private EditText password;
        private Button loginButton;

        private enum LoginType
        {
            Facebook,
            Local
        };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            if (AccessToken.CurrentAccessToken != null && Profile.CurrentProfile != null)
                SwitchToMainActivity(LoginType.Facebook);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_login);

            LoginButton login = FindViewById<LoginButton>(Resource.Id.login_facebook_button);
            manager = CallbackManagerFactory.Create();
            login.RegisterCallback(manager, this);


           

            ///Can be used to generate a key hash
            /*
            PackageInfo info = this.PackageManager.GetPackageInfo("com.report.kontrole.AvoidATicket", PackageInfoFlags.Signatures);

            foreach (Android.Content.PM.Signature signature in info.Signatures)
            {
                MessageDigest md = MessageDigest.GetInstance("SHA");
                md.Update(signature.ToByteArray());

                string keyhash = Convert.ToBase64String(md.Digest());
                Console.WriteLine("KeyHash: {0}", keyhash);
            }*/
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
            SwitchToMainActivity(LoginType.Facebook);
        }

        /*
         * <<---  IFacebookCalback interface implementation
         */
        
        private void SwitchToMainActivity(LoginType loginType)
        {
            if (loginType == LoginType.Facebook)
            {
                Intent launchIntent = new Intent(this, typeof(MainScreenActivity));
                launchIntent.PutExtra("login_type", "Facebook");
                launchIntent.PutExtra("user_profile", Profile.CurrentProfile);
                launchIntent.SetFlags(ActivityFlags.SingleTop);
                StartActivity(launchIntent);
            }
            else if (loginType == LoginType.Local)
            {

            }
        }
    }

}

