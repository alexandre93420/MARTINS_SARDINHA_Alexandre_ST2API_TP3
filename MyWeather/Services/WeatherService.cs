using System.Collections.Generic;
using System.Net.Http.Json;
using MyWeather.Data;
using MyWeather.Models;
//using static Java.Lang.Character;

namespace MyWeather.Services
{

    public class WeatherService
    {
        // TODO : add the key here !!!!
        private static string apiKey = "";

        HttpClient httpClient;
        List<Weather> weatherList = new();

        public WeatherService()
        {
            this.httpClient = new HttpClient();
        }
        public async Task<List<Weather>> GetWeatherForCities(List<CityTbl> cities)
        {
            string units = "metric";
            string exclude = "minutely,hourly,daily,alerts";
            string apiVersion = "2.5";
            string lang = "en";

            DateTime epochStart = new DateTime(1970, 1, 1);
            Weather cityWeather = new Weather();
            List<Weather> result = new List<Weather>();

            if (!(cities?.Count > 0))
            {
                return result;
            }

            foreach (CityTbl city in cities) {

                var response = await httpClient.GetAsync($"https://api.openweathermap.org/data/{apiVersion}/onecall?lat={city.Lat}&lon={city.Lon}&exclude={exclude}&units={units}&lang={lang}&appid={apiKey}");

                if (response.IsSuccessStatusCode)
{
                    cityWeather = await response.Content.ReadFromJsonAsync<Weather>();
                    cityWeather.Name = city.Name;
                    cityWeather.Current.dDt = DateTime.SpecifyKind(epochStart.AddSeconds(cityWeather.Current.Dt), DateTimeKind.Utc);
                    cityWeather.Current.dSunrise = DateTime.SpecifyKind(epochStart.AddSeconds(cityWeather.Current.Sunrise), DateTimeKind.Utc);
                    cityWeather.Current.dSunset = DateTime.SpecifyKind(epochStart.AddSeconds(cityWeather.Current.Sunset), DateTimeKind.Utc);

                    result.Add(cityWeather);
                }
            }

            return result;
        }

        public async Task<Weather> GetWeatherForCity(CityTbl city)
        {
            string units = "metric";
            string exclude = "minutely,alerts";
            string apiVersion = "2.5";
            string lang = "en";

            DateTime epochStart = new DateTime(1970, 1, 1);
            Weather result = new Weather();

            if (city == null)
            {
                return result;
            }

            var response = await httpClient.GetAsync($"https://api.openweathermap.org/data/{apiVersion}/onecall?lat={city.Lat}&lon={city.Lon}&exclude={exclude}&units={units}&lang={lang}&appid={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadFromJsonAsync<Weather>();

                result.Name = city.Name;

                result.Current.dDt = DateTime.SpecifyKind(epochStart.AddSeconds(result.Current.Dt), DateTimeKind.Utc);
                result.Current.dSunrise = DateTime.SpecifyKind(epochStart.AddSeconds(result.Current.Sunrise), DateTimeKind.Utc);
                result.Current.dSunset = DateTime.SpecifyKind(epochStart.AddSeconds(result.Current.Sunset), DateTimeKind.Utc);

                if (result.Hourly.Count != 0)
                    for (int i=0; i < result.Hourly.Count;i++)
                    {
                        result.Hourly[i].dDt = DateTime.SpecifyKind(epochStart.AddSeconds(result.Hourly[i].Dt), DateTimeKind.Utc);
                    }

                if (result.Daily.Count != 0)
                    for (int i = 0; i < result.Daily.Count; i++)
                    {
                        result.Daily[i].dDt = DateTime.SpecifyKind(epochStart.AddSeconds(result.Daily[i].Dt), DateTimeKind.Utc);
                        result.Daily[i].dSunrise = DateTime.SpecifyKind(epochStart.AddSeconds(result.Daily[i].Sunrise), DateTimeKind.Utc);
                        result.Daily[i].dSunset = DateTime.SpecifyKind(epochStart.AddSeconds(result.Daily[i].Sunset), DateTimeKind.Utc);
                        result.Daily[i].dMoonrise = DateTime.SpecifyKind(epochStart.AddSeconds(result.Daily[i].Moonrise), DateTimeKind.Utc);
                        result.Daily[i].dMoonset = DateTime.SpecifyKind(epochStart.AddSeconds(result.Daily[i].Moonset), DateTimeKind.Utc);
                    }

            }

            return result;
        }

    }
}