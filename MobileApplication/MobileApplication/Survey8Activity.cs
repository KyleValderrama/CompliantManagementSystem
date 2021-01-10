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
    [Activity(Label = "Survey8Activity", Theme = "@style/Theme.Design.NoActionBar")]
    public class Survey8Activity : Activity
    {
        private Button btnSrvy9;
        public CheckBox cbx1;
        public CheckBox cbx2;
        public CheckBox cbx3;
        public CheckBox cbx4;
        public CheckBox cbx5;

        public static List<string> survey8 = new List<string>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.survey_page8);
            // Create your application here
            cbx1 = FindViewById<CheckBox>(Resource.Id.checkBox1);
            cbx2 = FindViewById<CheckBox>(Resource.Id.checkBox2);
            cbx3 = FindViewById<CheckBox>(Resource.Id.checkBox3);
            cbx4 = FindViewById<CheckBox>(Resource.Id.checkBox4);
            cbx5 = FindViewById<CheckBox>(Resource.Id.checkBox5);
            cbx5.Click += (o, e) => {
                if (cbx5.Checked)
                {
                    cbx1.Enabled = false;
                    cbx2.Enabled = false;
                    cbx3.Enabled = false;
                    cbx4.Enabled = false;
                    cbx1.Checked = false;
                    cbx2.Checked = false;
                    cbx3.Checked = false;
                    cbx4.Checked = false;

                }
                else
                {
                    cbx1.Enabled = true;
                    cbx2.Enabled = true;
                    cbx3.Enabled = true;
                    cbx4.Enabled = true;
                }
            };



            FindViews();
            HandleEvents();

        }

        private void FindViews()
        {
            
            btnSrvy9 = FindViewById<Button>(Resource.Id.button1);
        }

        private void HandleEvents()
        {
            

            btnSrvy9.Click += btnSrvy9_Click;
        }


        private void btnSrvy9_Click(object sender, EventArgs e)
        {
            if (cbx1.Checked)
                survey8.Add(cbx1.Text);
            if (cbx2.Checked)
                survey8.Add(cbx2.Text);
            if (cbx3.Checked)
                survey8.Add(cbx3.Text);
            if (cbx4.Checked)
                survey8.Add(cbx4.Text);
            if (cbx5.Checked)
                survey8.Add(cbx5.Text);

            var intent = new Intent(this, typeof(Survey9Activity));
            StartActivity(intent);
        }
    }
}