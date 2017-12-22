using Android.App;
using Android.Content;
using Android.Views;
using Android.OS;
using Android.Support.V4.Widget;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using SupportActionBar = Android.Support.V7.App.ActionBar;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using Android.Support.V4.App;

using PosturerAndroid.Fragments;
using Android.Widget;
using Android.Preferences;

namespace PosturerAndroid
{
    [Activity(Label = "Posturer", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/Theme.DesignDemo")]
    public class MainActivity : AppCompatActivity
    {
        private DrawerLayout mDrawerLayout;
        private ExercisesFragment exercisesFragment;
        private SignInFragment signInFragment;
        private SignUpFragment signUpFragment;
        private TrainingProgramFragment trainingProgramFragment;
        private PostureLevelFragment postureLevelFragment;
        private ChatsFragment chatsFragment;
        private HomeFragment homeFragment;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            SupportToolbar toolBar = FindViewById<SupportToolbar>(Resource.Id.toolBar);
            SetSupportActionBar(toolBar);

            SupportActionBar ab = SupportActionBar;
            ab.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);
            ab.SetDisplayHomeAsUpEnabled(true);

            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            if (navigationView != null)
            {
                SetUpDrawerContent(navigationView);
            }

            FrameLayout viewPager = FindViewById<FrameLayout>(Resource.Id.container);
            exercisesFragment = new ExercisesFragment();
            signInFragment = new SignInFragment();
            signUpFragment = new SignUpFragment();
            trainingProgramFragment = new TrainingProgramFragment();
            postureLevelFragment = new PostureLevelFragment();
            chatsFragment = new ChatsFragment();
            homeFragment = new HomeFragment();

            Android.App.FragmentTransaction ftrans = FragmentManager.BeginTransaction();
            ftrans.Replace(Resource.Id.container, signInFragment).Commit();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    mDrawerLayout.OpenDrawer((int)GravityFlags.Left);
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);                    
            }
        }

        private void SetUpDrawerContent(NavigationView navigationView)
        {
            navigationView.NavigationItemSelected += (object sender, NavigationView.NavigationItemSelectedEventArgs e) =>
            {
                Android.App.FragmentTransaction ftrans = FragmentManager.BeginTransaction();
                Android.App.Fragment fragment = new Android.App.Fragment();

                switch (e.MenuItem.ItemId)
                {
                    case Resource.Id.nav_exercises:
                        SetTitle(Resource.String.exercises_title);
                        fragment = exercisesFragment;
                        break;
                    case Resource.Id.nav_home:
                        SetTitle(Resource.String.home_title);
                        if (GetToken() != "")
                        {
                            fragment = homeFragment;
                        }
                        else
                        {
                            fragment = signInFragment;
                        }
                        break;
                    case Resource.Id.nav_signin:
                        SetTitle(Resource.String.signin_title);
                        ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Application.Context);
                        ISharedPreferencesEditor editor = prefs.Edit();
                        editor.PutString("access_token", "");
                        editor.Apply();
                        fragment = new SignInFragment();
                        break;
                    case Resource.Id.nav_signup:
                        SetTitle(Resource.String.signup_title);
                        fragment = new SignUpFragment();
                        break;
                    case Resource.Id.nav_chats:
                        SetTitle(Resource.String.chats_title);
                        if (GetToken() != "")
                        {
                            fragment = chatsFragment;
                        }
                        else
                        {
                            fragment = signInFragment;
                        }
                        break;
                    case Resource.Id.nav_posturelevel:
                        SetTitle(Resource.String.posturelevel_title);
                        if (GetToken() != "")
                        {
                            fragment = postureLevelFragment;
                        }
                        else
                        {
                            fragment = signInFragment;
                        }
                        break;
                    case Resource.Id.nav_program:
                        SetTitle(Resource.String.program_title);
                        if (GetToken() != "")
                        {
                            fragment = trainingProgramFragment;
                        }
                        else
                        {
                            fragment = signInFragment;
                        }
                        break;
                }
                

                if (GetToken() != "")
                {
                    navigationView.Menu.GetItem(5).SetTitle("Sign Out");
                }
                else
                {
                    navigationView.Menu.GetItem(5).SetTitle("Sign In");
                }

                e.MenuItem.SetChecked(true);
                mDrawerLayout.CloseDrawers();
                ftrans.Replace(Resource.Id.container, fragment).Commit();
            };            
        }

        public static string GetToken()
        {
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Application.Context);
            return prefs.GetString("access_token", "");
        }
    }
}

