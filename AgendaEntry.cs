using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaApp
{
    public class AgendaEntry
    {
        public string text { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public int ID { get; }
        public AgendaEntry(string text,string date, string time, int ID)
        {
            this.text = text;
            this.date = date;
            this.time = time;
            this.ID = ID;
        }
    }
}
