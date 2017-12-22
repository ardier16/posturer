using System.Collections.Generic;
using System.Linq;

using Android.App;
using Android.OS;
using Android.Views;
using Microcharts.Droid;
using Microcharts;
using SkiaSharp;

using PosturerAndroid.Models;
using PosturerAndroid.Services;
using Android.Widget;
using System.Threading.Tasks;

namespace PosturerAndroid.Fragments
{
    public class PostureLevelFragment : Fragment
    {
        private string currentLevel;
        private List<PostureLevel> levels = new List<PostureLevel>();

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.PostureLevelFragment, container, false);

            TextView currentLevelView = view.FindViewById<TextView>(Resource.Id.current_level);

            ChartView chartView = view.FindViewById<ChartView>(Resource.Id.chart);

            Task.Factory.StartNew(() => {
                levels = RestService.GetPostureLevels(MainActivity.GetToken());
                currentLevel = RestService.GetCurrentPostureLevel(MainActivity.GetToken()).Level.ToString();
            }).ContinueWith(task => {
                var entries = levels.Select(l =>
                     new Entry(l.Level)
                     {
                         Color = SKColor.Parse("#007bff")
                     }).ToArray();

                var chart = new LineChart()
                {
                    Entries = entries
                };

                chartView.Chart = chart;
                currentLevelView.Text = currentLevel;

            }, TaskScheduler.FromCurrentSynchronizationContext());

            return view;
        }
    }
}