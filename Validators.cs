using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace AgendaApp
{
    public static class Validators
    {
        private static string[] dateFormats = new[] { "MM/dd/yyyy", "dd/MM/yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "MM-dd-yyyy", "dd-MM-yyyy" };
        public static bool isValidDate(string entry)
        {
            DateTime date;
            return DateTime.TryParseExact(entry,dateFormats,CultureInfo.CurrentCulture.DateTimeFormat, DateTimeStyles.None, out date);
        }
        public static bool isValidTime(string entry)
        {
            Regex timeChecker = new Regex(@"^(?i)(0?[1-9]|1[0-9]|2[0-4]):([0-5][0-9])(:[0-5][0-9])?( AM| PM)?$");
            return timeChecker.IsMatch(entry);
        }
    }
}
