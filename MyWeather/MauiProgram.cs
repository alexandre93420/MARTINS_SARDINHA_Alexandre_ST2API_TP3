using MyWeather.Views;
using MyWeather.Services;

namespace MyWeather;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        string dbPath = FileAccessHelper.GetLocalFilePath("myweather.db3");

        builder.Services.AddSingleton<MyWeatherRepository>(s => ActivatorUtilities.CreateInstance<MyWeatherRepository>(s, dbPath));

        builder.Services.AddSingleton<WeatherService>();
        builder.Services.AddSingleton<WeatherCitiesViewModel>();
        builder.Services.AddSingleton<WeatherCitiesPage>();
        builder.Services.AddTransient<WeatherCityDetailsViewModel>();
        builder.Services.AddTransient<WeatherCityDetailsPage>();
        
        builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
        builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
        builder.Services.AddSingleton<IMap>(Map.Default);

        return builder.Build();
	}
}
