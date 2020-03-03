using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaApp
{
    class AddPlainText : AddCommand
    {
        Agenda_Ayudante ayudante;
        public AddPlainText(Agenda_Ayudante ayudante)
        {
            this.ayudante = ayudante;
        }
        public void Add(string[] texto)
        {
            ayudante.add(texto[0]);
        }
    }
}
