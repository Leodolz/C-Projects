using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaApp
{
    class InterpreterOfRemove:IOrder
    {
        AgendaController agendaClient;
        public InterpreterOfRemove(AgendaController agendaClient)
        {
            this.agendaClient = agendaClient;
        }

        public void ExecuteTask(string text)
        {
            string idEntry = text;
            int id;
            if (int.TryParse(idEntry, out id))
                agendaClient.RemoveEntry(id);
            else Console.WriteLine("Comando invalido, por favor intente de nuevo");
        }
    }
}
