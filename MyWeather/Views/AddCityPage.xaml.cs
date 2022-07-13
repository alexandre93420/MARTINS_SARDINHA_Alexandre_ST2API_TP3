using MyWeather.Data;
using MyWeather.ViewModels;

namespace MyWeather.Views;

[QueryProperty("CityToDisplay", "city")]
public partial class AddCityPage : ContentPage
{
	AddCityViewModel viewModel;
	public AddCityPage()
	{
		InitializeComponent();

		viewModel = new AddCityViewModel();
		BindingContext = viewModel;
    }

	City _cityToDisplay;
    public City CityToDisplay {
		get => _cityToDisplay;
		set
        {
			if (_cityToDisplay == value)
				return;

            _cityToDisplay = value;

			viewModel.CityID = _cityToDisplay.CityID;
			viewModel.CityName = _cityToDisplay.CityName;
			viewModel.CityLon = _cityToDisplay.CityLon;
			viewModel.CityLat = _cityToDisplay.CityLat;
        }
	}
}
