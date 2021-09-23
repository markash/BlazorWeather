using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

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

    public enum TemperatureUnit
    {
        C,
        F
    }

    public enum UnitType
    {
        Feet=0,
        Inches=1,
        Miles=2,
        Millimeter=3,
        Centimeter=4,
        Meter=5,
        Kilometer=6,
        KilometersPerHour=7,
        Knots=8,
        MilesPerHour=9,
        MetersPerSecond=10,
        HectoPascals=11,
        InchesOfMercury=12,
        KiloPascals=13,
        Millibars=14,
        MillimetersOfMercury=15,
        PoundsPerSquareInch=16,
        Celsius=17,
        Fahrenheit=18,
        Kelvin=19,
        Percent=20,
        Float=21,
        Integer=22,
        MicrogramsPerCubicMeterOfAir=23
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

    public class CurrentConditions
    {
        public DateTime DateTime {get; set; }
        public string Phrase { get; set;}
        public int IconCode { get; set;}
        public bool HasPrecipitation { get; set; }
        public bool IsDayTime { get; set; }
        public Temperature Temperature { get; set; }
        public Temperature RealFeelTemperature { get; set; }
        public Temperature RealFeelTemperatureShade { get; set; }
    }
}