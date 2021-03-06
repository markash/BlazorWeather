using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Weather.Function
{
    public static class api
    {
        [FunctionName("CurrentConditions")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string latitude = req.Query["latitude"];
            string longitude = req.Query["longitude"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            latitude = latitude ?? data?.latitude;
            longitude = longitude ?? data?.longitude;

            var currentConditions = await new WeatherService().GetCurrentConditionsAsync(
                Convert.ToDouble(latitude ?? "0"), 
                Convert.ToDouble(longitude ?? "0"),
                log);

            return new OkObjectResult(currentConditions);
        }

        [FunctionName("DailyForecast")]
        public static async Task<IActionResult> DailyForecast(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Get daily forecast from latitude & longitude.");

            string latitude = req.Query["latitude"];
            string longitude = req.Query["longitude"];
            string duration = req.Query["duration"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            latitude = latitude ?? data?.latitude;
            longitude = longitude ?? data?.longitude;
            duration = duration ?? data?.duration;

            var currentConditions = await new WeatherService().GetDailyForecastAsync(
                Convert.ToDouble(latitude ?? "0"), 
                Convert.ToDouble(longitude ?? "0"),
                Convert.ToInt16(duration),    
                log);

            return new OkObjectResult(currentConditions);
        }

        [FunctionName("CurrentMuncipality")]
        public static async Task<IActionResult> CurrentMuncipality(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Get current muncipality from latitude & longitude");

            string latitude = req.Query["latitude"];
            string longitude = req.Query["longitude"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            latitude = latitude ?? data?.latitude;
            longitude = longitude ?? data?.longitude;

            var currentConditions = await new WeatherService().GetMuncipalityAsync(
                Convert.ToDouble(latitude ?? "0"), 
                Convert.ToDouble(longitude ?? "0"),
                log);

            return new OkObjectResult(currentConditions);
        }
    }
}
