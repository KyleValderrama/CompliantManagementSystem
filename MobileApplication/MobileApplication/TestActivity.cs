using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json.Linq;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Net;
using Newtonsoft.Json;

namespace MobileApplication
{
    [Activity(Label = "TestActivity")]
    public class TestActivity : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.testing);
            // Create your application here



            FindViewById<TextView>(Resource.Id.textView1).Text = Main.test;

        }


    }
}