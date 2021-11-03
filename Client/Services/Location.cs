using System;

namespace Client.Services
{
    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Municipality { get; set; }
        public string CountrySubdivision { get; set; }
    }
}