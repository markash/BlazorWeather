using System;

namespace Data
{
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
