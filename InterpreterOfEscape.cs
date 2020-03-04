using System;

namespace AgendaApp
{
    class InterpreterOfEscape : IUserOrder
    {
        public void ExecuteTask(string text)
        {
            Environment.Exit(0);
        }
    }
}
