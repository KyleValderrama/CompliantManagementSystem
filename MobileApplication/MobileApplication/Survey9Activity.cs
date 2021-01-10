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
    [Activity(Label = "Survey9Activity", Theme = "@style/Theme.Design.NoActionBar")]
    public class Survey9Activity : Activity
    {
        private Button btnSrvy10;

        public static string survey9;

        public RadioGroup radioGroup;
        public RadioButton radioButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.survey_page9);
            // Create your application here

            FindViews();
            HandleEvents();

            radioGroup = FindViewById<RadioGroup>(Resource.Id.radioGroup1);
            radioButton = FindViewById<RadioButton>(radioGroup.CheckedRadioButtonId);

            radioGroup.CheckedChange += radioGroup_CheckedChange;

        }
        private void radioGroup_CheckedChange(object sender, RadioGroup.CheckedChangeEventArgs e)
        {
            radioButton = FindViewById<RadioButton>(radioGroup.CheckedRadioButtonId);
            survey9 = radioButton.Text;
        }

        private void FindViews()
        {
            btnSrvy10 = FindViewById<Button>(Resource.Id.button1);
        }

        private void HandleEvents()
        {
            btnSrvy10.Click += btnSrvy10_Click;
        }

        private void btnSrvy10_Click(object sender, EventArgs e)
        {
            if (radioGroup.CheckedRadioButtonId != -1)
            {
                var intent = new Intent(this, typeof(Survey10Activity));
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