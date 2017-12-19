using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using PosturerAndroid.Services;
using System.Net;

namespace PosturerAndroid.Fragments
{
    public class Fragment3 : Fragment

    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.Fragment3, container, false);

            Button btnSignUp = view.FindViewById<Button>(Resource.Id.btnSignUp);
            TextView registerMessage = view.FindViewById<TextView>(Resource.Id.register_message);
            TextInputLayout passwordWrapper = view.FindViewById<TextInputLayout>(Resource.Id.signUpPassword);
            TextInputLayout confirmPasswordWrapper = view.FindViewById<TextInputLayout>(Resource.Id.signUpConfirmPassword);
            TextInputLayout emailWrapper = view.FindViewById<TextInputLayout>(Resource.Id.signUpEmail);

            btnSignUp.Click += (o, e) =>
            {
                string txtPassword = passwordWrapper.EditText.Text;
                string txtConfirmPassword = confirmPasswordWrapper.EditText.Text;
                string txtEmail = emailWrapper.EditText.Text;

                try
                {
                    RestService.SignUp(txtEmail, txtPassword);
                    registerMessage.Text = "You've succesfully signed up!";
                }
                catch (WebException ex)
                {
                    passwordWrapper.Error = "Incorrect data";
                }
            };

            return view;
        }
    }
}