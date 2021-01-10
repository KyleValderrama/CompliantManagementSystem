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
using System.Net.Mime;

namespace MobileApplication
{
    [Activity(Label = "FinishActivity", Theme = "@style/Theme.Design.NoActionBar" )]
    public class FinishActivity : Activity
    {
        public Button btnExit;
        public Button btnQuit;

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
            btnQuit = FindViewById<Button>(Resource.Id.btnQuit);
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

            btnQuit.Click += delegate
            {
                if (btnExit.Enabled == true)
                {
                    AlertDialog.Builder dialog = new AlertDialog.Builder(this);
                    AlertDialog alert = dialog.Create();
                    alert.SetTitle("Exit");
                    alert.SetMessage("Are you sure you want to exit without submitting?");
                    alert.SetButton2("No", (c, ev) =>
                    {
                        alert.Hide();
                    });
                    alert.SetButton("Yes", (c, ev) =>
                    {
                        var activity = (Activity)this;
                        activity.FinishAffinity(); 
                    });
                    
                    alert.Show();
                }
                else
                {
                    var activity = (Activity)this;
                    activity.FinishAffinity();
                }
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
                    string url = "https://api.myjson.com/bins/zyntg";
                    var uri = new Uri(url);
                    HttpResponseMessage response;
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var json = JsonConvert.SerializeObject(sub);
                    JArray array = JArray.Parse(Main.prev);
                    JObject obj = JObject.Parse(json);
                    array.Add(new JObject(obj));
                    var merge = JsonConvert.SerializeObject(array);
                    //Main.test = merge;
                    var content = new StringContent(merge, Encoding.UTF8, "application/json");
                    response = await client.PutAsync(uri, content);

                    try
                    {


                        //Email Sending-------------------------------------------->
                        SmtpClient sclient = new SmtpClient("smtp.gmail.com", 587);
                        MailMessage message = new MailMessage();
                        message.From = new MailAddress("CompliantSender@gmail.com"); //Who it's from
                        message.To.Add("CompliantReceiver@gmail.com"); // The E-Mail that recieves the message
                        message.IsBodyHtml = true;
                        message.Subject = "New Compliant Submission";
                        message.Body = "Reciept Nummber: <b>" + sub.id +
                        "</b><br>Time: <b>" + sub.date +
                        "</b><br><br><b>Answers</b><br>-------------------------------<br>Survey 1: <b>" + sub.survey1 +
                        "</b><br>Survey 2: <b>" + sub.survey2 +
                        "</b><br>Survey 3<br>&nbsp; > Question 1: <b>" + sub.survey3[0] +
                        "</b><br>&nbsp; > Question 2: <b>" + sub.survey3[1] +
                        "</b><br>&nbsp; > Question 3: <b>" + sub.survey3[2] +
                        "</b><br>&nbsp; > Question 4: <b>" + sub.survey3[3] +
                        "</b><br>&nbsp; > Question 5: <b>" + sub.survey3[4] +
                        "</b><br>&nbsp; > Question 6: <b>" + sub.survey3[5] +
                        "</b><br>Survey 4: <b>" + sub.survey4 +
                        "</b><br>Survey 5<br>&nbsp; > Question 1: <b>" + sub.survey5[0] +
                        "</b><br>&nbsp; > Question 2: <b>" + sub.survey5[1] +
                        "</b><br>Survey 6: <b>" + sub.survey6 +
                        "</b><br>Survey 7<br>&nbsp; > Question 1: <b>" + sub.survey7[0] +
                        "</b><br>&nbsp; > Question 2: <b>" + sub.survey7[1] +
                        "</b><br>&nbsp; > Question 3: <b>" + sub.survey7[2] +
                        "</b><br>Survey 8: <b>" + string.Join(", ", sub.survey8) +
                        "</b><br>Survey 9: <b>" + sub.survey9 +
                        "</b><br>Survey 10<br>&nbsp; > Question 1: <b>" + Survey10Activity.survey10q1 +
                        "</b><br>&nbsp; > Question 2: <b>" + Survey10Activity.survey10q2 +
                        "</b><br>&nbsp; > Question 3: <b>" + Survey10Activity.survey10q3 +
                        "</b><br>&nbsp; > Question 4: <b>" + Survey10Activity.survey10q4 +
                        "</b><br>&nbsp; > Question 5: <b>" + Survey10Activity.survey10q5 +
                        "</b><br>-------------------------------<br>";
                        sclient.EnableSsl = true;
                        sclient.UseDefaultCredentials = false;
                        sclient.DeliveryMethod = SmtpDeliveryMethod.Network;
                        sclient.Credentials = new NetworkCredential("CompliantSender@gmail.com", "5pOGXzC9TM");
                        sclient.Send(message);

                        AlertDialog.Builder dialog = new AlertDialog.Builder(this);
                        AlertDialog alert = dialog.Create();
                        alert.SetTitle("Success!");
                        alert.SetMessage("Thank you for participating the survey!");
                        alert.SetButton("OK", (c, ev) =>
                        {
                            alert.Hide();
                        });
                        alert.Show();
                    }
                    catch
                    {
                        Toast.MakeText(this, "Error!", ToastLength.Short).Show();
                    }
                    
                    








                    
                }
            };


        }


    }
}