using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using PosturerAndroid.Models;
using PosturerAndroid.Services;
using System.Threading.Tasks;

namespace PosturerAndroid.Fragments
{
    public class HomeFragment : Fragment
    {
        private User user;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.HomeFragment, container, false);

            TextView emailView = view.FindViewById<TextView>(Resource.Id.user_email);
            TextView usernameView = view.FindViewById<TextView>(Resource.Id.user_name);
            TextView statusView = view.FindViewById<TextView>(Resource.Id.user_status);
            TextView regdateView = view.FindViewById<TextView>(Resource.Id.user_reg_date);

            Task.Factory.StartNew(() => {
                user = RestService.GetUserInfo(MainActivity.GetToken());
            }).ContinueWith(task => {
                emailView.Text = user.Email;
                usernameView.Text = user.UserName;
                statusView.Text = user.Status;
                regdateView.Text = user.RegistrationDate.ToShortDateString();
            }, TaskScheduler.FromCurrentSynchronizationContext());

            return view;
        }
    }
}