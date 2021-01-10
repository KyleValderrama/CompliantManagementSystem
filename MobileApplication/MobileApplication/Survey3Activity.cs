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
    [Activity(Label = "Survey3Activity", Theme = "@style/Theme.Design.NoActionBar")]
    public class Survey3Activity : Activity
    {
        private Button btnSrvy4;

        public static string survey3q1;
        public static string survey3q2;
        public static string survey3q3;
        public static string survey3q4;
        public static string survey3q5;
        public static string survey3q6;

        public RadioGroup radioGroup1;
        public RadioButton radioButton1;
        public RadioGroup radioGroup2;
        public RadioButton radioButton2;
        public RadioGroup radioGroup3;
        public RadioButton radioButton3;
        public RadioGroup radioGroup4;
        public RadioButton radioButton4;
        public RadioGroup radioGroup5;
        public RadioButton radioButton5;
        public RadioGroup radioGroup6;
        public RadioButton radioButton6;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.survey_page3);
            // Create your application here
            

            FindViews();
            HandleEvents();

            radioGroup1 = FindViewById<RadioGroup>(Resource.Id.radioGroup1);
            radioGroup2 = FindViewById<RadioGroup>(Resource.Id.radioGroup2);
            radioGroup3 = FindViewById<RadioGroup>(Resource.Id.radioGroup3);
            radioGroup4 = FindViewById<RadioGroup>(Resource.Id.radioGroup4);
            radioGroup5 = FindViewById<RadioGroup>(Resource.Id.radioGroup5);
            radioGroup6 = FindViewById<RadioGroup>(Resource.Id.radioGroup6);


            radioGroup1.CheckedChange += radioGroup1_CheckedChange;
            radioGroup2.CheckedChange += radioGroup2_CheckedChange;
            radioGroup3.CheckedChange += radioGroup3_CheckedChange;
            radioGroup4.CheckedChange += radioGroup4_CheckedChange;
            radioGroup5.CheckedChange += radioGroup5_CheckedChange;
            radioGroup6.CheckedChange += radioGroup6_CheckedChange;
        }
        private void radioGroup1_CheckedChange(object sender, RadioGroup.CheckedChangeEventArgs e)
        {
            radioButton1 = FindViewById<RadioButton>(radioGroup1.CheckedRadioButtonId);
            survey3q1 = radioButton1.Text;
        }
        private void radioGroup2_CheckedChange(object sender, RadioGroup.CheckedChangeEventArgs e)
        {
            radioButton2 = FindViewById<RadioButton>(radioGroup2.CheckedRadioButtonId);
            survey3q2 = radioButton2.Text;
        }
        private void radioGroup3_CheckedChange(object sender, RadioGroup.CheckedChangeEventArgs e)
        {
            radioButton3 = FindViewById<RadioButton>(radioGroup3.CheckedRadioButtonId);
            survey3q3 = radioButton3.Text;
        }
        private void radioGroup4_CheckedChange(object sender, RadioGroup.CheckedChangeEventArgs e)
        {
            radioButton4 = FindViewById<RadioButton>(radioGroup4.CheckedRadioButtonId);
            survey3q4 = radioButton4.Text;
        }
        private void radioGroup5_CheckedChange(object sender, RadioGroup.CheckedChangeEventArgs e)
        {
            radioButton5 = FindViewById<RadioButton>(radioGroup5.CheckedRadioButtonId);
            survey3q5 = radioButton5.Text;
        }
        private void radioGroup6_CheckedChange(object sender, RadioGroup.CheckedChangeEventArgs e)
        {
            radioButton6 = FindViewById<RadioButton>(radioGroup6.CheckedRadioButtonId);
            survey3q6 = radioButton6.Text;
        }

        private void FindViews()
        {
            btnSrvy4 = FindViewById<Button>(Resource.Id.button1);
        }

        private void HandleEvents()
        {
            btnSrvy4.Click += btnSrvy4_Click;
        }

        private void btnSrvy4_Click(object sender, EventArgs e)
        {
            if ((radioGroup1.CheckedRadioButtonId != -1) &&
                (radioGroup2.CheckedRadioButtonId != -1) &&
                (radioGroup3.CheckedRadioButtonId != -1) &&
                (radioGroup4.CheckedRadioButtonId != -1) &&
                (radioGroup5.CheckedRadioButtonId != -1) &&
                (radioGroup6.CheckedRadioButtonId != -1))
            {
                var intent = new Intent(this, typeof(Survey4Activity));
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