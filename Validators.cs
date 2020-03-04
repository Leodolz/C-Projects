using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace AgendaApp
{
    public static class Validators
    {
        private static string[] localeDateFormats = CultureInfo.CurrentCulture.DateTimeFormat.GetAllDateTimePatterns();
        public static bool isValidDate(string dateEntry)
        {
            DateTime parsedDate;
            return DateTime.TryParseExact(dateEntry, localeDateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate);
        }
        public static bool isValidTime(string timeEntry)
        {
            Regex timeChecker = new Regex(@"^(?i)(0?[1-9]|1[0-9]|2[0-4]):([0-5][0-9])(:[0-5][0-9])?( AM| PM)?$");
            return timeChecker.IsMatch(timeEntry);
        }
        public static DateTime getDateTime(string dateEntry)
        {
            DateTime parsedDate;
            DateTime.TryParseExact(dateEntry, localeDateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate);
            return parsedDate;
        }
    }
}
