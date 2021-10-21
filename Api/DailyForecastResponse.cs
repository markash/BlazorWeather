using System;

namespace Weather.Function
{
    public class DailyForecastResponse
    {
        public DailyForecastSummary Summary { get; set; }

        public DailyForecast[] Forecasts { get; set; }
    }
}