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

namespace AvoidATicket
{
    [Activity(Label = "RegisterActivity")]
    public class RegisterActivity : Activity
    {
        Button back;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_register);

            back = FindViewById<Button>(Resource.Id.registerBack);
            back.Click += delegate
            {
                Finish();
            };
        }
    }
}