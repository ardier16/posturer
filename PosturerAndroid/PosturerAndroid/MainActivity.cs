using System.Collections.Generic;

using Java.Lang;

using Android.App;
using Android.Content;
using Android.Views;
using Android.OS;
using Android.Support.V4.Widget;
using SupportFragment = Android.Support.V4.App.Fragment;
using SupportFragmentManager = Android.Support.V4.App.FragmentManager;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using SupportActionBar = Android.Support.V7.App.ActionBar;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
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
        private Fragment1 fragment1;
        private Fragment2 fragment2;
        private Fragment3 fragment3;
        private TrainingProgramFragment trainingProgramFragment;
        private PostureLevelFragment postureLevelFragment;
        private ChatsFragment chatsFragment;
        private HomeFragment homeFragment;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
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
            fragment1 = new Fragment1();
            fragment2 = new Fragment2();
            fragment3 = new Fragment3();
            trainingProgramFragment = new TrainingProgramFragment();
            postureLevelFragment = new PostureLevelFragment();
            chatsFragment = new ChatsFragment();
            homeFragment = new HomeFragment();

            Android.App.FragmentTransaction ftrans = FragmentManager.BeginTransaction();
            ftrans.Replace(Resource.Id.container, fragment2).Commit();
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

                switch (e.MenuItem.ItemId)
                {
                    case Resource.Id.nav_exercises:
                        SetTitle(Resource.String.exercises_title);
                        ftrans.Replace(Resource.Id.container, fragment1).Commit();
                        break;
                    case Resource.Id.nav_home:
                        SetTitle(Resource.String.home_title);
                        if (GetToken() != "")
                        {
                            ftrans.Replace(Resource.Id.container, homeFragment).Commit();
                        }
                        else
                        {
                            ftrans.Replace(Resource.Id.container, fragment2).Commit();
                        }
                        break;
                    case Resource.Id.nav_signin:
                        SetTitle(Resource.String.signin_title);
                        ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Application.Context);
                        ISharedPreferencesEditor editor = prefs.Edit();
                        editor.PutString("access_token", "");
                        editor.Apply();
                        fragment2 = new Fragment2();
                        ftrans.Replace(Resource.Id.container, fragment2).Commit();
                        break;
                    case Resource.Id.nav_signup:
                        SetTitle(Resource.String.signup_title);
                        fragment3 = new Fragment3();
                        ftrans.Replace(Resource.Id.container, fragment3).Commit();
                        break;
                    case Resource.Id.nav_chats:
                        SetTitle(Resource.String.chats_title);
                        if (GetToken() != "")
                        {
                            ftrans.Replace(Resource.Id.container, chatsFragment).Commit();
                        }
                        else
                        {
                            ftrans.Replace(Resource.Id.container, fragment2).Commit();
                        }
                        break;
                    case Resource.Id.nav_posturelevel:
                        SetTitle(Resource.String.posturelevel_title);
                        if (GetToken() != "")
                        {
                            ftrans.Replace(Resource.Id.container, postureLevelFragment).Commit();
                        }
                        else
                        {
                            ftrans.Replace(Resource.Id.container, fragment2).Commit();
                        }
                        break;
                    case Resource.Id.nav_program:
                        SetTitle(Resource.String.program_title);
                        if (GetToken() != "")
                        {
                            ftrans.Replace(Resource.Id.container, trainingProgramFragment).Commit();
                        }
                        else
                        {
                            ftrans.Replace(Resource.Id.container, fragment2).Commit();
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
            };            
        }

        public static string GetToken()
        {
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Application.Context);
            return prefs.GetString("access_token", "");
        }
    }
}

