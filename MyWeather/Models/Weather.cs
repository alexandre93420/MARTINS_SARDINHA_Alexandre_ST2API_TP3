using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MyWeather.Models
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Weather>(myJsonResponse);
    public class Weather
    {
        public string Name { get; set; }

        [JsonPropertyName("lat")]
        public double Lat { get; set; }

        [JsonPropertyName("lon")]
        public double Lon { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }

        [JsonPropertyName("timezone_offset")]
        public int TimezoneOffset { get; set; }

        [JsonPropertyName("current")]
        public WeatherCurrent Current { get; set; }

        [JsonPropertyName("hourly")]
        public List<WeatherHourly> Hourly { get; set; }

        [JsonPropertyName("daily")]
        public List<WeatherDaily> Daily { get; set; }
    }

    public class WeatherCurrent
    {
        [JsonPropertyName("dt")]
        public int Dt { get; set; }
        public DateTime dDt { get; set; }

        [JsonPropertyName("sunrise")]
        public int Sunrise { get; set; }
        public DateTime dSunrise { get; set; }

        [JsonPropertyName("sunset")]
        public int Sunset { get; set; }
        public DateTime dSunset { get; set; }

        [JsonPropertyName("temp")]
        public double Temp { get; set; }

        [JsonPropertyName("feels_like")]
        public double FeelsLike { get; set; }

        [JsonPropertyName("pressure")]
        public int Pressure { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }

        [JsonPropertyName("dew_point")]
        public double DewPoint { get; set; }

        [JsonPropertyName("uvi")]
        public double Uvi { get; set; }

        [JsonPropertyName("clouds")]
        public int Clouds { get; set; }

        [JsonPropertyName("visibility")]
        public int Visibility { get; set; }

        [JsonPropertyName("wind_speed")]
        public double WindSpeed { get; set; }

        [JsonPropertyName("wind_deg")]
        public int WindDeg { get; set; }

        [JsonPropertyName("weather")]
        public List<WeatherSummary> Weather { get; set; }
    }

    public class WeatherHourly
    {
        [JsonPropertyName("dt")]
        public int Dt { get; set; }
        public DateTime dDt { get; set; }

        [JsonPropertyName("temp")]
        public double Temp { get; set; }

        [JsonPropertyName("feels_like")]
        public double FeelsLike { get; set; }

        [JsonPropertyName("pressure")]
        public int Pressure { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }

        [JsonPropertyName("dew_point")]
        public double DewPoint { get; set; }

        [JsonPropertyName("uvi")]
        public double Uvi { get; set; }

        [JsonPropertyName("clouds")]
        public int Clouds { get; set; }

        [JsonPropertyName("visibility")]
        public int Visibility { get; set; }

        [JsonPropertyName("wind_speed")]
        public double WindSpeed { get; set; }

        [JsonPropertyName("wind_deg")]
        public int WindDeg { get; set; }

        [JsonPropertyName("wind_gust")]
        public double WindGust { get; set; }

        [JsonPropertyName("weather")]
        public List<WeatherSummary> Weather { get; set; }

        [JsonPropertyName("pop")]
        public int Pop { get; set; }
    }

    public class WeatherDaily
    {
        [JsonPropertyName("dt")]
        public int Dt { get; set; }
        public DateTime dDt { get; set; }

        [JsonPropertyName("sunrise")]
        public int Sunrise { get; set; }
        public DateTime dSunrise { get; set; }

        [JsonPropertyName("sunset")]
        public int Sunset { get; set; }
        public DateTime dSunset { get; set; }

        [JsonPropertyName("moonrise")]
        public int Moonrise { get; set; }
        public DateTime dMoonrise { get; set; }

        [JsonPropertyName("moonset")]
        public int Moonset { get; set; }
        public DateTime dMoonset { get; set; }

        [JsonPropertyName("moon_phase")]
        public double MoonPhase { get; set; }

        [JsonPropertyName("temp")]
        public WeatherTemp Temp { get; set; }

        [JsonPropertyName("feels_like")]
        public WeatherFeelsLike FeelsLike { get; set; }

        [JsonPropertyName("pressure")]
        public int Pressure { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }

        [JsonPropertyName("dew_point")]
        public double DewPoint { get; set; }

        [JsonPropertyName("wind_speed")]
        public double WindSpeed { get; set; }

        [JsonPropertyName("wind_deg")]
        public int WindDeg { get; set; }

        [JsonPropertyName("wind_gust")]
        public double WindGust { get; set; }

        [JsonPropertyName("weather")]
        public List<WeatherSummary> Weather { get; set; }

        [JsonPropertyName("clouds")]
        public int Clouds { get; set; }

        [JsonPropertyName("pop")]
        public double Pop { get; set; }

        [JsonPropertyName("uvi")]
        public double Uvi { get; set; }
    }

    public class WeatherSummary
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("main")]
        public string Main { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }
    }
    
    public class WeatherTemp
    {
        [JsonPropertyName("day")]
        public double Day { get; set; }

        [JsonPropertyName("min")]
        public double Min { get; set; }

        [JsonPropertyName("max")]
        public double Max { get; set; }

        [JsonPropertyName("night")]
        public double Night { get; set; }

        [JsonPropertyName("eve")]
        public double Eve { get; set; }

        [JsonPropertyName("morn")]
        public double Morn { get; set; }
    }

    public class WeatherFeelsLike
    {
        [JsonPropertyName("day")]
        public double Day { get; set; }

        [JsonPropertyName("night")]
        public double Night { get; set; }

        [JsonPropertyName("eve")]
        public double Eve { get; set; }

        [JsonPropertyName("morn")]
        public double Morn { get; set; }
    }

}