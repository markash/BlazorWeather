using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Weather.Function;

namespace Client.Services
{
    public class WeatherService
    {
        private readonly HttpClient httpClient;

        public WeatherService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<WeatherForecast> GetWeatherForecastAsync(Location location)
        {
            var currentConditions = await httpClient.GetFromJsonAsync<CurrentConditions>($"api/CurrentConditions?latitude={@location.Latitude}&longitude={@location.Longitude}");
            var searchAddressResult = await httpClient.GetFromJsonAsync<SearchAddressReverseResult>($"api/CurrentMuncipality?latitude={@location.Latitude}&longitude={@location.Longitude}");
            var currentAddress = searchAddressResult.Address;

            location.Municipality = currentAddress.Municipality;
            location.CountrySubdivision = currentAddress.CountrySubdivision;

            return new WeatherForecast
            {
                Location = location,
                DateTime = currentConditions.DateTime,
                IconCode = currentConditions.IconCode,
                IsDayTime = currentConditions.IsDayTime,
                Phrase = currentConditions.Phrase,
                HasPrecipitation = currentConditions.HasPrecipitation,
                Temperature = currentConditions.Temperature,
                RealFeelTemperature = currentConditions.RealFeelTemperature,
                RealFeelTemperatureShade = currentConditions.RealFeelTemperatureShade
            };
        }
    }
}