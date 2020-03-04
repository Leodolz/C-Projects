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
            int id;
            if (int.TryParse(idEntry, out id))
                agendaController.RemoveEntry(id);
            else Console.WriteLine("Comando invalido, por favor intente de nuevo");
        }
    }
}
