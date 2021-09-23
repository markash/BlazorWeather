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

            var currentConditions = await new WeatherService().GetCurrentConditionsAsync(Convert.ToDouble(latitude ?? "0"), Convert.ToDouble(longitude ?? "0"));

            return new OkObjectResult(currentConditions);
        }
    }
}
