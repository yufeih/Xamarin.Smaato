using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Com.Smaato.Soma;

namespace Xamarin.Smatto.Test
{
    [Activity(Label = "Xamarin.Smatto.Test", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            var group = FindViewById<ViewGroup>(Resource.Id.ad_container);

            ShowSmaatoAdIn(group);

            button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
        }

        private void ShowSmaatoAdIn(ViewGroup adContainer)
        {
            BannerView banner = new BannerView(BaseContext);
            banner.AdSettings.PublisherId = 0;
            banner.AdSettings.AdspaceId = 0;
            banner.AsyncLoadNewBanner();
            banner.ScalingEnabled = false;
            banner.LocationUpdateEnabled = true;

            adContainer.AddView(banner);
        }
    }
}

