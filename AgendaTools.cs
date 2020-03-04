using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace AgendaApp
{
    public static class AgendaTools
    {

        public static ArrayList FilterByDate(string filteringDate, Dictionary<int, AgendaEntry> userAgenda)
        {
            ArrayList filteredEntryList = new ArrayList();
            DateTime sortingDateTime = Validators.GetDateTime(filteringDate.Trim());
            foreach (KeyValuePair<int, AgendaEntry> agendaEntry in userAgenda)
            {
                DateTime entryDateTime = Validators.GetDateTime(agendaEntry.Value.date.Trim());
                if (entryDateTime.Date == sortingDateTime.Date)
                    filteredEntryList.Add(agendaEntry.Value);
            }
            return filteredEntryList;
        }
        public static string BuildEntryShowingMessage(AgendaEntry agendaEntry)
        {
            string showingText = " Texto: " + agendaEntry.text + " ";
            string showingTime = string.Empty;
            if (!agendaEntry.time.Equals(string.Empty))
                showingTime = "Hora: " + agendaEntry.time + " ";
            return "Fecha: " + agendaEntry.date + showingText + showingTime + "ID: " + (agendaEntry.ID);
        }
        public static string GetDateIfNecessary(string entryDate)
        {
            if (entryDate.Trim().Equals(string.Empty))
                return DateTime.Today.Date.ToString(CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);
            else return entryDate;
        }
       

    }
}
