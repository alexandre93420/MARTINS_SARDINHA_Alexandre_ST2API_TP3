//using AndroidX.Lifecycle;

namespace MyWeather;

public partial class WeatherCityDetailsPage : ContentPage
{
    public WeatherCityDetailsPage(WeatherCityDetailsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}