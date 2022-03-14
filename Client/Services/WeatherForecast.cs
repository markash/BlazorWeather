using System;
using System.Collections.Generic;
using Weather.Function;

namespace Client.Services
{
    public class WeatherForecast
    {
        public long? Id { get; set; }
        public Location Location { get; set; }
        public DailyWeatherForecast[] DailyForecasts { get; set; }
        public DateTime DateTime {get; set; }
        public string Phrase { get; set;}
        public int IconCode { get; set;}
        public bool HasPrecipitation { get; set; }
        public bool IsDayTime { get; set; }
        public WeatherUnit Temperature { get; set; }
        public WeatherUnit RealFeelTemperature { get; set; }
        public WeatherUnit RealFeelTemperatureShade { get; set; } 

        public string IconImage
        {
            get => $"images/weather_transparent/{IconCode}.png";
        }

        public string LottieFile
        {
            get => $"images/lottiefiles/{IconCode}.json";
        }

        public string LocationAddress
        {
            get => Location == null ? "Unknown" : $"{Location.Municipality},{Location.CountrySubdivision}";
        }
        public string TemperatureReading
        {
            get => Temperature == null ? $"--{DefaultTemperatureUnit}" : $"{Math.Round(Temperature.Value, 0)}{Temperature.Unit}"; 
        }

        public string UpdatedDateTime
        {
            get => $"Updated as of {DateTime:HH:mm}";
        }
        
        private string DefaultTemperatureUnit
        {
            get => "\u2103";
        }
    }
}