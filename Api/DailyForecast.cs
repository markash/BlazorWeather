using System;

namespace Weather.Function
{
    public class DailyForecast
    {
        public DateTime Date { get; set; }

        public WeatherUnitRange Temperature { get; set; }

        public DayOrNight Day { get; set; }

        public DayOrNight Night { get; set; }
    }
}