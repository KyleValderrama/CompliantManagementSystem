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
using System.Timers;
using Felipecsl.GifImageViewLibrary;
using System.Net.Http;

namespace MobileApplication
{
    [Activity(Label = "EvalSystemActivity" , Theme = "@style/Theme.Design.NoActionBar", MainLauncher = true)]
    public class EvalSystemActivity : Activity
    {

        private Timer timer;

        GifImageView loading;

        protected async override void OnCreate(Bundle savedInstanceState)
        {
            
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.eval_system);
            // Create your application here

            var textView1 = FindViewById<TextView>(Resource.Id.textView1);
            Typeface tf = Typeface.CreateFromAsset(Assets, "Font/Tungsten.ttf");
            textView1.SetTypeface(tf, TypefaceStyle.Normal);
            textView1.Text = "ONLINE COMPLIANT MANAGEMENT AND EVALUATION SYSTEM  for";


            Android.Net.ConnectivityManager connectivityManager = (Android.Net.ConnectivityManager)GetSystemService(ConnectivityService);
            Android.Net.NetworkInfo activeConnection = connectivityManager.ActiveNetworkInfo;
            bool isOnline = (activeConnection != null) && activeConnection.IsConnected;
            if (isOnline == false)
            {

                AlertDialog.Builder dialog = new AlertDialog.Builder(this);
                AlertDialog alert = dialog.Create();
                alert.SetCancelable(false);
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
                loading = FindViewById<GifImageView>(Resource.Id.gifImageView1);


                var client = new HttpClient();
                var bytes = await client.GetByteArrayAsync("https://image.ibb.co/ggyzR9/Spinner_0_6s_200px.gif");
                loading.SetBytes(bytes);
                loading.StartAnimation();
                startTimer();
                
            }

            // Display image from a file in assets
            /*
            String uri = "assets://apng/apng_geneva_drive.png";
            ApngImageLoader.getInstance().displayImage(uri, imageView);

            imageView.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v)
            {
                ApngDrawable apngDrawable = ApngDrawable.getFromView(v);
                if (apngDrawable == null) return;

                if (apngDrawable.isRunning())
                {
                    apngDrawable.stop(); // Stop animation
                }
                else
                {
                    apngDrawable.setNumPlays(3); // Fix number of repetition
                    apngDrawable.start(); // Start animation
                }
            }
        });*/


        }
        private void startTimer()
        {
            
            base.OnResume();
            timer = new Timer();
            timer.Interval = 3000;
            timer.Start();
            timer.Elapsed += Timer_Elapsed;
            
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            timer.Stop();
            var intent = new Intent(this, typeof(Main));
            StartActivity(intent);
        }


    }
}