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
    [Activity(Label = "ASKActivity")]
    public class ASKActivity : Activity
    {
        Button back;
        Button send;
        EditText email;
        EditText question;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_ask);


            back = FindViewById<Button>(Resource.Id.ask1);
            back.Click += delegate
            {
                Finish();
            };

            send = FindViewById<Button>(Resource.Id.ask2);
            send.Click += delegate
            {
                email = FindViewById<EditText>(Resource.Id.editText1);
                question = FindViewById<EditText>(Resource.Id.editText2);

                if(email.Text == "" || email.Text == null || question.Text == "" || question.Text == null)
                {
                    Android.App.AlertDialog.Builder dialog = new AlertDialog.Builder(this);
                    AlertDialog alert = dialog.Create();
                    alert.SetTitle("<Error>");
                    alert.SetMessage("The question was not sent, please check the fields once again.");
                    alert.SetIcon(Resource.Drawable.BUS300x300);
                    alert.SetButton("Ok", (c, ev) =>
                    {
                        // Ok button click task  
                    });
                    alert.SetButton2("CANCEL", (c, ev) => { });
                    alert.Show();
                }
                else
                {
                    Android.App.AlertDialog.Builder dialog = new AlertDialog.Builder(this);
                    AlertDialog alert = dialog.Create();
                    alert.SetTitle("Success!");
                    alert.SetMessage("Your message has been successfully sent!");
                    alert.SetIcon(Resource.Drawable.success);
                    alert.SetButton("Back to F.A.Q menu", (c, ev) =>
                    {   // on continue click task
                        // klausimo siuntimo funkcijos panaudojimas cia <---
                        Finish();
                    });
                    alert.Show();
                }
            }; 
        }
    }
}