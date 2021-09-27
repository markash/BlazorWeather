using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Data;

namespace Client
{
    public class WeatherService
    {
        public async Task<CurrentConditions> GetCurrentConditionsAsync(double latitude, double longitude)
        {
            var httpClient = new HttpClient { BaseAddress = new Uri("https://atlas.microsoft.com/weather/") };
            var response = await httpClient.GetFromJsonAsync<CurrentConditionsResponse>("currentConditions/json?api-version=1.0&query=-26.042754499999997,28.217563&subscription-key=");
            return response.Results[0];
        }
    }

    public class CurrentConditionsResponse 
    {
        public CurrentConditions[] Results { get; set; }
    } 
}