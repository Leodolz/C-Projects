using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace AgendaApp
{
    class Interpreter
    {
        AgendaActions agendaClient = new AgendaActions();
        private const int ONE_ENTRY = 1;
        private const int TWO_ENTRIES = 2;
        private const int THREE_ENTRIES = 3;
        public bool command(string userEntry)
        {
            if (userEntry.StartsWith("ADD"))
            {
                add(replaceOnce(userEntry, "ADD ", ""));
            }
            else if (userEntry.StartsWith("SHOW"))
            {
                show(replaceOnce(userEntry, "SHOW", ""));
            }
            else if (userEntry.StartsWith("REMOVE "))
            {
                remove(replaceOnce(userEntry, "REMOVE ", ""));
            }
            else if (userEntry.StartsWith("ESC"))
                return true;
            else
                Console.WriteLine("Error, porfavor inserte un comando valido\nCOMANDOS:\nADD\nSHOW\nREMOVE");
            return false;
        }
        private void add(string userEntry)
        {
            string[] separado = userEntry.Split(" ");
            AgendaAdd agendaAdd = checkAddCommand(separado);
            if (agendaAdd != null)
                agendaAdd.execute(separado);
        }

        private void show(string date)
        {
            date = AgendaTools.putDateIfNecessary(date);
            if (Validators.isValidDate(date.Trim()))
                agendaClient.show(date);
            else Console.WriteLine("Formato Erroneo, por favor intente de nuevo");
        }
        private void remove(string idEntry)
        {
            int id;
            if (int.TryParse(idEntry, out id))
                agendaClient.remove(id);
            else Console.WriteLine("Comando invalido, por favor intente de nuevo");
        }
        private string replaceOnce(string texto,string viejoReg,string nuevoReg)
        {
            var regex = new Regex(Regex.Escape(viejoReg));
            return regex.Replace(texto, nuevoReg, 1);

        }
       
        private AgendaAdd checkAddCommand(string[] userEntry)
        {
            switch (userEntry.Length)
            {
                case ONE_ENTRY:
                    return new AddPlainText(agendaClient);
                case TWO_ENTRIES:
                    return new AddTwoEntries(agendaClient);
                case THREE_ENTRIES:
                    return new AddThreeEntries(agendaClient);
                default:
                    Console.WriteLine("Formato invalido, vuelva a intentar");
                    return null;
            }
        }
    }
}
