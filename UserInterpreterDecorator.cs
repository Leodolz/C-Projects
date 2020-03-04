using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaApp
{
    class UserInterpreterDecorator:IUserInterpreter
    {
        protected IUserInterpreter decoratedInterpreter;
        protected AgendaController agendaController;
        public UserInterpreterDecorator(IUserInterpreter decoratedInterpreter)
        {
            this.decoratedInterpreter = decoratedInterpreter;
            agendaController = GetAgendaController();
            AddUserValidCommand();
        }

        public void AddUserValidCommand(string commandName=null, IUserOrder executableCommand=null)
        {
            decoratedInterpreter.AddUserValidCommand("SEARCH ", new InterpreterOfSearch(agendaController));
        }
        public AgendaController GetAgendaController()
        {
            return decoratedInterpreter.GetAgendaController();
        }

        public void ParseUserCommand(string userEntry)
        {
            decoratedInterpreter.ParseUserCommand(userEntry);
        }
    }
}
