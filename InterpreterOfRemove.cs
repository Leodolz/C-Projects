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
                RemoveEntry(parsedId);
            else Console.WriteLine("Comando invalido, por favor intente de nuevo");
        }
        private void RemoveEntry(int entryID)
        {
            if (agendaController.getAgenda().Remove(entryID))
                Console.WriteLine("Entrada eliminada con exito");
            else Console.WriteLine("No existe entrada con dicho ID");
        }
    }
}
