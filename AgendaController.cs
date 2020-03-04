using System;
using System.Collections;
using System.Collections.Generic;

namespace AgendaApp
{
    public class AgendaController
    {
        private Dictionary<int, AgendaEntry> userAgenda = new Dictionary<int, AgendaEntry>();
        private static int entryID = 1;
        public void AddEntry(string entryText, string entryDate="", string entryTime="")
        {
            entryDate = AgendaTools.PutDateIfNecessary(entryDate);
            userAgenda.Add(entryID,new AgendaEntry(entryText, entryDate, entryTime,entryID));
            entryID++;
            Console.WriteLine("Texto ingresado correctamente");
        }
        public int getID()
        {
            return entryID;
        }
        public void incID()
        {
            entryID++;
        }
        public Dictionary<int, AgendaEntry> getAgenda()
        {
            return userAgenda;
        }
    }
}
