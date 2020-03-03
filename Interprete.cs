using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace AgendaApp
{
    class Interprete
    {
        Agenda_Ayudante ayudante = new Agenda_Ayudante();
        private static string[] formatosFecha = new[] { "MM/dd/yyyy", "dd/MM/yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "MM-dd-yyyy", "dd-MM-yyyy" };
        private const int PLAIN_TEXT = 1;
        private const int DOS_ENTRADAS = 2;
        private const int TRES_ENTRADAS = 3;
        private const string EMPTY = "";
        public bool comando(string entrada)
        {
            if (entrada.StartsWith("ADD"))
            {
                add(reemplazarUnaVez(entrada, "ADD ", ""));
            }
            else if (entrada.StartsWith("SHOW"))
            {
                show(reemplazarUnaVez(entrada, "SHOW ", ""));
            }
            else if (entrada.StartsWith("REMOVE "))
            {
                eliminar(reemplazarUnaVez(entrada, "REMOVE ", ""));
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
            switch(separado.Length)
            {
                case PLAIN_TEXT:
                    ayudante.add(separado[0]);
                    break;
                case DOS_ENTRADAS:
                    reconocerComando(separado);
                    break;
                case TRES_ENTRADAS:
                    ayudante.add(separado[2], separado[0], separado[1]);
                    break;
                default:
                    Console.WriteLine("Formato invalido, vuelva a intentar");
                    break;
            }
            
        }

        private void reconocerComando(string[] comando)
        {
            if (validarFecha(comando[0])) //Es Fecha primero
                ayudante.add(comando[1], comando[0]);
            else if (validarHora(comando[0])) //Es Hora primero
                ayudante.add(comando[1], EMPTY, comando[0]);
            else Console.WriteLine("Comando invalido, intente de nuevo");
        }

        private void show(string entrada)
        {
            if (entrada.Equals(EMPTY) || entrada.Equals(" "))
            {
                ayudante.show();
                return;
            }
            if (validarFecha(entrada))
            {
                ayudante.show(entrada);
            }

            else Console.WriteLine("Formato Erroneo, por favor intente de nuevo");
        }
        private void eliminar(string entrada)
        {
            ayudante.remove(int.Parse(entrada));
        }
        private string reemplazarUnaVez(string texto,string viejoReg,string nuevoReg)
        {
            var regex = new Regex(Regex.Escape(viejoReg));
            return regex.Replace(texto, nuevoReg, 1);

        }
        private bool validarFecha(string entrada)
        {
            DateTime date;
            return DateTime.TryParseExact(entrada, formatosFecha, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
        }
        private bool validarHora(string entrada)
        {
            Regex revisarTiempo = new Regex(@"^(?i)(0?[1-9]|1[0-9]|2[0-4]):([0-5][0-9])(:[0-5][0-9])?( AM| PM)?$");
            return revisarTiempo.IsMatch(entrada);
        }
    
    }
}
