using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaApp
{
    class AdderThreeEntries : IUserOrder
    {
        AgendaController agendaController;
        public AdderThreeEntries(AgendaController agendaController)
        {
            this.agendaController = agendaController;
        }
        public void ExecuteTask(string userEntry)
        {
            string[] controllerCommands = userEntry.Split(" ");
            string entryText = controllerCommands[2]; string entryDate = controllerCommands[0]; string entryTime = controllerCommands[1];
            if (Validators.IsValidDate(entryDate) && Validators.IsValidTime(entryTime))
                agendaController.AddEntry(entryText, entryDate, entryTime);
            else Console.WriteLine("Formato invalido... Debe considerar un formato de: <Fecha> <Hora> <Texto>");
        }
    }
}
