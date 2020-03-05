using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AgendaApp
{
    class BaseUserInterpreter:IUserInterpreter
    {
        public static Dictionary<string, IUserOrder> AgendaValidCommands = new Dictionary<string,IUserOrder>();
        AgendaController agendaController = new AgendaController();
        public BaseUserInterpreter()
        {
            AgendaValidCommands =
                new Dictionary<string, IUserOrder>()
                {
                    {"EXIT", new InterpreterOfEscape()},
                    {"ADD ", new InterpreterOfAdd(agendaController)},
                    {"SHOW", new InterpreterOfShow(agendaController)},
                    {"REMOVE ", new InterpreterOfRemove(agendaController)}
                };
        }
        public void ParseUserCommand(string userEntry)
        {
           
            foreach(string commandName in AgendaValidCommands.Keys)
            {
                if (userEntry.StartsWith(commandName))
                {
                    string agendaCommand = ReplaceTextOnce(userEntry, commandName, string.Empty);
                    AgendaValidCommands[commandName].ExecuteTask(agendaCommand);
                    return;
                }
            }
            ThrowInvalidCommandError(AgendaValidCommands);
        }
       
        private string ReplaceTextOnce(string textToModify,string oldCharSeq,string newCharSeq)
        {
            var regex = new Regex(Regex.Escape(oldCharSeq));
            return regex.Replace(textToModify, newCharSeq, 1);
        }
        private void ThrowInvalidCommandError(Dictionary<string,IUserOrder> agendaValidCommands)
        {
            Console.WriteLine("Error, porfavor inserte un comando valido\nCOMANDOS:");
            int commandNumber = 1;
            foreach (string validCommand in agendaValidCommands.Keys)
            {
                Console.WriteLine(commandNumber+". "+validCommand);
                commandNumber++;
            }
        }
        public void AddUserValidCommand(string commandName, IUserOrder executableCommand)
        {
            AgendaValidCommands.Add(commandName, executableCommand);
        }

        public AgendaController GetAgendaController()
        {
            return agendaController;
        }
    }
}
