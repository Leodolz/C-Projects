using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaApp
{
    class InterpreterOfSearch : IUserOrder
    {
        AgendaController agendaController;
        public InterpreterOfSearch(AgendaController agendaController)
        {
            this.agendaController = agendaController;
        }
        public void ExecuteTask(string entryText)
        {
            agendaController.SearchEntry(entryText);
        }
    }
}
