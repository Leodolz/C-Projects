using System;
using System.Collections;
using System.Collections.Generic;

namespace AgendaApp
{
    public class AgendaController
    {
        Dictionary<int, AgendaEntry> agenda = new Dictionary<int,AgendaEntry>();
        int entryID = 1;
        public void AddEntry(string entryText, string entryDate="", string entryTime="")
        {
            entryDate = AgendaTools.PutDateIfNecessary(entryDate);
            agenda.Add(entryID,new AgendaEntry(entryText, entryDate, entryTime,entryID));
            entryID++;
            Console.WriteLine("Texto ingresado correctamente");
        }
        public void ShowEntries(string entryDate)
        {
            foreach (AgendaEntry entry in AgendaTools.SortbyDate(entryDate,agenda))
            {
                Console.WriteLine(AgendaTools.BuildEntryShowingMessage(entry));
            }
        }
        public void RemoveEntry(int entryID)
        {
            if (agenda.Remove(entryID))
                Console.WriteLine("Entrada eliminada con exito");
            else Console.WriteLine("No existe entrada con dicho ID");
        }
       
    }
}
