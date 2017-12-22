using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using PosturerAndroid.Services;
using System.Net;

namespace PosturerAndroid.Fragments
{
    public class SignInFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.SignInFragment, container, false);

            Button btnLogin = view.FindViewById<Button>(Resource.Id.btnLogin);
            TextView loginMessage = view.FindViewById<TextView>(Resource.Id.login_message);
            TextInputLayout passwordWrapper = view.FindViewById<TextInputLayout>(Resource.Id.txtInputLayoutPassword);
            TextInputLayout emailWrapper = view.FindViewById<TextInputLayout>(Resource.Id.txtEmail);

            btnLogin.Click += (o, e) =>
            {
                string txtPassword = passwordWrapper.EditText.Text;
                string txtEmail = emailWrapper.EditText.Text;

                try
                {
                    string token = RestService.SignIn(txtEmail, txtPassword);
                    loginMessage.Text = "You've successfully signed in!";

                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Application.Context);
                    ISharedPreferencesEditor editor = prefs.Edit();
                    editor.PutString("access_token", token);
                    editor.Apply();
                }
                catch (WebException ex)
                {
                    passwordWrapper.Error = "Incorrect username or password";
                }
            };

            return view;
        }
    }
}