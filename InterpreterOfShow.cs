using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaApp
{
    class InterpreterOfShow:IOrder
    {
        AgendaController agendaController;
        public InterpreterOfShow(AgendaController agendaController)
        {
            this.agendaController = agendaController;
        }

        public void ExecuteTask(string text)
        {
            string date = text;
            date = AgendaTools.putDateIfNecessary(date);
            if (Validators.isValidDate(date.Trim()))
                agendaController.ShowEntries(date);
            else Console.WriteLine("Formato Erroneo, por favor intente de nuevo");
        }
    }
}
