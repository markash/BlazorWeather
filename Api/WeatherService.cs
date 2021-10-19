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

            // var url = _baseUrl + Service.Weather.ToUri() + "/";
            // var httpClient = new HttpClient { BaseAddress = new Uri(url) };
            // var httpResponse = httpClient.GetAsync($"currentConditions/json?api-version=1.0&query={latitude},{longitude}&subscription-key={_subscriptionKey}");

            // if (httpResponse.IsCompletedSuccessfully)
            // {
            //     var response = await httpResponse.Result.Content.ReadFromJsonAsync<CurrentConditionsResponse>();
            //     return response.Results[0];
            // }
            // else
            // {
            //     string msg = await httpResponse.Result.Content.ReadAsStringAsync();
            //     Console.WriteLine(msg);
            //     throw new Exception(msg);
            // } 

            var request = new CurrentConditionsRequest(_baseUrl)
            {
                SubscriptionKey = _subscriptionKey,
                Latitude = latitude.ToString(),
                Longitude = longitude.ToString(),
            };

            var currentConditionsResponse = await request.GetResponseAsync(log);
            return currentConditionsResponse.Results[0];
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

            // var url = _baseUrl + "/";
            // var httpClient = new HttpClient { BaseAddress = new Uri(url) };
            // var response = await httpClient.GetFromJsonAsync<ReverseSearchResponse>(request.ToUri);
            // return response.Addresses[0];
        }
    }

    
    public class CurrentConditionsResponse 
    {
        public CurrentConditions[] Results { get; set; }
    } 
    
    public class Temperature
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; } 
    }

    // public class CurrentConditions
    // {
    //     public DateTime DateTime {get; set; }
    //     public string Phrase { get; set;}
    //     public int IconCode { get; set;}
    //     public bool HasPrecipitation { get; set; }
    //     public bool IsDayTime { get; set; }
    //     public Temperature Temperature { get; set; }
    //     public Temperature RealFeelTemperature { get; set; }
    //     public Temperature RealFeelTemperatureShade { get; set; }
    // }
}