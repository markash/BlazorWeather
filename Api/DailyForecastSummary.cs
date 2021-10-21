using System;

namespace Weather.Function
{
    public class DailyForecastSummary
    {
        ///Date and time that the summary is in effect, displayed in ISO 8601 format, for example, 2019-10-27T19:39:57-08:00.
        public DateTime StartDate { get; set; }

        ///Date and time that the summary period ends, displayed in ISO 8601 format, for example, 2019-10-27T19:39:57-08:00.
        public DateTime EndDate { get; set; }

        ///one or 2 word(s) to summarize the phrase.
        public string Category { get; set; }

        ///Summary phrase of the daily forecast. Displayed in specified language.
        public string Phrase { get; set; }

        ///Severity
        public Int32 Severity { get; set; }
    }
}