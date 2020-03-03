using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaApp
{
    class AddPlainText : AgendaAdd
    {
        AgendaHelper ayudante;
        public AddPlainText(AgendaHelper ayudante)
        {
            this.ayudante = ayudante;
        }
        public void execute(string[] texto)
        {
            ayudante.add(texto[0]);
        }
    }
}
