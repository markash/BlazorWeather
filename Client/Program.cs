using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using TG.Blazor.IndexedDB;
using Client.Services;

namespace Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["API_Prefix"] ?? builder.HostEnvironment.BaseAddress) });
            builder.Services.AddMudServices();
            builder.Services.AddScoped<WeatherService>();
            
            builder.Services.AddIndexedDB(dbStore =>
            {
                dbStore.DbName = "MicroWeather";
                dbStore.Version = 1;

                dbStore.Stores.Add(new StoreSchema
                {
                    Name = "Locations",
                    PrimaryKey = new IndexSpec { Name = "id", KeyPath = "id", Auto = true },
                    Indexes = new List<IndexSpec>
                    {
                        new IndexSpec{Name="latitude", KeyPath = "latitude", Auto=false},
                        new IndexSpec{Name="longitude", KeyPath = "longitude", Auto=false},
                        new IndexSpec{Name="muncipality", KeyPath = "muncipality", Auto=false},
                        new IndexSpec{Name="countrySubDivision", KeyPath = "countrySubDivision", Auto=false}
                    }
                });
            });

            await builder.Build().RunAsync();
        }
    }
}
