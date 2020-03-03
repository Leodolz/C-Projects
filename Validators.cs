using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace AgendaApp
{
    public static class Validators
    {
        private static string[] localeDateFormats = CultureInfo.CurrentCulture.DateTimeFormat.GetAllDateTimePatterns();
        public static bool isValidDate(string entry)
        {
            DateTime date;
            return DateTime.TryParseExact(entry, localeDateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
        }
        public static bool isValidTime(string entry)
        {
            Regex timeChecker = new Regex(@"^(?i)(0?[1-9]|1[0-9]|2[0-4]):([0-5][0-9])(:[0-5][0-9])?( AM| PM)?$");
            return timeChecker.IsMatch(entry);
        }
        public static DateTime getDateTime(string entry)
        {
            DateTime date;
            DateTime.TryParseExact(entry, localeDateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
            return date;
        }
    }
}
