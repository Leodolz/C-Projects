using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace AgendaApp
{
    class Interpreter
    {
        AgendaHelper ayudante = new AgendaHelper();
        private const int PLAIN_TEXT = 1;
        private const int TWO_ENTRIES = 2;
        private const int THREE_ENTRIES = 3;
        public bool command(string entrada)
        {
            if (entrada.StartsWith("ADD"))
            {
                add(replaceOnce(entrada, "ADD ", ""));
            }
            else if (entrada.StartsWith("SHOW"))
            {
                show(replaceOnce(entrada, "SHOW", ""));
            }
            else if (entrada.StartsWith("REMOVE "))
            {
                remove(replaceOnce(entrada, "REMOVE ", ""));
            }
            else if (entrada.StartsWith("ESC"))
                return true;
            else
                Console.WriteLine("Error, porfavor inserte un comando valido\nCOMANDOS:\nADD\nSHOW\nREMOVE");
            return false;
        }
        private void add(string entrada)
        {
            string[] separado = entrada.Split(" ");
            AgendaAdd agendaAdd = checkAddCommand(separado);
            if (agendaAdd != null)
                agendaAdd.execute(separado);
        }

        private void show(string date)
        {
            date = AgendaTools.putDateIfNecessary(date);
            if (Validators.isValidDate(date.Trim()))
                ayudante.show(date);
            else Console.WriteLine("Formato Erroneo, por favor intente de nuevo");
        }
        private void remove(string entry)
        {
            ayudante.remove(int.Parse(entry));
        }
        private string replaceOnce(string texto,string viejoReg,string nuevoReg)
        {
            var regex = new Regex(Regex.Escape(viejoReg));
            return regex.Replace(texto, nuevoReg, 1);

        }
       
        private AgendaAdd checkAddCommand(string[] separado)
        {
            switch (separado.Length)
            {
                case PLAIN_TEXT:
                    return new AddPlainText(ayudante);
                case TWO_ENTRIES:
                    return new AddTwoEntries(ayudante);
                case THREE_ENTRIES:
                    return new AddThreeEntries(ayudante);
                default:
                    Console.WriteLine("Formato invalido, vuelva a intentar");
                    return null;
            }
        }
    }
}
