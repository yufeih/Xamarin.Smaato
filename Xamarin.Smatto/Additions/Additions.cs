using System;
using System.Collections.Generic;
using Android.Runtime;
using Com.Smaato.Soma.Internal.Requests.Settings;

namespace Com.Smaato.Soma
{
    public partial interface IStandardPublisherMethod : IJavaObject { }

    public partial interface IStandardPublisherMethods : IJavaObject { }

    public partial interface IBannerViewInterface : IJavaObject { }

    public partial interface IAdDownloaderInterface
    {
        AdSettings AdSettings { get; set; }
        bool LocationUpdateEnabled { get; set; }
        UserSettings UserSettings { get; set; }

        void AddAdListener(IAdListenerInterface p0);
        bool RemoveAdListener(IAdListenerInterface p0);
        void AsyncLoadNewBanner();
    }

    partial class BaseView
    {
        public event Action<IAdDownloaderInterface, IReceivedBannerInterface> ReceiveAd
        {
            add { AddAdListener(new AdListener(value)); }
            remove { throw new NotImplementedException(); }
        }

        class AdListener : Java.Lang.Object, IAdListenerInterface
        {
            private readonly Action<IAdDownloaderInterface, IReceivedBannerInterface> _callback;

            public AdListener(Action<IAdDownloaderInterface, IReceivedBannerInterface> value)
            {
                this._callback = value;
            }

            public void OnReceiveAd(IAdDownloaderInterface p0, IReceivedBannerInterface p1)
            {
                _callback(p0, p1);
            }
        }
    }
}
