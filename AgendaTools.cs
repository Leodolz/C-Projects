using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace AgendaApp
{
    public static class AgendaTools
    {

        public static ArrayList Sort(string sortingDate, Dictionary<int, AgendaEntry> agenda)
        {
            ArrayList filtered = new ArrayList();
            DateTime sortingDateTime = Validators.getDateTime(sortingDate.Trim());
            foreach (KeyValuePair<int, AgendaEntry> entry in agenda)
            {
                DateTime entryDateTime = Validators.getDateTime(entry.Value.date.Trim());
                if (entryDateTime.Date == sortingDateTime.Date)
                    filtered.Add(entry.Value);
            }
            return filtered;
        }
        public static string BuildEntryMessage(AgendaEntry entry)
        {
            string text = " Texto: " + entry.text + " ";
            string time = string.Empty;
            if (!entry.time.Equals(string.Empty))
                time = "Hora: " + entry.time + " ";
            return "Fecha: " + entry.date + text + time + "ID: " + (entry.ID);
        }
        public static string putDateIfNecessary(string date)
        {
            if (date.Trim().Equals(string.Empty))
                return DateTime.Today.Date.ToString(CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);
            else return date;
        }
    }
}
