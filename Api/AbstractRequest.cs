using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Weather.Function
{
    public abstract class AbstractRequest<T>
    {
        private readonly string _baseUrl;
        private readonly Service _service;
        
        public AbstractRequest(string baseUrl, Service service)
        {
            this._baseUrl = baseUrl;
            this._service = service;
            Format = "json";
        }

        public string BaseUrl { get => _baseUrl; } 
        public Service Service { get => _service; }
        public string SubscriptionKey { get; set; }
        public string Format { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        abstract public string GetUrl();

        public async Task<T> GetResponseAsync(ILogger log)
        {
            var url = _baseUrl + _service.ToUri() + "/";
            var httpClient = new HttpClient { BaseAddress = new Uri(url) };
            var requestUrl = GetUrl();

            Console.WriteLine();
            log.LogInformation($"Remote call {url}{requestUrl}");

            var httpResponse = await httpClient.GetAsync(requestUrl);
            if (httpResponse.IsSuccessStatusCode)
            {
                return await httpResponse.Content.ReadFromJsonAsync<T>();
            }
            else
            {
                string msg = await httpResponse.Content.ReadAsStringAsync();
                Console.WriteLine(msg);
                log.LogError($"Remote call error {msg}");

                throw new Exception(msg);
            }
        }
    }
}