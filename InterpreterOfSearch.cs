using System;
using System.Collections;
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
            ArrayList showEntries = AgendaTools.FilterByText(entryText, agendaController.getAgenda());
            foreach (AgendaEntry showingEntry in showEntries)
            {
                Console.WriteLine(AgendaTools.BuildEntryShowingMessage(showingEntry));
            }
        }
    }
}
