using System;

namespace Weather.Function
{
    public class DailyForecastRequest : AbstractRequest<DailyForecastResponse>
    {
        public DailyForecastRequest(string baseUrl) : base(baseUrl, Service.Weather)
        {

        }

        public Int16 Duration { get; set; }

        public override string GetUrl()
        {
            return $"forecast/daily/{Format}?api-version=1.0&query={Latitude},{Longitude}&subscription-key={SubscriptionKey}&duration={Duration}";
        }
    }
}