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
        EditText sender;
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
                sender = FindViewById<EditText>(Resource.Id.editText1);
                question = FindViewById<EditText>(Resource.Id.editText2);

                if(sender.Text == "" || sender.Text == null || question.Text == "" || question.Text == null)
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
                { // http://www.c-sharpcorner.com/article/send-email-using-an-intent-in-xamarin-android-app-using-visual-studio-2015/
                    var email = new Intent(Android.Content.Intent.ActionSend);
                    email.PutExtra(Android.Content.Intent.ExtraEmail, new string[] {
                            "avoidaticketpsi@mail.com"
                        });
                    email.PutExtra(Android.Content.Intent.ExtraCc, new string[] {
                            sender.Text
                        });
                    email.PutExtra(Android.Content.Intent.ExtraSubject, "A Question about AvoidATicket");
                    email.PutExtra(Android.Content.Intent.ExtraText, "Hello AvoidATicket staff, this is my question: " + question.Text);
                    email.SetType("message/rfc822");
                    StartActivity(email);


                    Android.App.AlertDialog.Builder dialog = new AlertDialog.Builder(this);
                    AlertDialog alert = dialog.Create();
                    alert.SetTitle("Success!");
                    alert.SetMessage("Please choose your e-mail app and proceed further.");
                    alert.SetIcon(Resource.Drawable.success);
                    alert.SetButton("Back to F.A.Q menu", (c, ev) =>
                    {   // on continue click task
                        Finish();
                    });
                    alert.Show();
                }
            }; 
        }
    }
}