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
        public void ExecuteTask(string userEntries)
        {
            string[] controllerCommands = userEntries.Split(" ");
            if (Validators.isValidDate(controllerCommands[0]) && Validators.isValidTime(controllerCommands[1]))
                agendaController.AddEntry(controllerCommands[2], controllerCommands[0], controllerCommands[1]);
            else Console.WriteLine("Formato invalido... Debe considerar un formato de: <Fecha> <Hora> <Texto>");
        }
    }
}
