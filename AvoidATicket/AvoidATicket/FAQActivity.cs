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
    [Activity(Label = "FAQActivity")]
    public class FAQActivity : Activity
    {
        TextView tv;
        Button back;
        Button ask;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_faq);

            tv = FindViewById<TextView>(Resource.Id.textView1faq);
            tv.Text = "Apie programą: \n\n   Trumpai tariant, ši programėlė yra skirta pažymėti tam tikras vietas žemėlapyje. Dėti žymeklius gali kiekvienas aplikacijos turėtojas, tačiau ištrinti - gali tik administratorius \n\n" +
                "Svarbu žinoti: \n\n > Padėtas žymeklis bus matomas žemėlapyje ribotą laiko tarpą \n > Siekiant išvengti nesusipratimų, žymeklis gali būti padedamas tam tikroje vietoje tik tuomet, kai ir vartotojo įrenginys yra netoliese" +
                "\n\n Dažniausiai užduodami klausimai: \n\n . \nk\nk\nk\nk\nk\nk\nk\nk\nk\nk\nk\nk\nk\nk\nk\nk\nk\nk\nk\nk\nThis thing is scrollable!";

            back = FindViewById<Button>(Resource.Id.button1faq);
            back.Click += delegate
            {
                Finish();
            };

            ask = FindViewById<Button>(Resource.Id.button2faq);
            ask.Click += delegate
            {
                Intent intent = new Intent(this, typeof(ASKActivity));
                StartActivity(intent);
            };
        }
    }
}