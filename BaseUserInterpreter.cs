using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AgendaApp
{
    class BaseUserInterpreter:IUserInterpreter
    {
        public static Dictionary<string, IUserOrder> AgendaValidCommands = new Dictionary<string,IUserOrder>();
        AgendaController agendaController = AgendaController.getInstance();
        public BaseUserInterpreter()
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
                    string agendaCommand = ReplaceTextOnce(userEntry, commandName, "");
                    AgendaValidCommands[commandName].ExecuteTask(agendaCommand);
                    return;
                }
            }
            ThrowInvalidCommandError(AgendaValidCommands);
        }
       
        private string ReplaceTextOnce(string textToParse,string oldCharSeq,string newCharSeq)
        {
            var regex = new Regex(Regex.Escape(oldCharSeq));
            return regex.Replace(textToParse, newCharSeq, 1);
        }
        private void ThrowInvalidCommandError(Dictionary<string,IUserOrder> agendaValidCommands)
        {
            Console.WriteLine("Error, porfavor inserte un comando valido\nCOMANDOS:");
            foreach (string validCommand in agendaValidCommands.Keys)
            {
                Console.WriteLine(validCommand);
            }
        }
        public void AddUserValidCommand(string commandName, IUserOrder executableCommand)
        {
            AgendaValidCommands.Add(commandName, executableCommand);
        }

    }
}
