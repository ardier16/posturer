using Android.OS;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using PosturerAndroid.Services;
using System.Net;
using SupportFragment = Android.Support.V4.App.Fragment;

namespace PosturerAndroid.Fragments
{
    public class Fragment3 : SupportFragment

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
                    new RestService().SignUp(txtEmail, txtPassword);
                    passwordWrapper.Error = "You've succesfully signed up!";
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