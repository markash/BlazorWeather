using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Weather.Function
{
    public class WeatherService
    {
        private readonly string _baseUrl;
        private readonly string _subscriptionKey;

        //private readonly string _format;

        public WeatherService()
        {
            //this._format = "json";
            this._baseUrl = System.Environment.GetEnvironmentVariable("AZURE_MAPS_BASE_URL");
            this._subscriptionKey = System.Environment.GetEnvironmentVariable("AZURE_MAPS_SUBSCRIPTION_KEY");
        }

        public async Task<CurrentConditions> GetCurrentConditionsAsync(double latitude, double longitude, ILogger log)
        {
            log.LogInformation($"GetCurrentConditionsAsync({latitude},{longitude})");

            var request = new CurrentConditionsRequest(_baseUrl)
            {
                SubscriptionKey = _subscriptionKey,
                Latitude = latitude.ToString(),
                Longitude = longitude.ToString(),
            };

            var currentConditionsResponse = await request.GetResponseAsync(log);
            return currentConditionsResponse.Results[0];
        }

        public async Task<DailyForecastResponse> GetDailyForecastAsync(double latitude, double longitude, Int16 duration, ILogger log)
        {
            log.LogInformation($"GetDailyForecastAsync({latitude},{longitude})");

            var request = new DailyForecastRequest(_baseUrl)
            {
                SubscriptionKey = _subscriptionKey,
                Latitude = latitude.ToString(),
                Longitude = longitude.ToString(),
                Duration = duration
            };

            return await request.GetResponseAsync(log);
        }

        public async Task<SearchAddressReverseResult> GetMuncipalityAsync(double latitude, double longitude, ILogger log)
        {
            log.LogInformation($"GetMuncipality({latitude},{longitude})");
            
            var request = new SearchAddressReverseRequest(_baseUrl)
            {
                SubscriptionKey = _subscriptionKey,
                Latitude = latitude.ToString(),
                Longitude = longitude.ToString(),
                EntityType = EntityType.Municipality
            };

            var reverseSearchResponse = await request.GetResponseAsync(log);
            return reverseSearchResponse.Addresses[0];
        }
    } 
}