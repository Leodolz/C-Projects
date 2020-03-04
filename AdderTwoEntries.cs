using System;


namespace AgendaApp
{
    class AdderTwoEntries : IOrder
    {
        AgendaController controller;
        public AdderTwoEntries(AgendaController controller)
        {
            this.controller = controller;
        }
        public void ExecuteTask(string text)
        {
            validateCommand(text.Split(" "));
        }

        private void validateCommand(string[] dateOrTime)
        {
            if (Validators.isValidTime(dateOrTime[0])) //It's time first
                controller.AddEntry(dateOrTime[1], string.Empty, dateOrTime[0]);
            else if (Validators.isValidDate(dateOrTime[0])) //It's date first
                controller.AddEntry(dateOrTime[1], dateOrTime[0]);
            else Console.WriteLine("Comando invalido, intente de nuevo puede usar un formato de: <Fecha> <Texto> o de <Hora> <Texto>");
        }
        
    }
}
