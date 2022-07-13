using MyWeather.Views;

namespace MyWeather;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute("addcity", typeof(AddCityPage));
        Routing.RegisterRoute(nameof(WeatherCityDetailsPage), typeof(WeatherCityDetailsPage));
    }
}
