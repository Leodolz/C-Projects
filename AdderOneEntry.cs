using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaApp
{
    class AdderOneEntry : IOrder
    {
        AgendaController controller;
        public AdderOneEntry(AgendaController controller)
        {
            this.controller = controller;
        }
        public void ExecuteTask(string text)
        {
            controller.AddEntry(text);
        }
    }
}
