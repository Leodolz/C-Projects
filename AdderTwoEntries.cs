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
            string time, date;
            time = date = string.Empty;
            string entryText = entryAttributes[1];
            string dateOrTime = entryAttributes[0];

            if (Validators.IsValidTime(dateOrTime))
                time = dateOrTime;
            else if (Validators.IsValidDate(dateOrTime))
                date = dateOrTime;

            if(date.Equals(string.Empty) && time.Equals(string.Empty))
                Console.WriteLine("Comando invalido, intente de nuevo puede usar un formato de: <Fecha> <Texto> o de <Hora> <Texto>");
            else
                agendaController.AddEntry(entryText, date, time);
            
        }
        
    }
}
