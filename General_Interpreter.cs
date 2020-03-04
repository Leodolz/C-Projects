using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace AgendaApp
{
    class General_Interpreter
    {
        AgendaController agendaController = new AgendaController();
        private const int ONE_ENTRY = 1;
        private const int TWO_ENTRIES = 2;
        private const int THREE_ENTRIES = 3;
        public void InterpretCommand(string userEntry)
        {
            Dictionary<string, IOrder> agendaCommands =
            new Dictionary<string, IOrder>()
            {
                {"ADD ", new InterpreterOfAdd(agendaController)},
                {"SHOW", new InterpreterOfShow(agendaController)},
                {"REMOVE ", new InterpreterOfRemove(agendaController)},
                {"ESC", new InterpreterOfEscape()}
            };
            foreach(string key in agendaCommands.Keys)
            {
                if (userEntry.StartsWith(key))
                {
                    agendaCommands[key].ExecuteTask(ReplaceOnce(userEntry, key, ""));
                    return;
                }
            }
            throwInvalidCommand(agendaCommands);
        }
       
        private string ReplaceOnce(string texto,string viejoReg,string nuevoReg)
        {
            var regex = new Regex(Regex.Escape(viejoReg));
            return regex.Replace(texto, nuevoReg, 1);
        }
        private void throwInvalidCommand(Dictionary<string,IOrder> agendaCommands)
        {
            Console.WriteLine("Error, porfavor inserte un comando valido\nCOMANDOS:");
            foreach (string comando in agendaCommands.Keys)
            {
                Console.WriteLine(comando);
            }
        }
    }
}
