using System;

namespace Data
{
    public class SearchResultAddress 
    {
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string CountryCodeISO3 { get; set; }
        public string CountrySubdivision { get; set; }
        public string CountrySecondarySubdivision { get; set; }
        public string Municipality { get; set; }
        public string FreeformAddress { get; set; }
        public string EntityType { get; set; }
    }
}