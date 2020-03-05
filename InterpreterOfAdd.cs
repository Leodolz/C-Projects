using System;

namespace AgendaApp
{
    class InterpreterOfAdd : IUserOrder
    {
        private const int ONE_ENTRY = 1;
        private const int TWO_ENTRIES = 2;
        private const int THREE_ENTRIES = 3;
        readonly AgendaController agendaController;
        public InterpreterOfAdd(AgendaController agendaController)
        {
            this.agendaController = agendaController;
        }
        public void ExecuteTask(string userEntry)
        {
            int numberEntryValues = userEntry.Split(" ").Length;
            IUserOrder agendaAddCommand = GetAddCommand(numberEntryValues, agendaController);
            if (agendaAddCommand != null)
                agendaAddCommand.ExecuteTask(userEntry);
            else Console.WriteLine("Formato invalido, vuelva a intentar");
        }
        private IUserOrder GetAddCommand(int numberEntryValues, AgendaController agendaClient)
        {
            switch (numberEntryValues)
            {
                case ONE_ENTRY:
                    return new AdderOneEntry(agendaClient);
                case TWO_ENTRIES:
                    return new AdderTwoEntries(agendaClient);
                case THREE_ENTRIES:
                    return new AdderThreeEntries(agendaClient);
                default:
                    return null;
            }
        }
    }
}
