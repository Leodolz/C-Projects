using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaApp
{
    class EntradaAgenda
    {
        public string texto { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public int ID { get; }
        public EntradaAgenda(string texto,string fecha, string hora, int ID)
        {
            this.texto = texto;
            this.fecha = fecha;
            this.hora = hora;
            this.ID = ID;
        }
    }
}
