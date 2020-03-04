using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaApp
{
    class InterpreterOfAdd : IOrder
    {
        private const int ONE_ENTRY = 1;
        private const int TWO_ENTRIES = 2;
        private const int THREE_ENTRIES = 3;
        AgendaController agendaController;
        public InterpreterOfAdd(AgendaController agendaController)
        {
            this.agendaController = agendaController;
        }
        public void ExecuteTask(string text)
        {
            string userEntry = text;
            IOrder agendaAdd = CheckAddCommand(userEntry.Split(" "), agendaController);
            if (agendaAdd != null)
                agendaAdd.ExecuteTask(userEntry);
        }
        private IOrder CheckAddCommand(string[] userEntry, AgendaController agendaClient)
        {
            switch (userEntry.Length)
            {
                case ONE_ENTRY:
                    return new AdderOneEntry(agendaClient);
                case TWO_ENTRIES:
                    return new AdderTwoEntries(agendaClient);
                case THREE_ENTRIES:
                    return new AdderThreeEntries(agendaClient);
                default:
                    Console.WriteLine("Formato invalido, vuelva a intentar");
                    return null;
            }
        }
    }
}
