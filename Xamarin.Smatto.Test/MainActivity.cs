using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using com.smaato.soma;
using Com.Smaato.Soma;

namespace Xamarin.Smatto.Test
{
    [Activity(Label = "Xamarin.Smatto.Test", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, IAdListenerInterface
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            var group = FindViewById<ViewGroup>(Resource.Id.ad_container);
            ShowSmaatoAdIn(group);            
        }

        private void ShowSmaatoAdIn(ViewGroup adContainer)
        {
            BannerView banner = new BannerView(BaseContext);            
            banner.AdSettings.PublisherId = 0; // for test ad
            banner.AdSettings.AdspaceId = 0; // for test ad
            banner.AdSettings.AdDimension=AdDimension.Mediumrectangle;
            banner.AsyncLoadNewBanner();
            banner.ScalingEnabled = false;
            banner.LocationUpdateEnabled = true;
            banner.AddAdListener(this);            

            adContainer.AddView(banner);
        }

        public void OnReceiveAd(IAdDownloaderInterface p0, IReceivedBannerInterface p1)
        {
            System.Diagnostics.Debug.WriteLine("ReceiveAd !!!");
        }
    }
}

