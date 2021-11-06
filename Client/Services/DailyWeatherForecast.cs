using System;
using Weather.Function;

namespace Client.Services
{
    public class DailyWeatherForecast
    {
        public DateTime Date { get; set; }

        public Int32 IconCode { get; set; }

        public WeatherUnitRange Temperature { get; set; }

        public string DateText
        {
            get 
            {
                var dateText = this.Date.ToString("MMM dd");
                var dayOfWeek = this.Date.ToString("ddd");

                return (DateTime.Now.AddDays(1).Date.Equals(this.Date.Date)) ? $"Tomorrow, {dateText}" : $"{dayOfWeek}, {dateText}";
            }
        }

        public string IconImage
        {
            get => $"images/weather_transparent/{IconCode}.png";
        }
    }
}