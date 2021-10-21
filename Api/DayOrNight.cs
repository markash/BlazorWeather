using System;

namespace Weather.Function
{
    public class DayOrNight
    {
        ///Numeric value representing an image that displays the iconPhrase. Please refer to Weather Service Concepts for details.
        public Int32 IconCode { get; set; }

        ///Phrase description of the icon. Displayed in specified language. For example, 'Sunny'.
        public string IconPhrase { get; set; }	

        ///Indicates the presence or absence of precipitation. True indicates the presence of precipitation, false indicates the absence of precipitation.
        public bool HasPrecipitation { get; set; }	

        ///Specifies the type of precipitation ("rain" "snow" "ice" or "mix"). If dbz = zero, precipitationType is not present in the response.
        public string PrecipitationType	{ get; set; }

        ///Description of the intensity.
        public string PrecipitationIntensity { get; set; }

        ///Percent representing the probability of precipitation. For example, '20'.
        public Int32 PrecipitationProbability { get; set; }

        ///Phrase description of the forecast in specified language. Azure Maps attempts to keep this phrase under 30 characters in length, but some languages/weather events may result in a longer phrase length, exceeding 30 characters.
        public string ShortPhrase { get; set; }

        ///Phrase description of the forecast in specified language. Azure Maps attempts to keep this phrase under 100 characters in length, but some languages/weather events may result in a longer phrase length, exceeding 100 characters.
        public string LongPhrase { get; set; }

        ///Percent representing cloud cover.
        public Int32 CloudCover { get; set; }

        ///Percent representing the probability of rain. For example, '40'.        
        public Int32 RainProbability { get; set; }

        ///Rain
        public WeatherUnit Rain { get; set; }

        // hoursOfIce	
        // number
        // Hours of ice.

        // hoursOfPrecipitation	
        // number
        // Hours of precipitation

        // hoursOfRain	
        // number
        // Hours of rain.

        // hoursOfSnow	
        // number
        // Hours of snow.

        // ice	
        // WeatherUnit
        // Ice

        // iceProbability	
        // integer
        // Percent representing the probability of ice. For example, '30'.


        // localSource	
        // LocalSource




        // snow	
        // WeatherUnit
        // Snow

        // snowProbability	
        // integer
        // Percent representing the probability of snow. For example, '30'.

        // thunderstormProbability	
        // integer
        // Percent representing the probability of a thunderstorm. For example, '80'.

        // totalLiquid	
        // WeatherUnit
        // Total liquid equivalent of precipitation during the forecast period.

        // wind	
        // Wind
        // Wind details being returned including speed and direction.

        // windGust	
        // Wind
        // Wind gust. Wind gust is a sudden, brief increase in speed of the wind.
    }
}