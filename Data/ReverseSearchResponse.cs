using System;

namespace Weather.Function
{
    public class ReverseSearchResponse
    {
        public SearchAddressReverseResult[] Addresses { get; set; }
        public SearchAddressReverseSummary Summary { get; set; }
    }
}