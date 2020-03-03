using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaApp
{
    class AddThreeEntries : AgendaAdd
    {
        AgendaHelper ayudante;
        public AddThreeEntries(AgendaHelper ayudante)
        {
            this.ayudante = ayudante;
        }
        public void execute(string[] texto)
        {
            ayudante.add(texto[2], texto[0], texto[1]);
        }
    }
}
