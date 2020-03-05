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
            string entryText = entryAttributes[1];
            string dateOrTime = entryAttributes[0];
            if (Validators.IsValidTime(dateOrTime))
                agendaController.AddEntry(entryText, string.Empty, dateOrTime);
            else if (Validators.IsValidDate(dateOrTime))
                agendaController.AddEntry(entryText, dateOrTime, string.Empty);
            else
                Console.WriteLine("Formato invalido, por favor intente de nuevo.");
        }

    }
}
