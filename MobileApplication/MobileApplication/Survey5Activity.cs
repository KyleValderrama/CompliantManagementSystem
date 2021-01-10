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
    [Activity(Label = "Survey5Activity", Theme = "@style/Theme.Design.NoActionBar")]
    public class Survey5Activity : Activity
    {
        private Button btnSrvy6;

        public static string survey5q1;
        public static string survey5q2;

        public RadioGroup radioGroup;
        public RadioButton radioButton;
        public RadioGroup radioGroup2;
        public RadioButton radioButton2;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.survey_page5);
            // Create your application here

            radioGroup = FindViewById<RadioGroup>(Resource.Id.radioGroup1);
            radioGroup2 = FindViewById<RadioGroup>(Resource.Id.radioGroup2);

           
            FindViews();
            HandleEvents();

            radioGroup.CheckedChange += radioGroup_CheckedChange;
            radioGroup2.CheckedChange += radioGroup2_CheckedChange;
        }
        private void radioGroup_CheckedChange(object sender, RadioGroup.CheckedChangeEventArgs e)
        {
            radioButton = FindViewById<RadioButton>(radioGroup.CheckedRadioButtonId);
            survey5q1 = radioButton.Text;
        }
        private void radioGroup2_CheckedChange(object sender, RadioGroup.CheckedChangeEventArgs e)
        {
            radioButton2 = FindViewById<RadioButton>(radioGroup2.CheckedRadioButtonId);
            survey5q2 = radioButton2.Text;
        }

        private void FindViews()
        {
            btnSrvy6 = FindViewById<Button>(Resource.Id.button1);
        }

        private void HandleEvents()
        {
            btnSrvy6.Click += btnSrvy6_Click;
        }

        private void btnSrvy6_Click(object sender, EventArgs e)
        {
            if ((radioGroup.CheckedRadioButtonId != -1) && (radioGroup2.CheckedRadioButtonId != -1))
            {
                var intent = new Intent(this, typeof(Survey6Activity));
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