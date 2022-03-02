using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Text.RegularExpressions;

namespace tasksss
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button login;
        private ImageView facebook, google;
        private TextView user, password, forgot, regsiter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            UIReferences();
            UIClickEvents();
        }

        private void UIClickEvents()
        {
            login.Click += Login_Click;
            facebook.Click += Facebook_Click;
            google.Click += Google_Click;
            forgot.Click += Forgot_Click;
            regsiter.Click += Regsiter_Click;
        }

        private void Regsiter_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(registerss));
            Finish();
        }

        private void Forgot_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "OTP send this number ", ToastLength.Short).Show();
        }

        private void Google_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "google sign in ", ToastLength.Short).Show();
        }

        private void Facebook_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "facebook sign in ", ToastLength.Short).Show();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            bool isUser = Regex.IsMatch(user.Text, @"^[a-z-A-Z]*$", RegexOptions.IgnoreCase);
            if (string.IsNullOrEmpty(user.Text))
            {
                // Toast.MakeText(this, "enter user data", ToastLength.Short).Show();
                user.Error = "enter user data";
            }
            else if (!isUser)
            {
                user.Error = " digit isnot allow";
            }
            else if (string.IsNullOrEmpty(password.Text))
            {
                //Toast.MakeText(this, "enter password data", ToastLength.Short).Show();
                password.Error = "enter password data";
            }
            else if ((password.Text.Length) < 8)
            {
                //Toast.MakeText(this, "enter password 8 charater ", ToastLength.Short).Show();
                password.Error = "cannot allow <8 character";
            }
            else
            {
                Toast.MakeText(this, "login  successfully", ToastLength.Short).Show();
            }
        }

        private void UIReferences()
        {
            login = FindViewById<Button>(Resource.Id.login);
            facebook=FindViewById<ImageView>(Resource.Id.facebook); 
            google=FindViewById<ImageView>(Resource.Id.google);   
            user=FindViewById<EditText>(Resource.Id.username);
            password=FindViewById<EditText>(Resource.Id.password);
            forgot=FindViewById<TextView>(Resource.Id.forgot);
            regsiter = FindViewById<TextView>(Resource.Id.newaccount);




        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}