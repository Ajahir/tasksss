using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace tasksss
{
    [Activity(Label = "registerss")]
    public class registerss : Activity
    {
        private Button regsiter;
        private ImageView facebook, google;
        private EditText name, email, user, password;
        private TextView login;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.register);
            UIReferences();
            UIClickEvents();


        }

        private void UIReferences()
        {
            regsiter = FindViewById<Button>(Resource.Id.registerbutton);
            facebook=FindViewById<ImageView>(Resource.Id.facebook);
            google=FindViewById<ImageView>(Resource.Id.google);
            name = FindViewById<EditText>(Resource.Id.nameuser);
            email = FindViewById<EditText>(Resource.Id.emailaddress);
            user = FindViewById<EditText>(Resource.Id.usernames);
            password=FindViewById<EditText>(Resource.Id.password);
            login = FindViewById<TextView>(Resource.Id.newaccount);


        }

        private void UIClickEvents()
        {
            regsiter.Click += Regsiter_Click;
            facebook.Click += Facebook_Click;
            google.Click += Google_Click;
            login.Click += Login_Click;

        }

        private void Login_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
            Finish();
        }

        private void Google_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "google sign in ", ToastLength.Short).Show();
        }

        private void Facebook_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "facebook sign in ", ToastLength.Short).Show();
        }

        private void Regsiter_Click(object sender, EventArgs e)
        {
            bool isEmail = Regex.IsMatch(email.Text, @"^[a-z]([\w]*[\w\.]*(?!\.)@gmail.com)", RegexOptions.IgnoreCase);
            bool isUser = Regex.IsMatch(user.Text, @"^[a-z-A-Z]*$", RegexOptions.IgnoreCase);
            bool isName = Regex.IsMatch(name.Text, @"^[a-z-A-Z]*$", RegexOptions.IgnoreCase);

            if (string.IsNullOrEmpty(name.Text))
            {
                //Toast.MakeText(this, "enter name data", ToastLength.Short).Show();
                name.Error = "enter name data";
            }
            else if (!isName)
            {
                name.Error = "digit isnot allow";
            }


            else if (string.IsNullOrEmpty(email.Text))
            {
                //Toast.MakeText(this, "enter email data", ToastLength.Short).Show();
                email.Error = "enter email data";
            }

            else if (!isEmail)
            {

                email.Error = "Invalid email address";

            }




            else if (string.IsNullOrEmpty(user.Text))
            {
                //Toast.MakeText(this, "enter user data", ToastLength.Short).Show();
                user.Error = "enter user data";
            }
            else if (!isUser)
            {
                user.Error = "digit isnot allow";
            }

            else if (string.IsNullOrEmpty(password.Text))
            {
                // Toast.MakeText(this, "enter password data", ToastLength.Short).Show();
                password.Error = "enter password data";
            }
            else if ((password.Text.Length) < 8)
            {
                //Toast.MakeText(this, "enter password 8 charater ", ToastLength.Short).Show();
                password.Error = "cannot allow <8 character  ";
            }

            else
            {
                StartActivity(typeof(MainActivity));
                Finish();
            }

        }
    }
    }
