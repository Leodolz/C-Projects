using System;

namespace AgendaApp
{
    class InterpreterOfRemove:IUserOrder
    {
        AgendaController agendaController;
        public InterpreterOfRemove(AgendaController agendaController)
        {
            this.agendaController = agendaController;
        }

        public void ExecuteTask(string idEntry)
        {
            int parsedId;
            if (int.TryParse(idEntry, out parsedId))
                agendaController.RemoveEntry(parsedId);
            else Console.WriteLine("Comando invalido, por favor intente de nuevo");
        }
    }
}
