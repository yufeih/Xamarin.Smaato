# Xamarin.Smaato

Xamarin binding for Smaato mobile advertising platform, used by http://talktosomeone.net

## Getting Started

Install Xamarin.Smaato from nuget:

### PM> Install-Package Xamarin.Smaato 

Add a BannarView to your app:

```csharp
BannerView banner = new BannerView(BaseContext);
banner.AdSettings.PublisherId = 0;
banner.AdSettings.AdspaceId = 0;
banner.AsyncLoadNewBanner();
banner.ScalingEnabled = false;
banner.LocationUpdateEnabled = true;

adContainer.AddView(banner);
```

## Build

You need to set Xamarin to use JDK 1.7 to build this project