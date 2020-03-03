using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaApp
{
    class AddThreeEntries : AgendaAdd
    {
        AgendaActions commander;
        public AddThreeEntries(AgendaActions commander)
        {
            this.commander = commander;
        }
        public void execute(string[] text)
        {
            commander.add(text[2], text[0], text[1]);
        }
    }
}
