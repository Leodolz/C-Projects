using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaApp
{
    class InterpreterOfEscape : IOrder
    {
        public void ExecuteTask(string text)
        {
            Environment.Exit(0);
        }
    }
}
