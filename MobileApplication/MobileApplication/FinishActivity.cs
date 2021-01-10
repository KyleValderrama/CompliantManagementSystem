using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json.Linq;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using System.Net;
using Plugin.Messaging;
using System.Net.Mail;

namespace MobileApplication
{
    [Activity(Label = "FinishActivity", Theme = "@style/Theme.Design.NoActionBar", MainLauncher =true)]
    public class FinishActivity : Activity
    {
        public Button btnExit;
        private string messageToSend;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.End);
            // Create your application here
            FindViews();
            HandleEvents();


        }

        private void FindViews()
        {
            btnExit = FindViewById<Button>(Resource.Id.btnFinish);
        }

        private void HandleEvents()
        {
            Submit sub = new Submit();
            sub.id = FillUpActivity.rId;
            sub.date = DateTime.Now;
            sub.survey1 = Survey1Activity.survey1;
            sub.survey2 = Survey2Activity.survey2;
            sub.survey3 = new string[]
            {
              Survey3Activity.survey3q1 ,
              Survey3Activity.survey3q2 ,
              Survey3Activity.survey3q3 ,
              Survey3Activity.survey3q4 ,
              Survey3Activity.survey3q5 ,
              Survey3Activity.survey3q6
            };
            sub.survey4 = Survey4Activity.survey4;
            sub.survey5 = new string[]
            {
                Survey5Activity.survey5q1,
                Survey5Activity.survey5q2
            };
            sub.survey6 = Survey6Activity.survey6;
            sub.survey7 = new string[]
            {
                Survey7Activity.survey7q1 ,
                Survey7Activity.survey7q2 ,
                Survey7Activity.survey7q3
            };
            sub.survey8 = Survey8Activity.survey8.ToArray();
            sub.survey9 = Survey9Activity.survey9;
            sub.survey10 = new s10
            {
                gender = Survey10Activity.survey10q1,
                age = Survey10Activity.survey10q2,
                living = Survey10Activity.survey10q3,
                income = Survey10Activity.survey10q4,
                background = Survey10Activity.survey10q5
            };


            btnExit.Click += async delegate
            {
                Android.Net.ConnectivityManager connectivityManager = (Android.Net.ConnectivityManager)GetSystemService(ConnectivityService);
                Android.Net.NetworkInfo activeConnection = connectivityManager.ActiveNetworkInfo;
                bool isOnline = (activeConnection != null) && activeConnection.IsConnected;
                if (isOnline == false)
                {
                    AlertDialog.Builder dialog = new AlertDialog.Builder(this);
                    AlertDialog alert = dialog.Create();
                    alert.SetTitle("No Connection");
                    alert.SetMessage("Please check your internet connection and try again.");
                    alert.SetButton("OK", (c, ev) =>
                    {
                        alert.Hide();
                    });
                    alert.Show();
                }
                else
                {

                    
                    btnExit.Enabled = false;
                    HttpClient client = new HttpClient();
                    string url = "https://jsonblob.com/api/jsonBlob/7367dcc3-c852-11e8-8a99-ad6b1022dc2b";
                    var uri = new Uri(url);

                    HttpResponseMessage response;
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var json = JsonConvert.SerializeObject(sub);

                    JArray array = JArray.Parse(EvalSystemActivity.prev);
                    JObject obj = JObject.Parse(json);
                    array.Add(new JObject(obj));

                    var merge = JsonConvert.SerializeObject(array);


                    Main.test = merge;

                    var content = new StringContent(merge, Encoding.UTF8, "application/json");
                    response = await client.PutAsync(uri, content);

                    /*

                    try
                    {
                        Toast.MakeText(this, "yes!", ToastLength.Short).Show();
                        messageToSend = "shit!";
                        SmtpClient sclient = new SmtpClient("smtp.gmail.com", 456);
                        MailMessage message = new MailMessage();
                        message.From = new MailAddress("raker.jobert@gmail.com"); //Who it's from
                        message.To.Add("valderrama.kyle@gmail.com"); // The E-Mail that recieves the message
                        message.Subject = "Replay from PC";
                        message.Body = messageToSend;
                        sclient.EnableSsl = true;
                        sclient.UseDefaultCredentials = false;
                        sclient.Credentials = new NetworkCredential("Hazhard Waryeah", "Astigako1234");
                        sclient.Send(message);
                    }
                    catch
                    {
                        Toast.MakeText(this, "error!", ToastLength.Short).Show();
                    }
                    */






                    // var activity = (Activity)this;
                    // activity.FinishAffinity();
                }
            };


        }


    }
}