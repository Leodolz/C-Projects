using System;
using System.Collections;
using System.Collections.Generic;

namespace AgendaApp
{
    public class AgendaHelper
    {
        Dictionary<int, AgendaEntry> agenda;
        int ID = 1;
        public AgendaHelper()
        {
            agenda = new Dictionary<int, AgendaEntry>();
        }
        public void add(string text, string date="", string time="")
        {
            date = AgendaTools.putDateIfNecessary(date);
            agenda.Add(ID,new AgendaEntry(text, date, time,ID));
            ID++;
            Console.WriteLine("Texto ingresado correctamente");
        }
        public void show(string date)
        {
            foreach (AgendaEntry entry in AgendaTools.Sort(date,agenda))
            {
                Console.WriteLine(AgendaTools.BuildEntryMessage(entry));
            }
        }
        public void remove(int id)
        {
            if (agenda.Remove(id))
                Console.WriteLine("Entrada eliminada con exito");
            else Console.WriteLine("No existe entrada con dicho ID");
        }
       
    }
}
