using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaApp
{
    class AddThreeEntries : AddCommand
    {
        Agenda_Ayudante ayudante;
        public AddThreeEntries(Agenda_Ayudante ayudante)
        {
            this.ayudante = ayudante;
        }
        public void Add(string[] texto)
        {
            ayudante.add(texto[2], texto[0], texto[1]);
        }
    }
}
