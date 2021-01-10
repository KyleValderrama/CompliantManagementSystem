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

namespace MobileApplication
{
    [Activity(Label = "Survey10Activity" , Theme = "@style/Theme.Design.NoActionBar")]
    public class Survey10Activity : Activity
    {
        public Button btnFinish;

        public static string survey10q1;
        public static string survey10q2;
        public static string survey10q3;
        public static string survey10q4;
        public static string survey10q5;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.survey_page10);
            // Create your application here
            Spinner spinner = FindViewById<Spinner>(Resource.Id.spinner);
            Spinner spinner2 = FindViewById<Spinner>(Resource.Id.spinner2);
            Spinner spinner3 = FindViewById<Spinner>(Resource.Id.spinner3);
            Spinner spinner4 = FindViewById<Spinner>(Resource.Id.spinner4);
            Spinner spinner5 = FindViewById<Spinner>(Resource.Id.spinner5);

            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.gender, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;

            spinner2.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner2_ItemSelected);
            var adapter2 = ArrayAdapter.CreateFromResource(this, Resource.Array.age, Android.Resource.Layout.SimpleSpinnerItem);

            adapter2.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner2.Adapter = adapter2;

            spinner3.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner3_ItemSelected);
            var adapter3 = ArrayAdapter.CreateFromResource(this, Resource.Array.und18, Android.Resource.Layout.SimpleSpinnerItem);

            adapter3.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner3.Adapter = adapter3;

            spinner4.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner4_ItemSelected);
            var adapter4 = ArrayAdapter.CreateFromResource(this, Resource.Array.income, Android.Resource.Layout.SimpleSpinnerItem);

            adapter4.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner4.Adapter = adapter4;

            spinner5.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner5_ItemSelected);
            var adapter5 = ArrayAdapter.CreateFromResource(this, Resource.Array.backg, Android.Resource.Layout.SimpleSpinnerItem);

            adapter5.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner5.Adapter = adapter5;

            FindViews();
            HandleEvents();

            

        }
        private void FindViews()
        {
            btnFinish = FindViewById<Button>(Resource.Id.button1);
        }

        private void HandleEvents()
        {
            btnFinish.Click += btnFinish_Click;
        }

        
        private void spinner3_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            survey10q3 = string.Format("{0}", spinner.GetItemAtPosition(e.Position));
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            survey10q1 = string.Format("{0}", spinner.GetItemAtPosition(e.Position));
        }
        private void spinner2_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            survey10q2 = string.Format("{0}", spinner.GetItemAtPosition(e.Position));
        }
        private void spinner4_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            survey10q4 = string.Format("{0}", spinner.GetItemAtPosition(e.Position));
        }
        private void spinner5_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            survey10q5 = string.Format("{0}", spinner.GetItemAtPosition(e.Position));
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if ((survey10q1 != "-Select One-") &&
                (survey10q2 != "-Select One-") &&
                (survey10q3 != "-Select One-") &&
                (survey10q4 != "-Select One-") &&
                (survey10q5 != "-Select One-"))
            {
                var intent = new Intent(this, typeof(FinishActivity));
                StartActivity(intent);
            }
            else
            {
                AlertDialog.Builder dialog = new AlertDialog.Builder(this);
                AlertDialog alert = dialog.Create();
                alert.SetTitle("Selection Required");
                alert.SetMessage("Your must select one from the options");
                alert.SetButton("OK", (c, ev) =>
                {
                    alert.Hide();
                });
                alert.Show();
            }
        }

    }
}