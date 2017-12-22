using Android.App;
using Android.OS;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using Android.Widget;
using Android.Views;

using PosturerAndroid.Models;
using PosturerAndroid.Services;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using System.Collections.Generic;

namespace PosturerAndroid
{
    [Activity(Label = "ChatActivity", Theme = "@style/Theme.DesignDemo")]
    public class ChatActivity : AppCompatActivity
    {
        public const int CHAT_ID = 0;
        private List<ChatMessage> messages;
        private CoordinatorLayout cl;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Activity_Detail);

            SupportToolbar toolBar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolBar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            cl = FindViewById<CoordinatorLayout>(Resource.Id.main_content);
            LinearLayout l = (LinearLayout)((NestedScrollView)cl.GetChildAt(1)).GetChildAt(0);

            
            messages = RestService.GetMessages(Intent.GetIntExtra("chat_id", CHAT_ID), MainActivity.GetToken());

            CardView cardView = (CardView)l.GetChildAt(0);
            TextView tt = (TextView)((LinearLayout)cardView.GetChildAt(0)).GetChildAt(0);
            TextView t = (TextView)((LinearLayout)cardView.GetChildAt(0)).GetChildAt(1);
            t.Text = messages[0].Text;
            tt.Text = messages[0].UserName;

            for (int i = 1; i < messages.Count; i++)
            {
                CardView c = (CardView)LayoutInflater.Inflate(Resource.Menu.card_template, null);
                TextView title = (TextView)((LinearLayout)c.GetChildAt(0)).GetChildAt(0);
                TextView text = (TextView)((LinearLayout)c.GetChildAt(0)).GetChildAt(1);
                title.Text = messages[i].UserName;
                text.Text = messages[i].Text;
                c.LayoutParameters = cardView.LayoutParameters;
                l.AddView(c);
            }

            CollapsingToolbarLayout collapsingToolBar = FindViewById<CollapsingToolbarLayout>(Resource.Id.collapsing_toolbar);
            collapsingToolBar.Title = "Chat";

        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish();
                    return true;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}