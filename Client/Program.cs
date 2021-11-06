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

            builder.Services.AddLogging();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["API_Prefix"] ?? builder.HostEnvironment.BaseAddress) });
            builder.Services.AddMudServices();
            builder.Services.AddScoped<WeatherForecastService>();
            
            builder.Services.AddIndexedDB(dbStore =>
            {
                dbStore.DbName = "MicroWeather";
                dbStore.Version = 2;

                dbStore.Stores.Add(new StoreSchema
                {
                    Name = Stores.STORE_WEATHER_FORECASTS,
                    PrimaryKey = new IndexSpec { Name = "id", KeyPath = "id", Auto = true },
                    Indexes = new List<IndexSpec>
                    {
                        new IndexSpec{Name="latitude", KeyPath = "location.latitude", Auto=false},
                        new IndexSpec{Name="longitude", KeyPath = "location.longitude", Auto=false},
                        new IndexSpec{Name="muncipality", KeyPath = "location.muncipality", Auto=false},
                        new IndexSpec{Name="countrySubDivision", KeyPath = "location.countrySubDivision", Auto=false},
                        new IndexSpec{Name="dailForecasts", KeyPath = "dailForecasts", Auto=false},
                        new IndexSpec{Name="dateTime", KeyPath = "dateTime", Auto=false},
                        new IndexSpec{Name="phrase", KeyPath = "phrase", Auto=false},
                        new IndexSpec{Name="iconCode", KeyPath = "iconCode", Auto=false},
                        new IndexSpec{Name="hasPrecipitation", KeyPath = "hasPrecipitation", Auto=false},
                        new IndexSpec{Name="isDayTime", KeyPath = "isDayTime", Auto=false},
                        new IndexSpec{Name="temperatureValue", KeyPath = "temperature.value", Auto=false},
                        new IndexSpec{Name="temperatureUnit", KeyPath = "temperature.unit", Auto=false},
                        new IndexSpec{Name="temperatureUnitType", KeyPath = "temperature.unitType", Auto=false},
                        new IndexSpec{Name="realFeelTemperatureValue", KeyPath = "realFeelTemperature.value", Auto=false},
                        new IndexSpec{Name="realFeelTemperatureUnit", KeyPath = "realFeelTemperature.unit", Auto=false},
                        new IndexSpec{Name="realFeelTemperatureUnitType", KeyPath = "realFeelTemperature.unitType", Auto=false}
                    }
                });

                dbStore.Stores.Add(new StoreSchema
                {
                    Name = Stores.STORE_CURRENT_LOCATION,
                    PrimaryKey = new IndexSpec { Name = "id", KeyPath = "id", Auto = true },
                    Indexes = new List<IndexSpec>
                    {
                        new IndexSpec{Name="latitude", KeyPath = "latitude", Auto=false},
                        new IndexSpec{Name="longitude", KeyPath = "longitude", Auto=false},
                        new IndexSpec{Name="muncipality", KeyPath = "muncipality", Auto=false},
                        new IndexSpec{Name="countrySubDivision", KeyPath = "countrySubDivision", Auto=false}
                    }
                });

                dbStore.Stores.Add(new StoreSchema
                {
                    Name = Stores.STORE_LOCATIONS,
                    PrimaryKey = new IndexSpec { Name = "muncipality", KeyPath = "muncipality", Auto = true },
                    Indexes = new List<IndexSpec>
                    {
                        new IndexSpec{Name="latitude", KeyPath = "latitude", Auto=false},
                        new IndexSpec{Name="longitude", KeyPath = "longitude", Auto=false},
                        new IndexSpec{Name="countrySubDivision", KeyPath = "countrySubDivision", Auto=false}
                    }
                });
            });

            await builder.Build().RunAsync();
        }
    }
}
