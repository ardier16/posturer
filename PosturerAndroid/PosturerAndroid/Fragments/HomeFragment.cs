using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using PosturerAndroid.Models;
using PosturerAndroid.Services;

namespace PosturerAndroid.Fragments
{
    public class HomeFragment : Fragment
    {
        private User user;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View view = inflater.Inflate(Resource.Layout.HomeFragment, container, false);

            TextView emailView = view.FindViewById<TextView>(Resource.Id.user_email);
            TextView usernameView = view.FindViewById<TextView>(Resource.Id.user_name);
            TextView statusView = view.FindViewById<TextView>(Resource.Id.user_status);
            TextView regdateView = view.FindViewById<TextView>(Resource.Id.user_reg_date);

            user = new RestService().GetUserInfo(MainActivity.GetToken());

            emailView.Text = user.Email;
            usernameView.Text = user.UserName;
            statusView.Text = user.Status;
            regdateView.Text = user.RegistrationDate.ToShortDateString();

            return view;
        }
    }
}