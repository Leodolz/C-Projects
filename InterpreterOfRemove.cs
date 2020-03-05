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
            if (int.TryParse(idEntry, out int parsedId))
                RemoveEntry(parsedId);
            else Console.WriteLine("Comando invalido, por favor intente de nuevo");
        }
        private void RemoveEntry(int entryID)
        {
            if (agendaController.GetAgenda().Remove(entryID))
                Console.WriteLine("Entrada eliminada con exito");
            else Console.WriteLine("No existe entrada con dicho ID");
        }
    }
}
