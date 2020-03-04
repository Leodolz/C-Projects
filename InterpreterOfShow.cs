using System;

namespace AgendaApp
{
    class InterpreterOfShow:IUserOrder
    {
        AgendaController agendaController;
        public InterpreterOfShow(AgendaController agendaController)
        {
            this.agendaController = agendaController;
        }

        public void ExecuteTask(string showDate)
        {
            showDate = AgendaTools.PutDateIfNecessary(showDate);
            if (Validators.IsValidDate(showDate.Trim()))
                agendaController.ShowEntries(showDate);
            else Console.WriteLine("Formato Erroneo, por favor intente de nuevo");
        }
    }
}
