using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaApp
{
    class AdderOneEntry : IUserOrder
    {
        AgendaController agendaController;
        public AdderOneEntry(AgendaController agendaController)
        {
            this.agendaController = agendaController;
        }
        public void ExecuteTask(string entryText)
        {
            agendaController.AddEntry(entryText);
        }
    }
}
