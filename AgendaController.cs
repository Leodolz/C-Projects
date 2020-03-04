using System;
using System.Collections;
using System.Collections.Generic;

namespace AgendaApp
{
    public class AgendaController
    {
        Dictionary<int, AgendaEntry> agenda = new Dictionary<int,AgendaEntry>();
        int ID = 1;
        public void AddEntry(string text, string date="", string time="")
        {
            date = AgendaTools.putDateIfNecessary(date);
            agenda.Add(ID,new AgendaEntry(text, date, time,ID));
            ID++;
            Console.WriteLine("Texto ingresado correctamente");
        }
        public void ShowEntries(string date)
        {
            foreach (AgendaEntry entry in AgendaTools.SortbyDate(date,agenda))
            {
                Console.WriteLine(AgendaTools.BuildEntryMessage(entry));
            }
        }
        public void RemoveEntry(int id)
        {
            if (agenda.Remove(id))
                Console.WriteLine("Entrada eliminada con exito");
            else Console.WriteLine("No existe entrada con dicho ID");
        }
       
    }
}
