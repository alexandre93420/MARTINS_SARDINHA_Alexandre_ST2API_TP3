using System.Net.Http.Json;
using MyWeather.Models;

namespace MyWeather.Services
{

    public class GeoLocService
    {
        private static string apiKey = "112506466b280c4e28f8f0173921a581";

        HttpClient httpClient;
        List<GeoLocation> geolocationList = new();

        public GeoLocService()
        {
            this.httpClient = new HttpClient();
        }
        public async Task<List<GeoLocation>> GetGeoLocations(string cityname)
        {
            int limit = 10;

            var response = await httpClient.GetAsync($"http://api.openweathermap.org/geo/1.0/direct?q={cityname}&limit={limit}&appid={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                geolocationList = await response.Content.ReadFromJsonAsync<List<GeoLocation>>();
            }         

            return geolocationList;
        }

    }
}