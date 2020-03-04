using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaApp
{
    class AdderThreeEntries : IOrder
    {
        AgendaController controller;
        public AdderThreeEntries(AgendaController controller)
        {
            this.controller = controller;
        }
        public void ExecuteTask(string text)
        {
            string[] commands = text.Split(" ");
            if (Validators.isValidDate(commands[0]) && Validators.isValidTime(commands[1]))
                controller.AddEntry(commands[2], commands[0], commands[1]);
            else Console.WriteLine("Formato invalido... Debe considerar un formato de: <Fecha> <Hora> <Texto>");
        }
    }
}
