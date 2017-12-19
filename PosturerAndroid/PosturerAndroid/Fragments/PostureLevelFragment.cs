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
using Microcharts.Droid;
using Microcharts;
using SkiaSharp;

using PosturerAndroid.Models;
using PosturerAndroid.Services;

namespace PosturerAndroid.Fragments
{
    public class PostureLevelFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.PostureLevelFragment, container, false);
            ChartView chartView = view.FindViewById<ChartView>(Resource.Id.chart);
            List<PostureLevel> levels = RestService.GetPostureLevels(MainActivity.GetToken());

            var entries = levels.Select(l =>
                 new Entry(l.Level)
                 {
                     Label = l.Date.ToShortDateString(),
                     ValueLabel = l.Level.ToString(),
                     Color = SKColor.Parse("#007bff")
                 }).ToArray();

            var chart = new LineChart()
            {
                Entries = entries
            };

            chartView.Chart = chart;
            return view;
        }
    }
}