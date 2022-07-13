using MyWeather.Data;
using MyWeather.Services;

namespace MyWeather.ViewModels;

public partial class WeatherCitiesViewModel : BaseApiViewModel
{
    public ObservableCollection<Weather> WeatherCities { get; } = new();

    WeatherService weatherService;
    IConnectivity connectivity;
    IGeolocation geolocation;

    [ObservableProperty]
    bool isRefreshing;
    public WeatherCitiesViewModel(WeatherService weatherService, IConnectivity connectivity, IGeolocation geolocation)
    {
        Title = "Weather Cities";
        this.weatherService = weatherService;
        this.connectivity = connectivity;
        this.geolocation = geolocation;
    }

    [RelayCommand]
    async Task GetWeatherCitiesAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;

            if (connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("No connectivity!",
                    $"Please check internet and try again.", "OK");
                return;
            }

            var cities = await App.MyWeatherRepo.GetAllCity();
            var weatherCities = await weatherService.GetWeatherForCities(cities);

            if (WeatherCities.Count != 0)
                WeatherCities.Clear();

            foreach (var weatherCity in weatherCities)
                WeatherCities.Add(weatherCity);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get cities: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
            IsRefreshing = false;
        }
    }

    [RelayCommand]
    async Task GoToWeatherCityDetails(Weather weather)
    {
        if (weather == null)
            return;

        await Shell.Current.GoToAsync(nameof(WeatherCityDetailsPage), true, new Dictionary<string, object>
        {
            {"Weather", weather }
        });
    }

}
