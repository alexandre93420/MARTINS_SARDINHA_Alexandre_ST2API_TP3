namespace MyWeather.Views;

public partial class WeatherCitiesPage : ContentPage
{
	public WeatherCitiesPage(WeatherCitiesViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = viewModel;
    }
}