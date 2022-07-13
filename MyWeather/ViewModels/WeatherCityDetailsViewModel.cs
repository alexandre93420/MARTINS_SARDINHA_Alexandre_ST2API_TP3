namespace MyWeather.ViewModels;

[QueryProperty(nameof(Weather), "Weather")]
public partial class WeatherCityDetailsViewModel : BaseApiViewModel
{
    IMap map;
    public WeatherCityDetailsViewModel(IMap map)
    {
        this.map = map;
    }

    [ObservableProperty]
    Weather weather;

    [RelayCommand]
    async Task OpenMap()
    {
        try
        {
            await map.OpenAsync(Weather.Lat, Weather.Lon, new MapLaunchOptions
            {
                Name = Weather.Name,
                NavigationMode = NavigationMode.None
            });
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to launch maps: {ex.Message}");
            await Shell.Current.DisplayAlert("Error, no Maps app!", ex.Message, "OK");
        }
    }
}
