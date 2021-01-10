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

namespace MobileApplication
{
    [Activity(Label = "FillUpActivity" , Theme = "@style/Theme.Design.NoActionBar") ]
    public class FillUpActivity : Activity
    {
        public Button btnStrt;

        public static string rId;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.fill_up);
            // Create your application here

            

            FindViews();
            HandleEvents();
            
        }

        private void FindViews()
        {
            btnStrt = FindViewById<Button>(Resource.Id.btnStart);
        }

        private void HandleEvents()
        {
            btnStrt.Click += BtnStrt_Click;
        }

        private void BtnStrt_Click(object sender, EventArgs e)
        {

            TextView input = FindViewById<TextView>(Resource.Id.txtId);
            if (input.Text != "")
            {
                rId = input.Text;

                var intent = new Intent(this, typeof(Survey1Activity));
                StartActivity(intent);
            }
            else
            {
                AlertDialog.Builder dialog = new AlertDialog.Builder(this);
                AlertDialog alert = dialog.Create();
                alert.SetTitle("Empty field");
                alert.SetMessage("Your Input must be supplied with a valid code.");
                alert.SetButton("OK", (c, ev) =>
                {
                    alert.Hide();
                });
                alert.Show();
            }


        }
        }
}