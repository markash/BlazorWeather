using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using TG.Blazor.IndexedDB;
using Weather.Function;
using Microsoft.Extensions.Logging;

namespace Client.Services
{
    public class WeatherForecastService
    {
        private readonly HttpClient httpClient;
        private readonly IndexedDBManager indexedDbManager;
        // private readonly ILogger logger;

        public WeatherForecastService(IndexedDBManager indexedDbManager, HttpClient httpClient)
        {
            this.httpClient = httpClient;
            this.indexedDbManager = indexedDbManager;
            // this.logger = logger;
        }

        public async Task<List<Location>> GetLocationsAsync()
        {
            return await indexedDbManager.GetRecords<Location>(Stores.STORE_LOCATIONS) ?? new List<Location>();
        }

        public async Task<Location> GetCurrentLocation()
        {
            var locations = await indexedDbManager.GetRecords<Location>(Stores.STORE_CURRENT_LOCATION) ?? new List<Location>();

            return locations.FirstOrDefault();
        }

        public async Task<WeatherForecast> GetWeatherForecastAsync(Location location, ServiceLocation serviceLocation)
        {
            WeatherForecast weatherForecast = null;

            if (serviceLocation == ServiceLocation.LOCAL) 
            {
                weatherForecast = (await GetLocalWeatherForecastByLocationAsync(location))?.FirstOrDefault();
            }

            if (weatherForecast == null)
            {
                weatherForecast = await GetAzureWeatherForecastAsync(location);
            }

            return weatherForecast;
        }

        private async Task<WeatherForecast> GetAzureWeatherForecastAsync(Location location)
        {
            try
            {
                var currentConditions = await RetrieveCurrentConditionsAsync(location);
                var currentAddress = await RetrieveSearchResultAddressAsync(location);
                var dailyForecasts = await RetrieveDailyForecastsAsync(location);

                location.Municipality = currentAddress.Municipality;
                location.CountrySubdivision = currentAddress.CountrySubdivision;

                var weatherForecast = new WeatherForecast
                {
                    Location = location,
                    DailyForecasts = dailyForecasts.ToArray<DailyWeatherForecast>(),
                    DateTime = currentConditions.DateTime,
                    IconCode = currentConditions.IconCode,
                    IsDayTime = currentConditions.IsDayTime,
                    Phrase = currentConditions.Phrase,
                    HasPrecipitation = currentConditions.HasPrecipitation,
                    Temperature = currentConditions.Temperature,
                    RealFeelTemperature = currentConditions.RealFeelTemperature,
                    RealFeelTemperatureShade = currentConditions.RealFeelTemperatureShade
                };

                Console.WriteLine(weatherForecast.DailyForecasts[0]);

                await WriteWeatherForecastAsync(weatherForecast);

                return weatherForecast;
            } 
            catch (Exception)
            {
                Console.WriteLine($"Unable to read weatherforecast for location ({location?.Latitude}, {location?.Longitude})");

                var weatherForecasts = await GetLocalWeatherForecastByLocationAsync(location);

                return weatherForecasts?.FirstOrDefault();
            }
        }

        private async Task<CurrentConditions> RetrieveCurrentConditionsAsync(Location location)
        {
            try
            {
                Console.WriteLine("Fetching current conditions for location");
                return await httpClient.GetFromJsonAsync<CurrentConditions>
                    (
                                $"api/CurrentConditions?latitude={@location.Latitude}&longitude={@location.Longitude}",
                                new CancellationTokenSource(TimeSpan.FromSeconds(10)).Token
                    );
            } 
            catch (OperationCanceledException)
            {
                Console.WriteLine($"RetrieveCurrentConditionsAsync cancelled");
            }

            return null;
        }

        private async Task<SearchResultAddress> RetrieveSearchResultAddressAsync(Location location)
        {
            try
            {
                Console.WriteLine("Fetching address for location");
                var searchAddressResult = 
                    await httpClient.GetFromJsonAsync<SearchAddressReverseResult>
                    (
                        $"api/CurrentMuncipality?latitude={@location.Latitude}&longitude={@location.Longitude}",
                        new CancellationTokenSource(TimeSpan.FromSeconds(10)).Token
                    );

                return searchAddressResult.Address;
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("RetrieveSearchResultAddressAsync cancelled");
            }

            return null;
        }

        private async Task<List<DailyWeatherForecast>> RetrieveDailyForecastsAsync(Location location)
        {
            try
            {
                Console.WriteLine("Fetching daily forecasts for location");
                
                int duration = 6;

                List<DailyWeatherForecast> results = new List<DailyWeatherForecast>();

                var dailyForecastResult = 
                    await httpClient.GetFromJsonAsync<DailyForecastResponse>
                    (
                        $"api/DailyForecast?latitude={@location.Latitude}&longitude={@location.Longitude}&duration=10",
                        new CancellationTokenSource(TimeSpan.FromSeconds(10)).Token
                    );

                var dailyForecasts = dailyForecastResult.Forecasts;

                if (dailyForecasts != null)
                {
                    var forecastCount = 0;

                    foreach (var forecast in dailyForecasts)
                    {
                        var forecastItem = new DailyWeatherForecast
                        {
                            Date = forecast.Date,
                            IconCode = forecast.Day.IconCode
                        };

                        results.Add(forecastItem);

                        forecastCount++;

                        if (forecastCount > duration)
                            break;
                    }

                    //Remove the first forecast because that is for today
                    if (results.Count > 0)
                        results.RemoveAt(0);
                }

                return results;
            }
            catch (Exception)
            {
                Console.WriteLine("RetrieveDailyForecastsAsync cancelled");
            }

            return new List<DailyWeatherForecast>();
        }

        private async Task WriteWeatherForecastAsync(WeatherForecast weatherForecast)
        {

            await indexedDbManager.OpenDb();

            var newRecord = new StoreRecord<WeatherForecast>
            {
                Storename = Stores.STORE_WEATHER_FORECASTS,
                Data = weatherForecast
            };

            await indexedDbManager.ClearStore(Stores.STORE_WEATHER_FORECASTS);
            await indexedDbManager.AddRecord(newRecord);
        }

        private async Task<List<WeatherForecast>> GetLocalWeatherForecastByLocationAsync(Location location)
        {
            var results = await indexedDbManager.GetRecords<WeatherForecast>(Stores.STORE_WEATHER_FORECASTS);

            if (results == null)
            {
                return new List<WeatherForecast>();
            }

            return (
                    from result in results
                    where (result.Location.Latitude == location.Latitude) && (result.Location.Longitude == location.Longitude) 
                    select result
                    ).ToList();
        }
    }
}