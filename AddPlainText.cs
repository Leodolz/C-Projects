using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaApp
{
    class AddPlainText : AgendaAdd
    {
        AgendaActions commander;
        public AddPlainText(AgendaActions commander)
        {
            this.commander = commander;
        }
        public void execute(string[] text)
        {
            commander.add(text[0]);
        }
    }
}
