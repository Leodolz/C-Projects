using System;


namespace AgendaApp
{
    class AdderTwoEntries : IUserOrder
    {
        AgendaController agendaController;
        public AdderTwoEntries(AgendaController agendaController)
        {
            this.agendaController = agendaController;
        }
        public void ExecuteTask(string entryTextCommand)
        {
            ValidateCommand(entryTextCommand.Split(" "));
        }

        private void ValidateCommand(string[] entryAttributes)
        {
            if (Validators.IsValidTime(entryAttributes[0])) //It's time first
                agendaController.AddEntry(entryAttributes[1], string.Empty, entryAttributes[0]);
            else if (Validators.IsValidDate(entryAttributes[0])) //It's date first
                agendaController.AddEntry(entryAttributes[1], entryAttributes[0]);
            else Console.WriteLine("Comando invalido, intente de nuevo puede usar un formato de: <Fecha> <Texto> o de <Hora> <Texto>");
        }
        
    }
}
