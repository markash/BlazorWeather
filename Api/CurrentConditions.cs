using System;

namespace Weather.Function
{
    public class CurrentConditions
    {
        public DateTime DateTime {get; set; }
        public string Phrase { get; set;}
        public int IconCode { get; set;}
        public bool HasPrecipitation { get; set; }
        public bool IsDayTime { get; set; }
        public WeatherUnit Temperature { get; set; }
        public WeatherUnit RealFeelTemperature { get; set; }
        public WeatherUnit RealFeelTemperatureShade { get; set; }
    }
}
