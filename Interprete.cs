using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace AgendaApp
{
    class Interprete
    {
        Agenda_Ayudante ayudante = new Agenda_Ayudante();
        private const int PLAIN_TEXT = 1;
        private const int DOS_ENTRADAS = 2;
        private const int TRES_ENTRADAS = 3;
        public bool comando(string entrada)
        {
            if (entrada.StartsWith("ADD"))
            {
                add(reemplazarUnaVez(entrada, "ADD ", ""));
            }
            else if (entrada.StartsWith("SHOW"))
            {
                show(reemplazarUnaVez(entrada, "SHOW", ""));
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
            AddCommand ejecutarAdd = revisarComandoAdd(separado);
            if (ejecutarAdd != null)
                ejecutarAdd.Add(separado);
        }

        private void show(string fecha)
        {
            if (fecha.Trim().Equals(string.Empty))
                fecha = DateTime.Today.ToString("dd-MM-yyyy");
            if (Validators.validarFecha(fecha.Trim()))
                ayudante.show(fecha);
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
       
        private AddCommand revisarComandoAdd(string[] separado)
        {
            switch (separado.Length)
            {
                case PLAIN_TEXT:
                    return new AddPlainText(ayudante);
                case DOS_ENTRADAS:
                    return new AddTwoEntries(ayudante);
                case TRES_ENTRADAS:
                    return new AddThreeEntries(ayudante);
                default:
                    Console.WriteLine("Formato invalido, vuelva a intentar");
                    return null;
            }
        }
    }
}
