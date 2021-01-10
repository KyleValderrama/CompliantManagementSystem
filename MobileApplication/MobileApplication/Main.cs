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
using System.Net;


namespace MobileApplication
{
    [Activity(Label = "MainActivity" , Theme = "@style/Theme.Design.NoActionBar" )]
    public class Main : Activity
    {

        private Button btnCont;

        public static string test;

        public static string prev;

        protected override void OnCreate(Bundle savedInstanceState)
        {

            prev = new WebClient().DownloadString("https://api.myjson.com/bins/zyntg");

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            // Create your application here

            FindViews();
            HandleEvents();
        }

        private void FindViews()
        {
            btnCont = FindViewById<Button>(Resource.Id.btnContinue);
        }

        private void HandleEvents()
        {
            btnCont.Click += BtnCont_Click;
        }

        private void BtnCont_Click(object sender, EventArgs e)
        {
            
            var intent = new Intent(this, typeof(FillUpActivity));
            StartActivity(intent);
        }
    }

}
