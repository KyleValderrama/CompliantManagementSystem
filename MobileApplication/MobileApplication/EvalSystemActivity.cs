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
using Android.Graphics;
using Android.Net;
using System.Net;

namespace MobileApplication
{
    [Activity(Label = "EvalSystemActivity" , Theme = "@style/Theme.Design.NoActionBar")]
    public class EvalSystemActivity : Activity
    {
        public Button btnStart;

        public static string prev;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.eval_system);
            // Create your application here

            var textView1 = FindViewById<TextView>(Resource.Id.textView1);
            Typeface tf = Typeface.CreateFromAsset(Assets, "Font/Tungsten.ttf");
            textView1.SetTypeface(tf, TypefaceStyle.Normal);
            textView1.Text = "ONLINE COMPLIANT MANAGEMENT AND EVALUATION SYSTEM  for";
            FindViews();
            HandleEvents();

            Android.Net.ConnectivityManager connectivityManager = (Android.Net.ConnectivityManager)GetSystemService(ConnectivityService);
            Android.Net.NetworkInfo activeConnection = connectivityManager.ActiveNetworkInfo;
            bool isOnline = (activeConnection != null) && activeConnection.IsConnected;
            if (isOnline == false)
            {
                AlertDialog.Builder dialog = new AlertDialog.Builder(this);
                AlertDialog alert = dialog.Create();
                alert.SetTitle("No Connection");
                alert.SetMessage("Please check your internet connection and try again.");
                alert.SetButton("OK", (c, ev) =>
                {
                    var activity = (Activity)this;
                    activity.FinishAffinity();
                });
                alert.Show();
            }
            else
            {
                prev = new WebClient().DownloadString("https://jsonblob.com/api/jsonBlob/7367dcc3-c852-11e8-8a99-ad6b1022dc2b");
            }



        }



        private void FindViews()
        {
            btnStart = FindViewById<Button>(Resource.Id.button1);
        }

        private void HandleEvents()
        {
            btnStart.Click += btnStart_Click;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(Main));
            StartActivity(intent);
        }
    }
}