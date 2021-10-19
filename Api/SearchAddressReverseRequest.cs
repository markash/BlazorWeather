using System;

namespace Weather.Function
{
    public class SearchAddressReverseRequest : AbstractRequest<ReverseSearchResponse>
    {
        public SearchAddressReverseRequest(string baseUrl) : base (baseUrl, Service.Search)
        {

        }

        public EntityType EntityType { get; set; }

        public bool ReturnSpeedLimit { get; set;}

        public override string GetUrl()
        {
            string url = $"address/reverse/{Format}?api-version=1.0&query={Latitude},{Longitude}&subscription-key={SubscriptionKey}&entityType={EntityType}";

                if (ReturnSpeedLimit) 
                {
                    url += $"&returnSpeedLimit={ReturnSpeedLimit}";
                }

                //&language={language}&heading={heading}&radius={radius}&number={number}&returnRoadUse={returnRoadUse}&roadUse={roadUse}&allowFreeformNewline={allowFreeformNewline}&returnMatchType={returnMatchType}&view={view}

                return url;
        }
    }
}