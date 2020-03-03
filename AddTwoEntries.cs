using System;


namespace AgendaApp
{
    class AddTwoEntries : AgendaAdd
    {
        AgendaActions commander;
        public AddTwoEntries(AgendaActions commander)
        {
            this.commander = commander;
        }
        public void execute(string[] text)
        {
            validateCommand(text);
        }

        private void validateCommand(string[] dateOrTime)
        {
            if (Validators.isValidTime(dateOrTime[0])) //It's a date
                commander.add(dateOrTime[1], string.Empty, dateOrTime[0]);
            else if (Validators.isValidDate(dateOrTime[0])) //It's time variable
                commander.add(dateOrTime[1], dateOrTime[0]);
            else Console.WriteLine("Comando invalido, intente de nuevo");
        }
        
    }
}
