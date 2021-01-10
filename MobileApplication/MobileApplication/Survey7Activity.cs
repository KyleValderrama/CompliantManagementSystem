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
    [Activity(Label = "Survey7Activity", Theme = "@style/Theme.Design.NoActionBar")]
    public class Survey7Activity : Activity
    {
        private Button btnSrvy8;

        public static string survey7q1;
        public static string survey7q2;
        public static string survey7q3;

        public RadioGroup radioGroup;
        public RadioButton radioButton;
        public RadioGroup radioGroup2;
        public RadioButton radioButton2;
        public RadioGroup radioGroup3;
        public RadioButton radioButton3;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.survey_page7);
            // Create your application here

            FindViews();
            HandleEvents();

            radioGroup = FindViewById<RadioGroup>(Resource.Id.radioGroup1);
            radioGroup2 = FindViewById<RadioGroup>(Resource.Id.radioGroup2);
            radioGroup3 = FindViewById<RadioGroup>(Resource.Id.radioGroup3);

            radioGroup.CheckedChange += radioGroup_CheckedChange;
            radioGroup2.CheckedChange += radioGroup2_CheckedChange;
            radioGroup3.CheckedChange += radioGroup3_CheckedChange;
        }

        private void radioGroup_CheckedChange(object sender, RadioGroup.CheckedChangeEventArgs e)
        {
            radioButton = FindViewById<RadioButton>(radioGroup.CheckedRadioButtonId);
            survey7q1 = radioButton.Text;
        }
        private void radioGroup2_CheckedChange(object sender, RadioGroup.CheckedChangeEventArgs e)
        {
            radioButton2 = FindViewById<RadioButton>(radioGroup2.CheckedRadioButtonId);
            survey7q2 = radioButton2.Text;
        }
        private void radioGroup3_CheckedChange(object sender, RadioGroup.CheckedChangeEventArgs e)
        {
            radioButton3 = FindViewById<RadioButton>(radioGroup3.CheckedRadioButtonId);
            survey7q3 = radioButton3.Text;
        }

        private void FindViews()
        {
            btnSrvy8 = FindViewById<Button>(Resource.Id.button1);
        }

        private void HandleEvents()
        {
            btnSrvy8.Click += btnSrvy8_Click;
        }

        private void btnSrvy8_Click(object sender, EventArgs e)
        {
            if ((radioGroup.CheckedRadioButtonId != -1) && (radioGroup2.CheckedRadioButtonId != -1) && (radioGroup3.CheckedRadioButtonId != -1))
            {
                var intent = new Intent(this, typeof(Survey8Activity));
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