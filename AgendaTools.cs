using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AgendaApp
{
    public static class AgendaTools
    {

        public static ArrayList Sort(string date, Dictionary<int, AgendaEntry> agenda)
        {
            ArrayList filtered = new ArrayList();
            foreach (KeyValuePair<int, AgendaEntry> entrada in agenda)
            {
                if (entrada.Value.date.Equals(date))
                    filtered.Add(entrada.Value);
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
                return DateTime.Today.ToString("dd-MM-yyyy");
            else return date;
        }
    }
}
