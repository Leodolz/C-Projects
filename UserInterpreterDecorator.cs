using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaApp
{
    class UserInterpreterDecorator:IUserInterpreter
    {
        protected IUserInterpreter decoratedInterpreter;
        public UserInterpreterDecorator(IUserInterpreter decoratedInterpreter)
        {
            this.decoratedInterpreter = decoratedInterpreter;
            AddUserValidCommand();
        }

        public void AddUserValidCommand(string commandName=null, IUserOrder executableCommand=null)
        {
            decoratedInterpreter.AddUserValidCommand("SEARCH ", new InterpreterOfSearch(AgendaController.getInstance()));
        }

        public void ParseUserCommand(string userEntry)
        {
            decoratedInterpreter.ParseUserCommand(userEntry);
        }
    }
}
