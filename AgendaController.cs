using System;
using System.Collections.Generic;

namespace AgendaApp
{
    public class AgendaController
    {
        private Dictionary<int, AgendaEntry> userAgenda = new Dictionary<int, AgendaEntry>();
        private static int entryID = 1;
        public void AddEntry(string entryText, string entryDate="", string entryTime="")
        {
            entryDate = AgendaTools.GetDateIfNecessary(entryDate);
            userAgenda.Add(entryID,new AgendaEntry(entryText, entryDate, entryTime,entryID));
            entryID++;
            Console.WriteLine("Texto ingresado correctamente");
        }
        public int GetID()
        {
            return entryID;
        }
        public void IncID()
        {
            entryID++;
        }
        public Dictionary<int, AgendaEntry> GetAgenda()
        {
            return userAgenda;
        }
    }
}
