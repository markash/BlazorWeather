using System;

namespace Weather.Function
{
    public class CurrentConditionsRequest : AbstractRequest<CurrentConditionsResponse>
    {
        public CurrentConditionsRequest(string baseUrl) : base(baseUrl, Service.Weather)
        {

        }

        public override string GetUrl()
        {
            return $"currentConditions/{Format}?api-version=1.0&query={Latitude},{Longitude}&subscription-key={SubscriptionKey}";
        }
    }
}