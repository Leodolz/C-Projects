using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AgendaApp
{
    class GeneralUserInterpreter
    {
        private static Dictionary<string, IUserOrder> AgendaValidCommands = new Dictionary<string,IUserOrder>();
        AgendaController agendaController = new AgendaController();
        public GeneralUserInterpreter()
        {
            AgendaValidCommands =
                new Dictionary<string, IUserOrder>()
                {
                    {"ADD ", new InterpreterOfAdd(agendaController)},
                    {"SHOW", new InterpreterOfShow(agendaController)},
                    {"REMOVE ", new InterpreterOfRemove(agendaController)},
                    {"ESC", new InterpreterOfEscape()}
                };
        }
        public void ParseUserCommand(string userEntry)
        {
           
            foreach(string commandName in AgendaValidCommands.Keys)
            {
                if (userEntry.StartsWith(commandName))
                {
                    string agendaCommand = ReplaceOnce(userEntry, commandName, "");
                    AgendaValidCommands[commandName].ExecuteTask(agendaCommand);
                    return;
                }
            }
            ThrowInvalidCommand(AgendaValidCommands);
        }
       
        private string ReplaceOnce(string textToParse,string oldCharSeq,string newCharSeq)
        {
            var regex = new Regex(Regex.Escape(oldCharSeq));
            return regex.Replace(textToParse, newCharSeq, 1);
        }
        private void ThrowInvalidCommand(Dictionary<string,IUserOrder> agendaCommands)
        {
            Console.WriteLine("Error, porfavor inserte un comando valido\nCOMANDOS:");
            foreach (string validCommand in agendaCommands.Keys)
            {
                Console.WriteLine(validCommand);
            }
        }
    }
}
